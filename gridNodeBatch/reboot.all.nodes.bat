
for /F %%s in (allnodes.txt) DO shutdown /m \\%%s /r /f /t 0

goto END




:END
ping -t merw7qa610