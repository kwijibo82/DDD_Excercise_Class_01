param 
(
    [Parameter(Mandatory=$false)][string]$keyToCheck = "StorageConfigurationConnectionString",
    [Parameter(Mandatory=$false)][string]$expectedValue = "UseDevelopmentStorage=true" 
)

$wrong = @()
$blackListFolders = @("\obj\","\bin\")

$files = Get-Childitem -Recurse -Include web.config,app.config

$files |
	ForEach-Object {
        Write-Host "." -NoNewline
        $proj = $_
        $exclude = $blackListFolders | Where-Object { $proj.FullName.Contains($_) }
        if($exclude -eq $null)
        {
            [xml]$xdoc = Get-Content $_.FullName
            $node = $xdoc.SelectSingleNode('/configuration/appSettings/add[@key = "' + $keyToCheck + '"]')
            
            if($node -ne $null -and $node.value -ne $expectedValue)
            {
                $wrong += new-object psobject -Property @{ Project = $_; Value = $node.value }
            }
        }
    }

if($wrong.Length -gt 0)
{
    $wrong | Select Project, Value | Format-Table
    Write-Error "`nSome projects not has the expected values"
}else
{
    Write-Host "OK" -ForegroundColor Green
}
