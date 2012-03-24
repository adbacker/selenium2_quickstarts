@echo off
echo Updating grid2 scripts from svn...
set path=%path%;"C:\Program Files\TortoiseSVN\bin"
c:
cd \grid2
echo starting %date% @ %time% ...>>svnlog.txt
svn up >> svnlog.txt
echo done %date% @ %time% ...>>svnlog.txt
echo grid2 script update complete.  check svnlog.txt in this 
echo directory if something wonky happened..
exit