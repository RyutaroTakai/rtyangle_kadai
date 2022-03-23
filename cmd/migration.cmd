echo off
cd %~dp0
powershell -ExecutionPolicy RemoteSigned -File "./ps1/migration.ps1"

pause
