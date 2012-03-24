@echo off

::tricksy method to jump to the actual execution of the 
::node *after* the file has been updated by svn
if "%1"=="UPDATEDONE" goto UPDATEDONE

::otherwise, fire off the update script
start update.bat

echo Waiting for svn update to complete (10 seconds should be more than enough)...

::quick and dirty method to delay for 10 seconds while update completes
PING -n 11 127.0.0.1>nul

::then start *another* instance of this script - presumeably updated
%0 UPDATEDONE

::and end this one
goto END


:UPDATEDONE
echo Svn update complete.  Launching selenium2 grid hub
path=%path%;c:\grid2
java -jar selenium-server-standalone.jar -role hub -port 4445

:END

