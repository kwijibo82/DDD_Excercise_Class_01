$blackListFolders = @("\obj\","\bin\")
$wrongNamespaces = @()

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

            $namespace = $xdoc.SelectNodes('/x:Project/x:PropertyGroup/x:RootNamespace', $ns) | Select-Object -First 1
            $assemblyName = $xdoc.SelectNodes('/x:Project/x:PropertyGroup/x:AssemblyName', $ns) | Select-Object -First 1

            if($namespace.InnerText -ne $assemblyName.InnerText)
            {
                $wrongNamespaces += new-object psobject -Property @{Assembly = $assemblyName.InnerText; Namespace = $namespace.InnerText; Folder = $proj.Directory.Name }
            }
        }
    } 
    
    if($wrongNamespaces.Length -ge 1)
    {
        $wrongNamespaces | Format-Table
        Write-Error "`nInconsistecies were found between asembly names and namespaces"
    }
    else
    {
        Write-Host "OK" -ForegroundColor Green
    }