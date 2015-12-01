#
# DscConfiguration.psd1
#

@{
    AllNodes = @( 
        @{
            NodeName = 'localhost'
            WebPiSourcePath = "D:\dsc\WebPi"
            WebPiCmdPath = "$env:ProgramFiles\Microsoft\Web Platform Installer\WebPiCmd-x64.exe"
        }
    );
}