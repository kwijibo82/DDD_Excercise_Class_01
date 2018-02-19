$blackListFolders = @("\obj\","\bin\")

$errors =  dir -Recurse *.csproj | ForEach-Object{
        Write-Host "." -NoNewline
        $prj = $_
        $exclude = $blackListFolders | Where-Object { $prj.FullName.Contains($_) }
        if($exclude -eq $null)
        {
            $absolutePath = $_.FullName
            $PathSegments = $absolutePath.Split("\\")
            $currentProject = $PathSegments[-1]
            $lastPath = $PathSegments[-2]
            $projectName = $currentProject.Substring(0, $currentProject.Length -7)
            if($lastPath.Trim() -ne $projectName.Trim()) { 
                return new-object psobject -Property @{project = $projectName; path = $absolutePath }
            }
        }
    } 


if($errors.Length -ge 1)
{
    $errors | Format-Table
    Write-Error "`nInconsistecies were found between project names and folders"
}
else
{
    Write-Host "OK" -ForegroundColor Green
}