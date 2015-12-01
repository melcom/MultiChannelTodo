#
# ApiServerConfiguration.ps1
#

Configuration ApiServerConfiguration 
{
	Node $AllNodes.NodeName
	{
		#Install the IIS Role 
		WindowsFeature IIS 
		{ 
		  Ensure = “Present” 
		  Name = “Web-Server” 
		} 

		#Install ASP.NET 4.5 
		WindowsFeature ASP 
		{ 
		  Ensure = “Present” 
		  Name = “Web-Asp-Net45” 
		} 

        Package WebPi_Installation
        {
            Ensure = "Present"
            Name = "Microsoft Web Platform Installer 5.0"
            Path = Join-Path $($Node.WebPiSourcePath) wpilauncher.exe
            ProductId = '4D84C195-86F0-4B34-8FDE-4A17EB41306A'
            Arguments = ''
        }

        Package WebDeploy_Installation
        {
            Ensure = "Present"
            Name = "Microsoft Web Deploy 3.5"
            Path = $Node.WebPiCmdPath
            ProductId = ''
            Arguments = "/install /products:WDeploy /AcceptEula"
            DependsOn = @("[Package]WebPi_Installation")
        }
    } 
} 

#$DestPath = "D:\temp"
#$configPath = Join-Path $DestPath "_configurations"
 
#ApiServerConfiguration -Verbose -OutputPath $configPath\DevToolsConfiguration -ConfigurationData .\DscConfiguration.psd1
#Start-DscConfiguration -Path $configPath\DevToolsConfiguration -Wait -Verbose -Force