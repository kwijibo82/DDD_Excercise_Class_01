@echo off
echo -- Restoring Microsoft.Mdp.sln ---------------------------------------
..\Src\.nuget\NuGet.exe restore ..\Src\Microsoft.Mdp.sln
echo -- Restoring Microsoft.Mdp.RF.Integration.sln ------------------------
..\Src\.nuget\NuGet.exe restore ..\Src\Microsoft.Mdp.RF.Integration.sln
echo -- Restoring Deploy.sln ----------------------------------------------
..\Deploy\.nuget\NuGet.exe restore ..\Deploy\Deploy.sln
