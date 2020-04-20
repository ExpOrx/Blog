#!/bin/bash
echo Usage: run ./icon_gen.sh theme_name image_name

echo Create dir $1
#mkdir -p $1/drawable-mdpi/
mkdir -p $1/drawable-xhdpi/
#mkdir -p $1/drawable-xxhdpi/

#convert -resize 48x48 $2 $1/drawable-mdpi/ic_launcher181.png 
convert -resize 72x72 "$2" $1/drawable-xhdpi/ic_launcher181.png 
#convert -resize 150x150 $2 $1/drawable-xxhdpi/ic_launcher181.png 
rm "$2"
echo Done
