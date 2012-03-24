:: 2012-03-23 - Aaron Backer
:: super nifty auto update and launch your selenium 2 grid node processes
::
:: assumes:
:: this file is in a c:\grid2 directory
:: the c:\grid2 directory contains::
::  ==> selenium-server-standalone.jar (we remove the version #)
::  ==> ChromeDriver.exe
::  ==> InternetExplorerDriver.exe
:: the JAVA_HOME environment var is set
:: the c:\grid2 directory is IN THE SYSTEM PATH
:: the java home\bin directory is in the path
:: 
:: the c:\grid2 directory (and contents) is a subversion directory, with cached credentials


@echo off

:: GRIDSERVER should be set to you selenium HUB and PORT
set GRIDSERVER=qa-sel01:4445


::tricksy method to jump to the actual execution of the 
::node *after* the file has been updated by svn
if "%1"=="UPDATEDONE" goto UPDATEDONE

::otherwise, fire off the update script
start update.bat

echo Waiting for svn update to complete (10 seconds should be more than enough)...

::quick and dirty method to delay for 10 seconds while the svn update completes
PING -n 3 127.0.0.1>nul

::then start *another* instance of this script - presumeably updated
%0 UPDATEDONE

::and end this one
goto END


:UPDATEDONE
echo Svn update complete.  Launching selenium2 grid node...
::just in case...be extra sure this is in the path
path=%path%;c:\grid2 

java -jar selenium-server-standalone.jar -role node  -hub http://%GRIDSERVER%/grid/register -maxSession 1 -browser "browserName=chrome" -browser "browserName=firefox,maxInstances=1" -browser "browserName=htmlunit,platform=ANY,version=firefox,maxInstances=1"
::java -jar selenium-server-standalone.jar -role node  -hub http://%GRIDSERVER%/grid/register


:END
