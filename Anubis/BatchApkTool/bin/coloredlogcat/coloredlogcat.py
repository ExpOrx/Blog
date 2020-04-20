#!/usr/bin/python

'''
    Copyright 2009, The Android Open Source Project

    Licensed under the Apache License, Version 2.0 (the "License"); 
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at 

        http://www.apache.org/licenses/LICENSE-2.0 

    Unless required by applicable law or agreed to in writing, software 
    distributed under the License is distributed on an "AS IS" BASIS, 
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
    See the License for the specific language governing permissions and 
    limitations under the License.
'''

# Thanks to Jeff Sharkey for main idea, and Adrian Vintu for Windows version
# Rewritten by BurSoft for Python 3 and max speed
# Uses André Burgaud's color_console.py

# set PYTHONIOENCODING=utf-8 before launch script

import os, sys, re
import color_console as cons
# import time

# start = time.time()

tag_width = 22
message_width = os.get_terminal_size()[0] - tag_width - 6 - 1

retag = re.compile("^.*?([VDIWEFS])\/(.+?) *?\( *?([0-9]+)\): (.+)$")

adb_args = ' '.join(sys.argv[1:])

if sys.stdin.isatty():
  input = os.popen("adb logcat -v time %s" % adb_args)
else:
  input = sys.stdin

default_colors = cons.get_text_attr()

while 1:
  try:
    line = input.readline()
  except UnicodeError:
    continue
  except KeyboardInterrupt:
    break
  if not line:
    break

  match = retag.match(line.expandtabs())

  if match:
    tagtype, tag, owner, message = match.groups()

    print(" " + tag.rjust(tag_width)[-tag_width:], end=' ', flush=True)

    if tagtype == "V":
      cons.set_text_attr(cons.FOREGROUND_BLACK | cons.BACKGROUND_GREY)
    elif tagtype == "D":
      cons.set_text_attr(cons.FOREGROUND_BLACK | cons.BACKGROUND_BLUE | cons.BACKGROUND_INTENSITY)
    elif tagtype == "I":
      cons.set_text_attr(cons.FOREGROUND_BLACK | cons.BACKGROUND_GREEN)
    elif tagtype == "W":
      cons.set_text_attr(cons.FOREGROUND_BLACK | cons.BACKGROUND_YELLOW)
    else:
      cons.set_text_attr(cons.FOREGROUND_BLACK | cons.BACKGROUND_RED)

    print(" " + tagtype, end=' ', flush=True)
    cons.set_text_attr(default_colors)

    for i in range(0,len(message),message_width):
      if i == 0:
        print (" " + message[i:i + message_width])
      else:
        print (" " * (tag_width + 6) + message[i:i + message_width])

  else:
    continue

cons.set_text_attr(default_colors)

# end = time.time()
# print(end - start)