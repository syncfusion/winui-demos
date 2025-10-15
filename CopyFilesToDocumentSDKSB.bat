@echo off
echo Starting copy from SB to DocumentSDK_SB...

:: Create the destination directory if it doesn't exist
if not exist "DocumentSDK_SB" mkdir "DocumentSDK_SB"

:: Copy all files from SB to DocumentSDK_SB
echo Copying files from SB to DocumentSDK_SB...
xcopy "SB\*" "DocumentSDK_SB\" /E /I /Y

:: Delete specific project and solution files from DocumentSDK_SB
echo Deleting project and solution files from DocumentSDK_SB...
if exist "DocumentSDK_SB\SampleBrowser.WinUI_Net80.csproj" del "DocumentSDK_SB\SampleBrowser.WinUI_Net80.csproj"
if exist "DocumentSDK_SB\SampleBrowser.WinUI_Net80.sln" del "DocumentSDK_SB\SampleBrowser.WinUI_Net80.sln"
if exist "DocumentSDK_SB\SampleBrowser.WinUI_Net90.csproj" del "DocumentSDK_SB\SampleBrowser.WinUI_Net90.csproj"
if exist "DocumentSDK_SB\SampleBrowser.WinUI_Net90.sln" del "DocumentSDK_SB\SampleBrowser.WinUI_Net90.sln"
if exist "DocumentSDK_SB\SampleBrowser.WinUI.csproj" del "DocumentSDK_SB\SampleBrowser.WinUI.csproj"
if exist "DocumentSDK_SB\SampleBrowser.WinUI.sln" del "DocumentSDK_SB\SampleBrowser.WinUI.sln"
if exist "DocumentSDK_SB\syncfusion.samplebrowser.props" del "DocumentSDK_SB\syncfusion.samplebrowser.props"
if exist "DocumentSDK_SB\syncfusion.samplebrowser.winui_TemporaryKey.pfx" del "DocumentSDK_SB\syncfusion.samplebrowser.winui_TemporaryKey.pfx"

echo Process completed successfully!