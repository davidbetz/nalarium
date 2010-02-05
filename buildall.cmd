@echo off
::+
echo Building Core
msbuild /nologo /noconlog "Core\Core Module.sln"
::+
echo Building Web
msbuild /nologo /noconlog "Web\Web Module.sln"
::+
echo Building Client
msbuild /nologo /noconlog "Client\Client Module.sln"