#!/bin/bash
sqlcmd -S 192.168.108.128 -U SA -P 'p@55word' -i $1 -o "$1_out.txt"
cat "$1_out.txt"
rm "$1_out.txt"
