from PIL import Image
import struct
import os

def create_magic(p1,p2,p3):
	return (p1<<2 &4 | p2 & 2 | p2 & 1 | p1 << 2 & 8 | p3)

def dex_extractor(p1,p2):
	return ord(d[p1%size])^p2

if __name__ == '__main__':

	image_file = "C:\\Users\\Tony_Bao\\Desktop\\prcnbzqn.png"
	so_file = "C:\\Users\\Tony_Bao\\Desktop\\libhoter.so"
	offset = 0x34755
	size = 0x1fa
	output_file = "C:\\Users\\Tony_Bao\\Desktop\\drop.dex"

	im = Image.open(image_file)
	rgb_im = im.convert('RGB')
	im_y = im.size[1]
	im_x = im.size[0]
	dex_size = im_y * im_x / 2 - 255

	f = open(so_file,'rb')
	d = f.read()
	d = d[offset:offset + size]

	count = 0
	dex_file = open(output_file,"wb")
	second = False
	magic_byte = 0
	for y in range(0,im.size[1]):
		for x in range(0,im.size[0]):
			r, g, b = rgb_im.getpixel((x, y))
			#print r, g, b
			magic_byte = create_magic(r,b,magic_byte)
			if second:
				magic_byte = magic_byte & 0xff
				dex_byte = dex_extractor(count,magic_byte)
				dex_byte = dex_byte &0xff
				if count > 7 and count-8 < dex_size:
					dex_file.write(struct.pack("B",dex_byte))
				magic_byte = 0
				second = False
				count+=1
			else:
				magic_byte = magic_byte << 4
				second = True

	dex_file.close()


