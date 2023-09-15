#
# This script handles common telemetry tasks for Install.ps1 and Add-AppDevPackage.ps1.
#

function IsVsTelemetryRegOptOutSet()
{
    $VsTelemetryRegOptOutKeys = @(
        "HKLM:\SOFTWARE\Policies\Microsoft\VisualStudio\SQM",
        "HKLM:\SOFTWARE\Wow6432Node\Microsoft\VSCommon\16.0\SQM",
        "HKLM:\SOFTWARE\Microsoft\VSCommon\16.0\SQM"
    )

    foreach ($optOutKey in $VsTelemetryRegOptOutKeys)
    {
        if (Test-Path $optOutKey)
        {
            # If any of these keys have the DWORD value OptIn set to 0 that means that the user
            # has explicitly opted out of logging telemetry from Visual Studio.
            $val = (Get-ItemProperty $optOutKey)."OptIn"
            if ($val -eq 0)
            {
                return $true
            }
        }
    }

    return $false
}

try
{
    $TelemetryOptedOut = IsVsTelemetryRegOptOutSet
    if (!$TelemetryOptedOut)
    {
        $TelemetryAssembliesFolder = $args[0]
        $EventName = $args[1]
        $ReturnCode = $args[2]
        $ProcessorArchitecture = $args[3]

        foreach ($file in Get-ChildItem $TelemetryAssembliesFolder -Filter "*.dll")
        {
            [Reflection.Assembly]::LoadFile((Join-Path $TelemetryAssembliesFolder $file)) | Out-Null
        }

        [Microsoft.VisualStudio.Telemetry.TelemetryService]::DefaultSession.IsOptedIn = $True
        [Microsoft.VisualStudio.Telemetry.TelemetryService]::DefaultSession.Start()

        $TelEvent = New-Object "Microsoft.VisualStudio.Telemetry.TelemetryEvent" -ArgumentList $EventName
        if ($null -ne $ReturnCode)
        {
            $TelEvent.Properties["VS.DesignTools.SideLoadingScript.ReturnCode"] = $ReturnCode
        }

        if ($null -ne $ProcessorArchitecture)
        {
            $TelEvent.Properties["VS.DesignTools.SideLoadingScript.ProcessorArchitecture"] = $ProcessorArchitecture
        }

        [Microsoft.VisualStudio.Telemetry.TelemetryService]::DefaultSession.PostEvent($TelEvent)
        [Microsoft.VisualStudio.Telemetry.TelemetryService]::DefaultSession.Dispose()
    }
}
catch
{
    # Ignore telemetry errors
}