---
title: 试着逆向一次windows PE文件
---


标签（空格分隔）： windowRE

---

### 0x01 DEMO信息
- md5:c408b2c131bc868e32fcbb677f8e8781

### 环境
- win7专业版
- IDA 7.0
- 火绒剑

### 0x02 静态分析
#### 1.函数调用关系中 GetActiveWindow和MessageBoxW是“系统”函数，所以主要是分析sub_401000这个函数
#### 2.sub_401000函数分析
```
.text:00401000 ; Attributes: bp-based frame
.text:00401000
.text:00401000 sub_401000      proc near               ; CODE XREF: wWinMain(x,x,x,x)↓p
.text:00401000
.text:00401000 Filename        = word ptr -2004h
.text:00401000 pszPath         = word ptr -1004h
.text:00401000 var_4           = dword ptr -4
.text:00401000
.text:00401000                 push    ebp
.text:00401001                 mov     ebp, esp
.text:00401003                 mov     eax, 2004h
.text:00401008                 call    __alloca_probe  ; __alloca_probe is a support routine for the API _alloca() without providing any reference
.text:0040100D                 mov     eax, ___security_cookie ; get the adjusted cookie 0BB40E64Eh
.text:00401012                 xor     eax, ebp        ; adjust based on base pointer.
.text:00401014                 mov     [ebp+var_4], eax ; store adjusted value.ebp-4=___security_cookie
.text:00401017                 push    1000h           ; nSize
.text:0040101C                 lea     eax, [ebp+Filename] ; eax=[ebp-2004h]
.text:00401022                 push    eax             ; lpFilename
.text:00401023                 push    0               ; hModule
.text:00401025                 call    ds:GetModuleFileNameW ; Retrieves the fully qualified path .such as F:\virus\virus.exe
.text:0040102B                 lea     ecx, [ebp+pszPath] ; ecx=[ebp-1004h]
.text:00401031                 push    ecx             ; pszPath
.text:00401032                 push    0               ; dwFlags
.text:00401034                 push    0               ; hToken
.text:00401036                 push    7               ; #define CSIDL_STARTUP 0x0007 // Start Menu\Programs\Startup
.text:00401038                 push    0               ; hwnd
.text:0040103A                 call    ds:SHGetFolderPathW ; Gets the path of a folder identified by a CSIDL value.This path is saved in [ebp-2004h]
.text:00401040                 push    offset String2  ; "\\wsample01b.exe"
.text:00401045                 lea     edx, [ebp+pszPath]
.text:0040104B                 push    edx             ; lpString1
.text:0040104C                 call    ds:lstrcatW     ; Appends one string to another.new string is saved in [ebp-1004h]=Menu\Programs\Startup\wsample01b.exe
.text:00401052                 push    0               ; bFailIfExists
.text:00401054                 lea     eax, [ebp+pszPath] ; Menu\Programs\Startup\wsample01b.exe
.text:0040105A                 push    eax             ; lpNewFileName
.text:0040105B                 lea     ecx, [ebp+Filename] ; the fully qualified path for the file that contains the specified module
.text:00401061                 push    ecx             ; lpExistingFileName
.text:00401062                 call    ds:CopyFileW    ; such as mv current.exe Menu\Programs\Startup\wsample01b.exe,start at boot
.text:00401068                 mov     ecx, [ebp+var_4] ; get the adjusted cookie, ecx=0BB40E64Eh
.text:0040106B                 xor     ecx, ebp
.text:0040106D                 xor     eax, eax
.text:0040106F                 call    @__security_check_cookie@4 ; Check if the cookie changes,prevent stack overflow
.text:00401074                 mov     esp, ebp
.text:00401076                 pop     ebp
.text:00401077                 retn
.text:00401077 sub_401000      endp
.text:00401077
.text:00401077 ; ---------------------------------------------------------------------------
```
### 0x03 火绒剑动态分析,可以看出文件发生了转移，最后设置了开机自启，并修改了注册表




