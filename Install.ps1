function waitUntillInstallation {
    Write-Host "Function has been called"
    
    $installComplete = 0

while($installComplete -le 1) 
{
    Write-Host "Test"
    $msi = Get-Process msiexec -ErrorAction SilentlyContinue
    if ($msi) {
        Sleep(10)
    }
    else
    {
        $installComplete = 2
    }

}
}

#Create Software folder for download
New-Item -ItemType Directory -Force -Path C:/Software
& { (New-Object System.Net.WebClient).DownloadFile('https://www.syncfusion.com/downloads/support/directtrac/general/ze/syncfusionpfx-546827946', 'C:/Software/syncfusionpfx-546827946.zip') }

#Extract zip file
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory('C:/Software/syncfusionpfx-546827946.zip', 'C:\Software')

# Certificate installation
Import-PfxCertificate -FilePath C:\Software\syncfusion.pfx -CertStoreLocation Cert:\CurrentUser\My -Password (ConvertTo-SecureString -String "Coolcomp299" -Force -AsPlainText)

waitUntillInstallation
