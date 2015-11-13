#
# UpdateParameters.ps1
#

$wd = $Env:System.DefaultWorkingDirectory

$parameters = Get-ChildItem $wd -Recurse -Filter "*SetParameters.xml"

foreach($p in $parameters) {
	
	Write-Host Updating $p.FullName
	
	$xml = New-Object XML
	$xml.Load($p.FullName)

	foreach($node in $xml.parameters.setParameter)
    {        
        $varname = $node.name
        $value = [Environment]::GetEnvironmentVariable($varname)
        if($value)
        {            
            Write-Output ("Setting {0} with value {1}" -f $varname, $value)
            $node.SetAttribute('value', $value)
        }
        else
        {
            Write-Output ("No {0} variable found" -f $varname)
        }
    }

    $xml.Save($p.FullName)
}