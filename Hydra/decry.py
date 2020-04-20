import ida_bytes
from idautils import *
from idc import *
def xor_block(addr,size):
    first_block = list(get_bytes(addr,size))
    second_block = list(get_bytes(addr+size,size))
    a = ""
    for i in range(len(first_block)):
         a+=chr((ord(first_block[i])^ord(second_block[i])))
    return a
def block(addr):
    ## block that related to creation of dex file. pass itt
    if addr == 0x34755:      
        return 0x0003494f
    ## get xrefs
    xrefs = list(XrefsTo(addr,0))
    if len(xrefs) ==0:
        ## no xrefs go to next byte
        return addr+1
    for xref in xrefs:
        ref_addr = xref.frm
        try:
            inst = ref_addr+0x20
        except AddressOutOfBoundsException as e:
            print("Found last xor block exiting..")
            exit()
        ## Get size of block with inst.getByte(2)
        block_size = get_operand_value(inst,1)
        ## decrypt blocks
        dec_str = xor_block(addr,block_size)
        ## get function
        func_name = get_func_name(ref_addr)
        print("Block : {} , func : {}, dec string : {}".format(hex(addr),func_name,dec_str))
    return addr+2*block_size
if __name__=="__main__":
    curr_block_location = 0x34035
    for i in range(132):
        curr_block_location = block(curr_block_location)
