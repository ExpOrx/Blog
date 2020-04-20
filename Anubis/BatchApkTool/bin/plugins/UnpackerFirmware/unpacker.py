import os
import sys
import errno
import struct
import traceback
import argparse
import zipfile
from subprocess import Popen, PIPE, STDOUT


__version__ = '1.6.0'
__author__ = ' unix3dgforce [MiuiPro.by DEV Team]'
__copyright__ = ' Copyright (c) 2018 Miuipro.by'

EXT4_HEADER_MAGIC = 0xED26FF3A
EXT4_SPARSE_HEADER_LEN = 28
EXT4_CHUNK_HEADER_SIZE = 12


class ext4_file_header(object):
    def __init__(self, buf):
        (self.magic,
         self.major,
         self.minor,
         self.file_header_size,
         self.chunk_header_size,
         self.block_size,
         self.total_blocks,
         self.total_chunks,
         self.crc32) = struct.unpack('<I4H4I', buf)


class ext4_chunk_header(object):
    def __init__(self, buf):
        (self.type,
         self.reserved,
         self.chunk_size,
         self.total_size) = struct.unpack('<2H2I', buf)


class LinkError(Exception):
    pass


class Unpacker(object):
    def __init__(self):
        self.BASE_DIR = (os.path.realpath(os.path.dirname(sys.argv[0])) + os.sep).split('bin', 1)[0]
        self.OUTPUT_IMAGE_FILE = self.BASE_DIR + 'system.img'
        self.EXTRACT_DIR = self.BASE_DIR + 'system_'
        self.BLOCK_SIZE = 4096
        self.TYPE_IMG = 'system'
        self.symlinks = []
        self.context = []
        self.fsconfig = []
        self.brotli = False

    def __logtb(self, ex, ex_traceback=None):
        if ex_traceback is None:
            ex_traceback = ex.__traceback__
        tb_lines = [line.rstrip('\n') for line in
                    traceback.format_exception(ex.__class__, ex, ex_traceback)]
        return '\n'.join(tb_lines)

    def __appendf(self, msg, log_file):
        with open(log_file, 'a', newline='\n') as file:
            print(msg, file=file)

    def __rangeset(self, src):
        src_set = src.split(',')
        num_set = [int(item) for item in src_set]
        if len(num_set) != num_set[0] + 1:
            print('Error on parsing following data to rangeset:\n%s' % src)
            sys.exit(1)
        return tuple([(num_set[i], num_set[i + 1]) for i in range(1, len(num_set), 2)])

    def __parse_transfer_list_file(self):
        trans_list = open(self.TRANSFER_FILE_PATH, 'r')
        version = int(trans_list.readline())

        new_blocks = int(trans_list.readline())

        if version >= 2:
            trans_list.readline()
            trans_list.readline()

        commands = []
        for line in trans_list:
            line = line.split(' ')
            cmd = line[0]
            if cmd in ['erase', 'new', 'zero']:
                commands.append([cmd, self.__rangeset(line[1])])
            else:
                if not cmd[0].isdigit():
                    print('Command "%s" is not valid.' % cmd)
                    trans_list.close()
                    sys.exit(1)
        trans_list.close()
        return version, new_blocks, commands

    def __convert(self):
        version, new_blocks, commands = self.__parse_transfer_list_file()
        if version == 1:
            print('Android Lollipop 5.0 detected!')
        elif version == 2:
            print('Android Lollipop 5.1 detected!')
        elif version == 3:
            print('Android Marshmallow 6.x detected!')
        elif version == 4:
            print('Android Nougat 7.x / Oreo 8.x detected!')
        else:
            print('Unknown Android version!')
        if not os.path.isdir(os.path.dirname(self.OUTPUT_IMAGE_FILE)):
            os.mkdir(os.path.dirname(self.OUTPUT_IMAGE_FILE))
        output_img = open(self.OUTPUT_IMAGE_FILE, 'wb')

        new_data_file = open(self.DAT_FILE_PATH, 'rb')
        all_block_sets = [i for command in commands for i in command[1]]
        max_file_size = max(pair[1] for pair in all_block_sets) * self.BLOCK_SIZE

        for command in commands:
            if command[0] == 'new':
                for block in command[1]:
                    begin = block[0]
                    end = block[1]
                    block_count = end - begin
                    output_img.seek(begin * self.BLOCK_SIZE)
                    while (block_count > 0):
                        output_img.write(new_data_file.read(self.BLOCK_SIZE))
                        block_count -= 1
        if output_img.tell() < max_file_size:
            output_img.truncate(max_file_size)

        output_img.close()
        new_data_file.close()

    def __unpackZIP(self, zip_file):
        path_project = self.BASE_DIR + 'project_' + self.PROJECT_NAME + os.sep
        convert_files = []
        check_file = ["system.new.dat", "system.transfer.list"]
        brotli_check_file = ["system.new.dat.br", "system.transfer.list"]
        try:
            zip_file_ref = zipfile.ZipFile(zip_file, 'r')
        except zipfile.BadZipFile:
            return "corrupted file %s" % os.path.basename(zip_file)
        result = zip_file_ref.testzip()
        if result is None:
            try:
                for file in check_file:
                    zip_file_ref.getinfo(file)
            except KeyError:
                try:
                    for file in brotli_check_file:
                        zip_file_ref.getinfo(file)
                except KeyError:
                    return "no such file %s" % file
                self.brotli = True

        if self.brotli:
            check_file = brotli_check_file
        for file in check_file:
            zip_file_ref.extract(file, path_project)
        convert_files.append([path_project + check_file[x] for x in range(len(check_file))])
        try:
            zip_file_ref.getinfo('file_contexts.bin')
            zip_file_ref.extract('file_contexts.bin', path_project)
        except KeyError:
            pass
        try:
            if self.brotli:
                vendor_check_file = ["vendor.new.dat.br", "vendor.transfer.list"]
            else:
                vendor_check_file = ["vendor.new.dat", "vendor.transfer.list"]
            for file in vendor_check_file:
                zip_file_ref.getinfo(file)
                zip_file_ref.extract(file, path_project)
            convert_files.append([path_project + vendor_check_file[x] for x in range(len(vendor_check_file))])
        except KeyError:
            pass
        exclude_list = ["system.new.dat", "system.new.dat.br", "system.transfer.list", "system.patch.dat", "vendor.new.dat", "vendor.new.dat.br", "vendor.transfer.list", "vendor.patch.dat", "file_contexts.bin", "boot.img"]
        for item in zip_file_ref.namelist():
            if not item in exclude_list:
                zip_file_ref.extract(item, path_project + 'other')
        zip_file_ref.close()
        setattr(self,'job',convert_files)
        self.BASE_DIR = path_project
        return

    def __getperm(self, arg):
        if len(arg) < 9 or len(arg) > 10:
            return
        if len(arg) > 8:
            arg = arg[1:]
        oor, ow, ox, gr, gw, gx, wr, ww, wx = list(arg)
        o, g, w, s = 0, 0, 0, 0
        if oor == 'r': o += 4
        if ow == 'w': o += 2
        if ox == 'x': o += 1
        if ox == 'S': s += 4
        if ox == 's': s += 4; o += 1
        if gr == 'r': g += 4
        if gw == 'w': g += 2
        if gx == 'x': g += 1
        if gx == 'S': s += 2
        if gx == 's': s += 2; g += 1
        if wr == 'r': w += 4
        if ww == 'w': w += 2
        if wx == 'x': w += 1
        if wx == 'T': s += 1
        if wx == 't': s += 1; w += 1
        return str(s) + str(o) + str(g) + str(w)  # original

    def __ext4Xtract(self , symlinks_file='symlinks.txt', fs_config_file='fs_config.txt'):
        import ext4, string, struct
        def scan_dir(root_inode, root_path=""):
            for entry_name, entry_inode_idx, entry_type in root_inode.open_dir():
                if entry_name in ['.', '..', 'lost+found'] or entry_name.endswith(' (2)'):
                    continue
                entry_inode = root_inode.volume.get_inode(entry_inode_idx, entry_type)
                entry_inode_path = root_path + '/' + entry_name
                mode = self.__getperm(entry_inode.mode_str)
                uid = entry_inode.inode.i_uid
                gid = entry_inode.inode.i_gid
                con = '?'
                cap = ''
                for i in list(entry_inode.xattrs()):
                    if i[0] == 'security.selinux':
                        con = i[1].decode('utf8')[:-1]
                    elif i[0] == 'security.capability':
                        cap = ' capabilities=' + str(hex(struct.unpack("<IIIII", i[1])[1]))
                if entry_inode.is_dir:
                    dir_target = self.EXTRACT_DIR + entry_inode_path
                    if not os.path.isdir(dir_target):
                        os.makedirs(dir_target)
                    if os.name == 'posix':
                        os.chmod(dir_target, int(mode, 8))
                        os.chown(dir_target, uid, gid)
                    self.fsconfig.append('%s %s %s %s' % (self.DIR + entry_inode_path, uid, gid, mode + cap))
                    scan_dir(entry_inode, entry_inode_path)
                elif entry_inode.is_file:
                    try:
                        raw = entry_inode.open_read().read()
                    except Exception as e:
                        self.__appendf(entry_inode_path, self.BASE_DIR + os.sep + 'unpack.log')
                        self.__appendf(self.__logtb(e), self.BASE_DIR + os.sep + 'unpack.log')
                        continue
                    wdone = None
                    if os.name == 'nt':
                        if entry_name.endswith('/'):
                            entry_name = entry_name[:-1]
                        file_target = self.EXTRACT_DIR + entry_inode_path.replace('/', os.sep)
                        if not os.path.isdir(os.path.dirname(file_target)):
                            os.makedirs(os.path.dirname(file_target))
                        with open(file_target, 'wb') as out:
                            out.write(raw)
                    if os.name == 'posix':
                        file_target = self.EXTRACT_DIR + entry_inode_path
                        if not os.path.isdir(os.path.dirname(file_target)):
                            os.makedirs(os.path.dirname(file_target))
                        with open(file_target, 'wb') as out:
                            out.write(raw)
                        os.chmod(file_target, int(mode, 8))
                        os.chown(file_target, uid, gid)
                    self.fsconfig.append('%s %s %s %s' % (self.DIR + entry_inode_path, uid, gid, mode + cap))
                elif entry_inode.is_symlink:
                    try:
                        link_target = entry_inode.open_read().read().decode("utf8")
                        target = self.EXTRACT_DIR + entry_inode_path
                        if os.path.islink(target):
                            try:
                                os.remove(target)
                            except OSError:
                                pass
                        if os.path.isfile(target):
                            try:
                                os.remove(target)
                            except OSError:
                                pass
                        if os.name == 'posix':
                            os.symlink(link_target, target)
                        if os.name == 'nt':
                            with open(target.replace('/', os.sep), 'wb') as out:
                                tmp = bytes.fromhex('213C73796D6C696E6B3EFFFE')
                                for index in list(link_target):
                                    tmp = tmp + struct.pack('>sx', index.encode('utf-8'))
                                out.write(tmp + struct.pack('xx'))
                                os.system('attrib +s "%s"' % target.replace('/', os.sep))
                        if not all(c in string.printable for c in link_target):
                            raise LinkError
                        # if entry_inode_path[1:] == entry_name or link_target[1:] == entry_name:
                        #     self.symlinks.append('%s %s' % (link_target, entry_inode_path[1:]))
                        # else:
                        if len(entry_inode_path.split('/')) <= 2:
                            if entry_inode_path == '/vendor':
                                self.symlinks.append('%s %s' % (link_target, self.DIR + entry_inode_path))
                            else:
                                self.symlinks.append('%s %s' % (link_target, entry_inode_path[1:]))
                        elif entry_inode_path.find('/'+self.DIR) == -1:
                            self.symlinks.append('%s %s' % (link_target, self.DIR + entry_inode_path))
                        else:
                            self.symlinks.append('%s %s' % (link_target, entry_inode_path[1:]))
                        self.fsconfig.append('%s %s %s %s' % (self.DIR + entry_inode_path, uid, gid, mode + cap))
                    except LinkError:
                        try:
                            link_target_block = int.from_bytes(entry_inode.open_read().read(), "little")
                            link_target = root_inode.volume.read(link_target_block * root_inode.volume.block_size, entry_inode.inode.i_size).decode("utf8")

                            if link_target and all(c in string.printable for c in link_target):
                                self.symlinks.append('%s %s' % (link_target, self.DIR + entry_inode_path))
                            else:
                                self.__appendf('Failed symlink: ' + entry_inode_path, self.BASE_DIR + os.sep + 'unpack.log')
                        except:
                            self.__appendf('Failed symlink: ' + entry_inode_path, self.BASE_DIR + os.sep + 'unpack.log')
                self.context.append('/%s %s' % (self.DIR + entry_inode_path, con))


        with open(self.OUTPUT_IMAGE_FILE, 'rb') as file:
            root = ext4.Volume(file).root
            dirlist = []
            for file_name, inode_idx, file_type in root.open_dir():
                dirlist.append(file_name)
            dirr = os.path.basename(self.OUTPUT_IMAGE_FILE).split('.')[0]
            setattr(self, 'DIR', dirr)
            if dirr == 'system':
                self.fsconfig = [dirr + ' 0 0 0755']
            elif dirr == 'vendor':
                self.fsconfig = [dirr + ' 0 2000 0755']
            self.context = ['/'+dirr+' u:object_r:'+dirr+'_file:s0']
            if not os.path.exists(self.EXTRACT_DIR):
                os.makedirs(self.EXTRACT_DIR)
            scan_dir(root)
            for item in self.symlinks:
                self.__appendf('symlink("'+item.split()[0]+'", "/'+item.split()[1]+'");', self.BASE_DIR + os.sep + symlinks_file)
            self.__appendf('\n'.join(self.fsconfig), self.BASE_DIR + os.sep +  fs_config_file)
            # self.__appendf('\n'.join(self.context), self.BASE_DIR + os.sep + self.PROJECT_NAME + '____file_contexts.txt')

    def __convertContextFile(self, target):
        if os.path.isfile(self.BASE_DIR + os.sep + 'file_contexts.bin'):
            from sefcontext import SefContext
            sef_parser = SefContext(self.BASE_DIR + os.sep + 'file_contexts.bin')
            with open(target, 'w') as out:
                entries = sef_parser.decompile()
                for entry in entries:
                    out.write("%s\n" % str(entry))

    def __converSimgToImg(self, target):
        with open(target, "rb") as img_file:
            if self.sign_offset > 0:
                img_file.seek(self.sign_offset, 0)
            header = ext4_file_header(img_file.read(28))
            total_chunks = header.total_chunks
            if header.file_header_size > EXT4_SPARSE_HEADER_LEN:
                img_file.seek(header.file_header_size - EXT4_SPARSE_HEADER_LEN, 1)
            with open(target.replace(".img", ".raw.img"), "wb") as raw_img_file:
                sector_base = 82528
                output_len = 0
                while total_chunks > 0:
                    chunk_header = ext4_chunk_header(img_file.read(EXT4_CHUNK_HEADER_SIZE))
                    sector_size = (chunk_header.chunk_size * header.block_size) >> 9
                    chunk_data_size = chunk_header.total_size - header.chunk_header_size
                    if chunk_header.type == 0xCAC1:  # CHUNK_TYPE_RAW
                        if header.chunk_header_size > EXT4_CHUNK_HEADER_SIZE:
                            img_file.seek(header.chunk_header_size - EXT4_CHUNK_HEADER_SIZE, 1)
                        data = img_file.read(chunk_data_size)
                        len_data = len(data)
                        if len_data == (sector_size << 9):
                            raw_img_file.write(data)
                            output_len += len_data
                            sector_base += sector_size
                    else:
                        if chunk_header.type == 0xCAC2:  # CHUNK_TYPE_FILL
                            if header.chunk_header_size > EXT4_CHUNK_HEADER_SIZE:
                                img_file.seek(header.chunk_header_size - EXT4_CHUNK_HEADER_SIZE, 1)
                            data = img_file.read(chunk_data_size)
                            len_data = sector_size << 9
                            raw_img_file.write(struct.pack("B", 0) * len_data)
                            output_len += len(data)
                            sector_base += sector_size
                        else:
                            if chunk_header.type == 0xCAC3:  # CHUNK_TYPE_DONT_CARE
                                if header.chunk_header_size > EXT4_CHUNK_HEADER_SIZE:
                                    img_file.seek(header.chunk_header_size - EXT4_CHUNK_HEADER_SIZE, 1)
                                data = img_file.read(chunk_data_size)
                                len_data = sector_size << 9
                                raw_img_file.write(struct.pack("B", 0) * len_data)
                                output_len += len(data)
                                sector_base += sector_size
                            else:
                                len_data = sector_size << 9
                                raw_img_file.write(struct.pack("B", 0) * len_data)
                                sector_base += sector_size
                    total_chunks -= 1
        self.OUTPUT_IMAGE_FILE = target.replace(".img", ".raw.img")

    def checkSignOffset(self, file):
        import mmap
        offset = 0
        mm = mmap.mmap(file.fileno(), 52428800, access=mmap.ACCESS_READ)  # 52428800=50Mb
        result = mm.find(struct.pack('<L', EXT4_HEADER_MAGIC))
        if result > 0:
            offset = result
        return offset

    def __getTypeTarget(self, target):
        filename, file_extension = os.path.splitext(target)
        if file_extension == '.zip':
            return 'zip'
        elif file_extension == '.xml':
            return 'xml'
        elif file_extension == '.img':
            with open(target, "rb") as img_file:
                setattr(self, 'sign_offset', self.checkSignOffset(img_file))
                if self.sign_offset > 0:
                    img_file.seek(self.sign_offset, 0)
                header = ext4_file_header(img_file.read(28))
                if header.magic != EXT4_HEADER_MAGIC:
                    return 'img'
                else:
                    return 'simg'
        elif file_extension == '.dat':
            tmp = os.path.basename(filename).split('.')[0]
            if os.path.isfile(os.path.dirname(target) + os.sep + tmp + '.transfer.list'):
                self.DAT_FILE_PATH = target
                self.TRANSFER_FILE_PATH = os.path.dirname(target) + os.sep + tmp + '.transfer.list'
                if tmp != 'system':
                    self.OUTPUT_IMAGE_FILE = os.path.dirname(target) + os.sep + tmp + '.img'
                    self.EXTRACT_DIR = self.EXTRACT_DIR + os.sep + '_' + tmp
                    self.TYPE_IMG = tmp
                else:
                    self.EXTRACT_DIR = self.EXTRACT_DIR + os.sep + '_' + tmp
                    self.OUTPUT_IMAGE_FILE = os.path.dirname(self.EXTRACT_DIR) + os.sep + tmp + '.img'
                    self.TYPE_IMG = tmp
                return 'dat'
        elif file_extension == '.br':
            tmp = os.path.basename(filename).split('.')[0]
            if os.path.isfile(os.path.dirname(target) + os.sep + tmp + '.transfer.list'):
                self.DAT_FILE_PATH = os.path.dirname(target) + os.sep + tmp + '.new.dat'
                self.TRANSFER_FILE_PATH = os.path.dirname(target) + os.sep + tmp + '.transfer.list'
                if tmp != 'system':
                    self.OUTPUT_IMAGE_FILE = os.path.dirname(target) + os.sep + tmp + '.img'
                    self.EXTRACT_DIR = self.EXTRACT_DIR + os.sep + '_' + tmp
                    self.TYPE_IMG = tmp
                else:
                    self.EXTRACT_DIR = self.EXTRACT_DIR + os.sep + '_' + tmp
                    self.OUTPUT_IMAGE_FILE = os.path.dirname(self.EXTRACT_DIR) + os.sep + tmp + '.img'
                    self.TYPE_IMG = tmp
                return 'br'

    def unpack(self, target):
        setattr(self, 'PROJECT_NAME', os.path.basename(os.path.splitext(target)[0]))
        print("\nPython Version: " + sys.version)
        print("Version Plugin: " + __version__)
        print("Author Plugin:" + __author__)
        print("Copyright:" + __copyright__)
        print("Work Dir BATCH APKTOOL: " + self.BASE_DIR)
        print("\nProcessing unpack %s" % self.PROJECT_NAME)
        target_type = self.__getTypeTarget(target)
        if target_type == 'simg':
            print("Convert %s to %s" % (os.path.basename(target), os.path.basename(target).replace(".img", ".raw.img")))
            self.__converSimgToImg(target)
            print("Extraction from %s\n" % os.path.basename(target).replace(".img", ".raw.img"))
            self.__ext4Xtract()
        if target_type == 'xml':
            from qfil import Qfil
            print("Convert system_XX.unsparse to system.raw.img")
            self.OUTPUT_IMAGE_FILE = Qfil().convert(target)
            self.EXTRACT_DIR = os.path.dirname(self.OUTPUT_IMAGE_FILE) + os.sep + os.path.basename(self.EXTRACT_DIR)
            self.BASE_DIR = os.path.dirname(self.EXTRACT_DIR)
            print("Extraction from %s\n" % os.path.basename(self.OUTPUT_IMAGE_FILE))
            self.__ext4Xtract()
        if target_type == 'img':
            print("Extraction from %s\n" % os.path.basename(target))
            self.__ext4Xtract()
        if target_type == 'dat':
            self.BASE_DIR = os.path.dirname(self.EXTRACT_DIR)
            self.__convert()
            print("Extraction from %s.img\n" % self.TYPE_IMG)
            self.__ext4Xtract()
        if target_type == 'br':
            print("Convert %s to %s" % (os.path.basename(target), os.path.basename(target).replace(".new.dat.br", ".new.dat")))
            if os.path.isfile(self.DAT_FILE_PATH):
                os.unlink(self.DAT_FILE_PATH)
            Popen('%s -d \"%s\" -o \"%s\"' % (os.path.join(os.path.abspath(os.path.dirname(__file__)), 'bin') + os.sep + 'brotli.exe', target, self.DAT_FILE_PATH), shell=False, stdin=PIPE, stdout=PIPE, stderr=STDOUT, universal_newlines=True).communicate()
            self.BASE_DIR = os.path.dirname(self.EXTRACT_DIR)
            self.__convert()
            print("Extraction from %s.img\n" % self.TYPE_IMG)
            self.__ext4Xtract()
        if target_type == 'zip':
            status = self.__unpackZIP(target)
            if status is None:
                print("Generate file_contexts")
                self.__convertContextFile(self.BASE_DIR + os.sep + 'file_contexts.txt')
                for item in self.job:
                    self.symlinks = []
                    self.context = []
                    self.fsconfig = []
                    if self.brotli:
                        print("Convert %s to %s" % (os.path.basename(item[0]), os.path.basename(item[0]).replace(".new.dat.br", ".new.dat")))
                        self.DAT_FILE_PATH = item[0].replace(".new.dat.br", ".new.dat")
                        if os.path.isfile(self.DAT_FILE_PATH):
                            os.unlink(self.DAT_FILE_PATH)
                        Popen('%s -d \"%s\" -o \"%s\"' % (os.path.join(os.path.abspath(os.path.dirname(__file__)), 'bin') + os.sep + 'brotli.exe', item[0], self.DAT_FILE_PATH), shell=False, stdin=PIPE, stdout=PIPE, stderr=STDOUT, universal_newlines=True).communicate()
                    else:
                        self.DAT_FILE_PATH = item[0]
                    self.TRANSFER_FILE_PATH = item[1]
                    tmp = os.path.basename(item[0]).split('.')[0]
                    self.OUTPUT_IMAGE_FILE = self.BASE_DIR + tmp + '.img'
                    self.EXTRACT_DIR = self.BASE_DIR + '_' + tmp
                    self.__convert()
                    print("Extraction from %s.img" % os.path.basename(item[0]).split('.')[0])
                    self.__ext4Xtract()
                print('\n')
            else:
                print('Error %s in %s' % (status, os.path.basename(target)))


def createParser():
    parser = argparse.ArgumentParser(description='Unpack Firmware')
    parser.add_argument('-v', '--version', action='version',
                        version='Unpacker Firmware version [' + __version__ + '] ')
    subparsers = parser.add_subparsers(dest='command', help='List of commands')
    target = subparsers.add_parser('unpack', help='Unpack firmware')
    target.add_argument('-f', '--file')
    return parser


if __name__ == '__main__':
    parser = createParser()
    namespace = parser.parse_args()
    if len(sys.argv) >= 2:
        if namespace.command == 'unpack':
            Unpacker().unpack(namespace.file)
        else:
            parser.print_help()
            sys.exit(2)
        sys.exit(0)
    else:
        parser.print_usage()
        sys.exit(1)
