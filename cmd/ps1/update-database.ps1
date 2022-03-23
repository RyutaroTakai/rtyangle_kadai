. "./ps1/set-location.ps1"
. "./ps1/variable.ps1"

$connectionString = Read-Host "XV‘ÎÛDB‚ÌÚ‘±•¶š—ñ‚ğ“ü—Í‚µ‚Ä‚­‚¾‚³‚¢"
if([string]::IsNullOrWhiteSpace($connectionString)) {
    exit
}

SetLocation
dotnet ef database update --no-build --verbose --project:$project --startup-project:$startupProject --context:$context --connection:$connectionString
