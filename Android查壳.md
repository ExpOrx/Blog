---
title: Android查壳
---


标签（空格分隔）： AndroidSec

---

```
娜迦：libchaosvmp.so , libddog.solibfdog.so

爱加密：libexec.so, libexecmain.so，ijiami.dat

梆梆：libsecexe.so, libsecmain.so,libSecShell.so

梆梆企业版：libDexHelper.so , libDexHelper-x86.so

360：libprotectClass.so, libjiagu.so，libjiagu.so, libjiagu_art.so，libjiagu.so, libjiagu_x86.so

通付盾：libegis.so，libNSaferOnly.so

网秦：libnqshield.so

百度：libbaiduprotect.so

阿里聚安全：aliprotect.dat，libsgmain.so，libsgsecuritybody.so

腾讯：libtup.so, libexec.so，libshell.so，mix.dex，lib/armeabi/mix.dex ,lib/armeabi/mixz.dex

腾讯御安全：libtosprotection.armeabi.so，libtosprotection.armeabi-v7a.so，libtosprotection.x86.so

网易易盾：libnesec.so

APKProtect：libAPKProtect.so

几维安全：libkwscmm.so, libkwscr.so, libkwslinker.so

顶像科技：libx3g.so
```
```
def is_shell(zip_object):
    shell_result=""
    so_arr=[]
    for s in zip_object.namelist():
        if s.endswith('.so'):
          s=str(s).rsplit('/')[-1]
          so_arr.append(s)

    if 'libexec.so' in so_arr and 'libexecmain.so' in so_arr:
        shell_result="爱加密"

    elif 'libsecexe.so' in so_arr and 'libsecmain.so' in so_arr:
        shell_result = "梆梆普通加固"

    elif 'libDexHelper-x86.so' in so_arr and 'libDexHelper.so' in so_arr:
        shell_result="梆梆企业加固"

    elif ('libprotectClass.so' in so_arr or 'libprotectClass_x86.so' in so_arr) or ('libjiagu.so' in so_arr or 'libjiagu_art.so' in so_arr) or ('libjiagu.so' in so_arr or 'libjiagu_x86.so' in so_arr):
        shell_result="360加固"

    elif ('libddog.so' in so_arr and 'libfdog.so' in so_arr) or 'libchaosvmp.so' in so_arr  :
        shell_result = "娜迦加固"

    elif 'libbaiduprotect.so' in so_arr and 'libbaiduprotect_x86.so' in so_arr:
        shell_result = "百度加固"

    elif 'libnqshield.so' in so_arr and 'libnqshieldx86.so' in so_arr:
        shell_result = "网秦加固"

    elif 'libmobisec.so' in so_arr and 'libmobisecx.so' in so_arr:
        shell_result = "阿里加固"

    elif 'libtup.so' in so_arr or 'libexec.so' in so_arr:
        shell_result = "腾讯加固"

    elif 'libshella-2.8.so' in so_arr or 'libshellx-2.8.so' in so_arr:
        shell_result = "腾讯加固"

    elif 'libegis.so' in so_arr :
        shell_result = "通付盾加固"
```




