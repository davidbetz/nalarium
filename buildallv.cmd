@echo off
::+
echo Building Core
msbuild "Core\Core Module.sln"
::+
echo Building Web
msbuild "Web\Web Module.sln"
::+
echo Building Client
msbuild "Client\Client Module.sln"