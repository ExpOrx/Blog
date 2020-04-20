import os
import sys
import xml.etree.ElementTree


class Qfil(object):
    def __init__(self):
        self.target_dir = None
        self.list_work = []
        self.out_file = None
        self.name = None
        self.buffer = 8192
        self.sektor_size = 512

    def __parseXML(self, file_path):
        e = xml.etree.ElementTree.parse(file_path).getroot()
        for item in e.findall('program'):
            if item.get('label') == 'system':
                if self.name is None:
                    self.name = item.get('label')+'.raw.img'
                self.list_work.append(item)

    def __copy_img(self, filename, seek):
        cur_pos = self.out_file.tell()
        if cur_pos != 0:
            for i in range(int((seek * self.sektor_size - cur_pos)/self.sektor_size)):
                self.out_file.write(b'\0' * self.sektor_size)
        try:
            with open(filename, 'rb', buffering=self.buffer) as orig_file:
                self.out_file.write(orig_file.read())
                self.out_file.flush()
        except FileNotFoundError:
            os.unlink(self.out_file)
            print("File \"%s\" not found in directory \"%s\". Unpacking is't possible." % (os.path.basename(filename), self.target_dir))
            sys.exit(0)


    def convert(self, file_path):
        offset = 0
        self.target_dir = os.path.dirname(file_path)
        self.__parseXML(file_path)
        self.out_file = open(self.target_dir + os.sep + self.name, 'wb+', buffering=self.buffer)
        for item in self.list_work:
            start_sector = int(item.get('start_sector'))
            self.sektor_size = int(item.get('SECTOR_SIZE_IN_BYTES'))
            filename = self.target_dir + os.sep + item.get('filename')
            if offset == 0:
                offset = start_sector
            seek = start_sector - offset
            self.__copy_img(filename, seek)
        self.out_file.close()
        return self.target_dir + os.sep + self.name

if __name__ == '__main__':
    Qfil().convert("C:\\Batch ApkTool\\New folder\\rawprogram0.xml")