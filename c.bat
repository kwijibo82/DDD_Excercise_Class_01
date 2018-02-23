@echo off

if "%1"=="?" goto help
echo Tip: For help run "%0 ?"
goto start

:help
echo This script verifies that all the projects under Src have the right framework version,
echo nuget packages and .config settings. An error will be printed on screen if any verification  fail.
echo.
echo Usage:
echo    %0
echo.
goto end

:start

cd Src

echo * Checking all projects are using framework 4.6.1
powershell ..\Build\CheckFrameworkTargetProjects.ps1 -FrameworkVersion "v4.6.1"
echo.

echo * Checking all projects have nuget references using 4.6.1
powershell ..\Build\CheckFrameworkTargetPackages.ps1 -FrameworkVersion "net461"
echo.

echo * Checking assembly name - namespace consistencies
powershell ..\Build\CheckWrongNamespaces.ps1
echo.

echo * Checking projects names which does not match folders name
powershell ..\Build\CheckWrongNamedFolders.ps1
echo.

echo * Projects folders which are not part of any solution
powershell ..\Build\CheckOrphanProjects.ps1
echo.

echo * Projects that should be referenced in DDD and are not...
powershell ..\Build\CheckProjectsMissingInAll.ps1
echo.

echo * Connection strings targeting local emulator...
powershell ..\Build\CheckConfigSettings.ps1 -keyToCheck "StorageConfigurationConnectionString" -expectedValue "UseDevelopmentStorage=true"
echo.

echo * Deployment id set to we...
powershell ..\Build\CheckConfigSettings.ps1 -keyToCheck "DeploymentId" -expectedValue "we"
echo.

echo * Checking AssemblyInfo.cs files  for correct AssemblyVersion and AssemblyFileVersion 
powershell ..\Build\CheckWrongAssemblyInfoVersion.ps1
echo.

cd..

:end