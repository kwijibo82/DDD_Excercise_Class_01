$ver = $host | select version
if ($ver.Version.Major -gt 1)  {$Host.Runspace.ThreadOptions = "ReuseThread"}
$ErrorActionPreference = "Stop"
$PSScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition
if ($PSScriptRoot -eq "") {$PSScriptRoot = "."}

#.NET Assembly Files Unlock
$assemblyPath = [System.String]::Concat($PSScriptRoot, "\*.dll")
$localAssemblies = Get-Item $assemblyPath
$localAssemblies | Unblock-File

foreach($assemblyFile in $localAssemblies)
{
    try
    {
        [System.Reflection.Assembly]::LoadFile($assemblyFile);
    }
    catch
    {
        Write-Debug $_.Exception.Message
    }
}

#Set app key valut configuration settings
  
[Microsoft.Mdp.Core.Configuration.KeyVault.AzureKeyVaultConfiguration]::BaseURLKeyVault = "https://fd-dev-gl-kv-main.vault.azure.net"
[Microsoft.Mdp.Core.Configuration.KeyVault.AzureKeyVaultConfiguration]::HSMClientId = "1950a258-227b-4e31-a9cf-717495945fc2"
[Microsoft.Mdp.Core.Configuration.KeyVault.AzureKeyVaultConfiguration]::RSASecretIdentifier = "https://fd-dev-gl-kv-main.vault.azure.net/keys/FDCPHSMKey/ae8ff288739040a88b4abfd4b96e4c3f"

#Path of .pfx
$pfxFilePath = 'C:\Temp\test.mdpfifa.com.pfx'

#Load .pfx in memory for encrypt x509Certificate
$flag = [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable
$collection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection

#Certificate password input
$password = Read-Host -Prompt "Introduce the Certificate Password" -AsSecureString
$passwordVariantBSTR = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($password)
$UnsecurePassword = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($passwordVariantBSTR)
$collection.Import($pfxFilePath, $UnsecurePassword, $flag)
$certificate = $collection[0]

#Set authorization for user and password
[Microsoft.Mdp.Azure.Security.KeyVaultManager]::AuthenticationOptions = [Microsoft.Mdp.Azure.Security.KeyVaultManagerAuthenticationOption]::UserNameAndPassword

<# 
Launch the process for create secret in key vault with certificate
Should be create 2 secrets, one for the encrypted certificate and other with encrypted private password of the certificate
#>

$keVaultManager = New-Object Microsoft.Mdp.Azure.Security.KeyVaultManager
$secretName = Read-Host -Prompt "Introduce the Secret Name" 
$keVaultManager.LoadCertificate($certificate , $secretName, $password)