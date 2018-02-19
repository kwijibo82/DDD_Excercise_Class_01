@echo off

if "%1"=="?" goto help
echo Tip: For help run "%0 ?"
goto start

:help
echo This script execute build DDD solution by running msbuild.
echo If any error is found, the log will be automatically open after the build is finished.
echo.
echo Usage:
echo    %0 [generateZips]
echo Where:
echo    generateZips: [empty] or true or false      (by default false)
echo Examples:
echo    %0              Start a local build without generating zips
echo    %0 false        Start a local build without generating zips
echo    %0 true         Start a local build generating zips
echo.
goto end

:start

cd build

set generateZips=false
if %1""==true"" set generateZips=true
if %1""=="true""" set generateZips=true
if %1""==1"" set generateZips=true
if %1""=="1""" set generateZips=true

echo Building... please wait (%time%)
msbuild LocalBuild.proj /nowarn:612 /v:n /p:ConditionDeployOnBuild=%generateZips% > localbuild.log
rem Add msbuild "/v:n" for detailed output

set buildResult=OK
findstr /b /l /i /x /c:"    0 Warning(s)" localbuild.log
if %errorlevel% EQU 0 goto checkErrors
findstr /b /l /i /x /c:"    0 Advertencia(s)" localbuild.log
if %errorlevel% EQU 0 goto checkErrors
set buildResult=ERROR

:checkErrors
findstr /b /l /i /x /c:"    0 Error(s)" localbuild.log
if %errorlevel% EQU 0 goto checkEnd
findstr /b /l /i /x /c:"    0 Errores" localbuild.log
if %errorlevel% EQU 0 goto checkEnd
set buildResult=ERROR

:checkEnd
if %buildResult%==ERROR goto buildResultError

:buildResultSuccess
echo Build completed successfully  (%time%)
goto buildResultEnd

:buildResultError
echo Build completed with errors and/or warnings  (%time%)
start localbuild.log
goto buildResultEnd

:buildResultEnd
echo.
cd..

:end