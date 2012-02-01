@echo off
if "%1" == "" (
set CONFIGURATION=DEBUG
) else (
set CONFIGURATION=%1
)
:build
echo Using %CONFIGURATION% configuration...
echo Building Core
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "Core\Core Module.sln" /verbosity:quiet "/p:Configuration=%CONFIGURATION%" 
echo Building Web
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "Web\Web Module.sln" /verbosity:quiet "/p:Configuration=%CONFIGURATION%" 
echo Building Client
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "Client\Client Module.sln" /verbosity:quiet "/p:Configuration=%CONFIGURATION%" 
goto :end
:syntax
echo Syntax: build [CONFIGURATION]
goto :end
:end
echo Output binaries have been copied to %homedrive%\_REFERENCE\%CONFIGURATION%