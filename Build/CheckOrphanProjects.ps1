$projects = @()
$orphans = @()
$blackListFolders = @("\obj\","\bin\")

dir -Recurse *.sln | 
    ForEach-Object {
        Write-Host "." -NoNewline
        $sol = $_
        $exclude = $blackListFolders | Where-Object { $sol.FullName.Contains($_) }
        if($exclude -eq $null)
        {
            $rootPath = $_.Directory.FullName
            $solution = $_
            $content = Get-Content $_
            $content | Where-Object { $_.Trim().StartsWith("Project(""") -and $_.Contains(".csproj") } | 
            ForEach-Object { $proj = $_.Split('"') | Where { $_.Contains("csproj") } | Select-Object -Unique | 
            ForEach-Object {
                                $currentProject = $_.Split("\\")[-1]
                                $absolutePath = [System.IO.Path]::GetFullPath((Join-Path $rootPath $_))
                                $entry = new-object psobject -Property @{solution = $solution; project = $currentProject; path = $absolutePath; folder = [System.IO.Path]::GetDirectoryName($absolutePath) }

                                $exist = $projects | Where-Object { 
                                    $absolutePath -eq $_.path 
                                }
                                if($exist -eq $null) {
                                    $projects += $entry
                                }
                            }
            }
        } 
}

dir -Recurse *.csproj | ForEach-Object{
    Write-Host "." -NoNewline
    $prj = $_
    $exclude = $blackListFolders | Where-Object { $prj.FullName.Contains($_) }
    if($exclude -eq $null)
    {
        $absolutePath = $_.FullName
        $currentProject = $absolutePath.Split("\\")[-1]

        $exist = $projects | Where-Object { 
            $absolutePath -eq $_.path 
        }

        if($exist -eq $null) {
            $entry = new-object psobject -Property @{solution = "NONE"; project = $currentProject; path = $absolutePath; folder = [System.IO.Path]::GetDirectoryName($absolutePath) }
            $orphans += $entry
        } 
    }        
} 

if($orphans.Length -ge 1)
{
    $orphans | Sort-Object folder | Select folder | Format-Table
    Write-Error "`nThere are orphan projects which are not part of any solution"
}
else
{
    Write-Host "OK" -ForegroundColor Green
}