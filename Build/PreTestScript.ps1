
Write-Host "BuildInfo:"
Write-Host "The build definition is $Env:TF_BUILD_BUILDDEFINITIONNAME"

$emulatorCmd = "${env:ProgramFiles(x86)}" + "\Microsoft SDKs\Azure\Storage Emulator\WAStorageEmulator.exe"
# Only needed the first time
# & $emulatorCmd "init"

$process = $null
$process = Get-Process -Name "WAStorageEmulator" -ErrorAction Ignore
if ($process -eq $null)
{
	Write-Host "Starting Storage Emulator.."
	 & $emulatorCmd start
}
else
{
	Write-Host "Storage emulator is already running"
}

Write-Host "Clearing storage emulator data..."
& $emulatorCmd clear all

# Environment variables
# TF_BUILD - True
# TF_BUILD_BINARIESDIRECTORY - C:\Builds\15117\TestScrum\Global\bin
# TF_BUILD_BUILDDEFINITIONNAME - Global
# TF_BUILD_BUILDDIRECTORY - C:\Builds\15117\TestScrum\Global
# TF_BUILD_BUILDNUMBER - Global_20140718.2
# TF_BUILD_BUILDREASON - Manual
# TF_BUILD_BUILDURI - vstfs:///Build/Build/120
# TF_BUILD_COLLECTIONURI - 
# TF_BUILD_DROPLOCATION - \\encbuild\DropBuild\Global\Global_20140718.2
# TF_BUILD_SOURCEGETVERSION - 
# TF_BUILD_SOURCESDIRECTORY - 
# TF_BUILD_TESTRESULTSDIRECTORY - 