$errors = @()

Get-ChildItem -Recurse AssemblyInfo.cs | ForEach-Object{
        $file = $_
        Write-Host "." -NoNewline
        Get-Content -Path $_.FullName | ForEach-Object {


            $found = $_ -match "^\s*\[\s*assembly\s*:\s*(AssemblyVersion|AssemblyFileVersion)\s*\(\s*""([^(\s""]*)"

            if($found)
            {
                if($Matches[2] -ne "1.0.0.0")
                {
                    $errors += new-object psobject -Property @{
                        File = $file.Directory.Parent.FullName; 
                        Atributte = $Matches[1];
                        Version =  $Matches[2]
                    }
                }
            }
        }
    } 

if($errors.Length -ge 1)
{
    $errors | Format-Table
    Write-Error "Wrong AssemblyInfo Versions found"
}
else
{
    Write-Host "OK" -ForegroundColor Green
}