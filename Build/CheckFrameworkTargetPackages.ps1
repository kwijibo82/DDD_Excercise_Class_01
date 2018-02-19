param 
(
    [Parameter(Mandatory=$true)][string]$FrameworkVersion = "net46" 
)

$wrong = @()
$blackListFolders = @("\obj\","\bin\")

dir -Recurse packages.config |
	ForEach-Object {
        Write-Host "." -NoNewline
        $proj = $_
        $exclude = $blackListFolders | Where-Object { $proj.FullName.Contains($_) }
        if($exclude -eq $null)
        {
            [xml]$xdoc = Get-Content $proj
            $xdoc.SelectNodes('/packages/package/@targetFramework') | ForEach-Object { 
                if($_.Value -ne $FrameworkVersion)
                {
                    $package = $_
                    $exist = $wrong | Where-Object { $package.Value -eq $_."Framework Referenced" -and  $proj.Directory.Name -eq $_."Directory Project" }
                    if($exist -eq $null)
                    {
                        $wrong += new-object psobject -Property @{"Directory Project" = $proj.Directory.Name; "Framework Referenced" = $_.Value }
                    }
                }
            }
        }
    }

if($wrong.Length -gt 0)
{
    $wrong | Select "Directory Project", "Framework Referenced" | Format-Table
    Write-Error "`nSome packages not has the desired version"
}else
{
    Write-Host "OK" -ForegroundColor Green
}
