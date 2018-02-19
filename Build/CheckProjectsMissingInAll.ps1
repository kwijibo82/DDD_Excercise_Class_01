$projects = @()
$missing = @()

$blackListFolders = @("\obj\","\bin\")


if (Test-Path ".\DDD.sln")
{
    $solution = Get-Item -Path ".\DDD.sln"
    $rootPath = $solution.Directory.FullName
    $content = Get-Content $solution

    $content | Where-Object { $_.Trim().StartsWith("Project(""") -and $_.Contains(".csproj") } | 
    ForEach-Object { $proj = $_.Split('"') | Where { $_.Contains("csproj") } | Select-Object -Unique | 
    ForEach-Object {
                        $currentProject = $_.Split("\\")[-1]
                        $absolutePath = [System.IO.Path]::GetFullPath((Join-Path $rootPath $_))
                        $entry = new-object psobject -Property @{solution = $solution; project = $currentProject; path = $absolutePath }
                        $projects += $entry
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

            $exist = $projects | Where-Object { $absolutePath -eq $_.path }
            if($exist -eq $null) {
                $entry = new-object psobject -Property @{project = $currentProject; path = $absolutePath }
                $missing += $entry
            }
         
        }
    } 
    
    if($missing.Length -ge 1)
    {
        $missing | Sort-Object solution | Select project | Format-Table
        Write-Error "`nThere are projects which are not part of DDD.sln"
    }
    else
    {
        Write-Host "`OK" -ForegroundColor Green
    }
}
else
{
    Write-Error "Wrong location, launch this script from root of git repository"    
}