#!/bin/bash

echo Git reset in $1
cd $1/app/src/main/
git checkout HEAD .
git clean -fd
