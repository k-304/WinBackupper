@echo off
REM This script runs Winbackupper silently in the background.
cmd.exe /c "%~dp0WinBackupper.exe -s"

REM Alternative commands: -s /s /silent and -silent
exit