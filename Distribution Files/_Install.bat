REM Description:	Installs Winbackupper (IT creates Shortcuts - Winbackupper is basically portable)
REM Version:		0.0.0.2
REM Supported OS:	XP and higher.
REM Prerequisites:	NET 4.5

@echo off
@break off
@title Install Winbackupper
@cls

@echo "Start determening OS Version..."
rem this version would be XP - supported down to XP
ver | findstr /i "5\.1\.">nul
if %ErrorLevel% EQU 0 goto 7down
ver | findstr /i "5\.2\.">nul
if %ErrorLevel% EQU 0 goto 7down
ver | findstr /i "6\.0\.">nul
if %ErrorLevel% EQU 0 goto 7down
ver | findstr /i "6\.1\.">nul
if %ErrorLevel% EQU 0 goto 7down
ver | findstr /i "6\.2\.">nul
if %ErrorLevel% EQU 0 goto 7up
ver | findstr /i "6\.3\.">nul
if %ErrorLevel% EQU 0 goto 7up

REM if not one of the two - throw error and exit
goto error

:7down

@echo Start install for Win7 and earlier

::Create temporary VB Script for creation of the Desktop Shortcut.
set SCRIPTD="%TEMP%\winbackupperDesktopinstall.vbs"
echo Set oWS = WScript.CreateObject("WScript.Shell") >> %SCRIPTD%
echo sLinkFile = "%USERPROFILE%\Desktop\Winbackupper.lnk" >> %SCRIPTD%
echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %SCRIPTD%
echo oLink.TargetPath = "%~dp0winbackupper.exe" >> %SCRIPTD%
echo oLink.Save >> %SCRIPTD%
cscript /nologo %SCRIPTD%
del %SCRIPTD%

::Create needed Folders for Startmenu Shortcuts

rmdir "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Winbackupper" /S /Q
mkdir "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Winbackupper"
::Create temporary VB Script for creation of the Startmenu Shortcuts.
set SCRIPTS="%TEMP%\winbackupperStartmenuinstall.vbs"
echo Set oWS = WScript.CreateObject("WScript.Shell") >> %SCRIPTS%
echo sLinkFile = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Winbackupper\Winbackupper.lnk" >> %SCRIPTS%
echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %SCRIPTS%
echo oLink.TargetPath = "%~dp0winbackupper.exe" >> %SCRIPTS%
echo oLink.Save >> %SCRIPTS%
cscript /nologo %SCRIPTS%
del %SCRIPTS%

goto finish

:7up
@echo Start isntall for Win8 and later
Start /wait "Installing Win8 Tiles for Winbackupper" OblyTile.exe "Winbackupper" "%~dp0winbackupper.exe" "" "%~dp0\icons\backupper\128x128.png" "%~dp0\icons\backupper\64x64.png" #000000 #FFFFFF show admin no no no
Start /wait "Installing Win8 Tiles for Winbackupper-update" OblyTile.exe "Winbackupper-Updater" "%~dp0THC_Updater.exe" "" "%~dp0\icons\updater\128x128_tile.png" "%~dp0\icons\updater\64x64_tile.png" #000000 #FFFFFF show admin no no no
goto finish

:finish
@Echo finished succesfully
::write into registry that SW is installed
reg add HKCU\software\winBackupper /v Installed /t REG_SZ /D 1
::Check if a parameter was specified, if so suppose it was a "Silent" paramater and close immediatly.
::The If asks if there is no argumen, if so do a pause to inform user it s finished.
if %1!==! pause   
exit

:error
@Echo There was some Error! Probably the OS is not supported (earlier than XP?)
pause
exit