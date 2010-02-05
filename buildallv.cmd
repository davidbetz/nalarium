@echo off
::+
echo Building Core
%windir%\Microsoft.NET\Framework\v3.5\msbuild "Core\Core Module.sln"
::+
echo Building Web
%windir%\Microsoft.NET\Framework\v3.5\msbuild "Web\Web Module.sln"
::+
echo Building Client
%windir%\Microsoft.NET\Framework\v3.5\msbuild "Client\Client Module.sln"