#
# UpdateParameters.ps1
#

Write-Host (Get-Variable | Out-String)

$parameters = Get-ChildItem $Env:Release.EnvironmentUri -Recurse -Filter "SetParameters.xml"

Foreach($p in $parameters) {
	
	Write-Host "Updating $p.FullName"
	
	#$xml = New-Object XML
	#$xml.Load($manifest.FullName)
	#$version = "{0}.{1}.{2}.{3}" -f $major, $minor, $revision, $build
	#Write-Output "Updating to version $version"
	#$xml.Package.Identity.Version = $version
	#$xml.Save($manifest.FullName)
}