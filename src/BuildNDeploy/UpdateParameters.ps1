#
# UpdateParameters.ps1
#

$wd = $Env:System.DefaultWorkingDirectory

$parameters = Get-ChildItem $wd -Recurse -Filter "*SetParameters.xml"

Foreach($p in $parameters) {
	
	Write-Host Updating $p.FullName
	
	$xml = New-Object XML
	$xml.Load($p.FullName)

	foreach($node in $xml.parameters.setParameter)
    {        
        $value = Get-Variable $node.name -ValueOnly -ErrorAction SilentlyContinue
        if($value)
        {
            Write-Output ("Setting {0} with value {1}" -f $node.name, $value)
            $node.SetAttribute('value', $value)
        }
        else
        {
            Write-Output ("No {0} variable found" -f $node.name)
        }
    }
    $xml.Save($p.FullName)
}