@echo off
if "%1" == "" (
set CONFIGURATION=DEBUG
) else (
set CONFIGURATION=%1
)
:build
echo Using %CONFIGURATION% configuration...
echo Cleaning Core
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "Core\Core Module.sln" /target:clean /verbosity:quiet "/p:Configuration=%CONFIGURATION%" 
echo Cleaning Web
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "Web\Web Module.sln" /target:clean /verbosity:quiet "/p:Configuration=%CONFIGURATION%" 
echo Cleaning Client
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe "Client\Client Module.sln" /target:clean /verbosity:quiet "/p:Configuration=%CONFIGURATION%" 
goto :end
:syntax
echo Syntax: clean [CONFIGURATION]
goto :end
:end