@echo off
::+
echo Building Core
%windir%\Microsoft.NET\Framework\v3.5\msbuild /nologo /noconlog "Core\Core Module.sln"
::+
echo Building Web
%windir%\Microsoft.NET\Framework\v3.5\msbuild /nologo /noconlog "Web\Web Module.sln"
::+
echo Building Client
%windir%\Microsoft.NET\Framework\v3.5\msbuild /nologo /noconlog "Client\Client Module.sln"