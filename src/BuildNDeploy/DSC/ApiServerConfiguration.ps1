#
# ApiServerConfiguration.ps1
#

$configData = @{
    AllNodes = @( 
        @{
            NodeName = 'localhost'
            WebPiSourcePath = "D:\dsc\dev\WebPi"
            WebPiCmdPath = "$env:ProgramFiles\Microsoft\Web Platform Installer\WebPiCmd-x64.exe"
        }
    );
}

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
		
		#Install IIS Console
		WindowsFeature IISConsole 
		{ 
		  Ensure = “Present” 
		  Name = “Web-Mgmt-Tools” 
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

ApiServerConfiguration -Verbose -OutputPath D:\dsc\dev -ConfigurationData $configData 
Start-DscConfiguration -Path D:\dsc\dev -Wait -Verbose -Force