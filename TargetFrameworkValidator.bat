@echo off

setlocal
REM check if .NET10 SDK is in list
dotnet --list-sdks | findstr "^10\.[0-9]"
if errorlevel 1 (
	echo .NET SDK is not installed.
	
	REM Modify MultiTargeting target file if SDK is missing
	if exist "targets\MultiTargeting.targets" (
		echo MultiTargeting.targets file exists.
		
		REM Search for target line
		findstr /C:"&nbsp; &nbsp; &lt;TargetFrameworks&gt;net8.0-windows10.0.19041.0;net9.0-windows10.0.19041.0;net10.0-windows10.0.19041.0;&lt;/TargetFrameworks&gt;" "targets\MultiTargeting.targets" >nul
		if errorlevel 1 (
			echo TargetFrameworks line found.
			powershell -Command "(Get-Content '"targets\MultiTargeting.targets"') -replace '<TargetFrameworks>net8.0-windows10.0.19041.0;net9.0-windows10.0.19041.0;net10.0-windows10.0.19041.0;</TargetFrameworks>', '<TargetFrameworks>net8.0-windows10.0.19041.0;net9.0-windows10.0.19041.0;</TargetFrameworks>' | Set-Content 'targets\MultiTargeting.targets'"
		) else (
			echo TargetFrameworks line not found.
		)	
	) else (
		echo MultiTargeting.targets file does not exists.
	)
) else (
	echo .NET SDK is installed.
)

:end
endlocal
