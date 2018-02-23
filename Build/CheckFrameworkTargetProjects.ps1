param 
(
    [Parameter(Mandatory=$true)][string]$FrameworkVersion = "v4.6.1" 
)

$wrong = @()
$blackListFolders = @("\obj\","\bin\")

dir -Recurse *.csproj |
	ForEach-Object {
        Write-Host "." -NoNewline
        $proj = $_
        $exclude = $blackListFolders | Where-Object { $proj.FullName.Contains($_) }
        if($exclude -eq $null)
        {
            [xml]$xdoc = Get-Content $_.FullName
            $ns = new-object Xml.XmlNamespaceManager $xdoc.NameTable
            $ns.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003")

            $xdoc.SelectNodes('/x:Project/x:PropertyGroup/x:TargetFrameworkVersion', $ns) | ForEach-Object {

                if($_.InnerText -ne $FrameworkVersion)
                {
                    $package = $_
                    $exist = $wrong | Where-Object { $package.Value -eq $_."Framework Referenced" -and  $proj.Directory.Name -eq $_."Directory Project" }
                    if($exist -eq $null)
                    {
                        $wrong += new-object psobject -Property @{ Project = $proj.Name; Framework = $_.InnerText }
                    }
                }
            }
        }
    }

if($wrong.Length -gt 0)
{
    $wrong | Select Project, Framework | Format-Table
    Write-Error "`nSome projects not has the desired version"
}else
{
    Write-Host "OK" -ForegroundColor Green
}
