. "./ps1/set-location.ps1"
. "./ps1/variable.ps1"

$migrationName = Read-Host "作成するマイグレーション名を設定してください"
if ([string]::IsNullOrWhiteSpace($migrationName)) {
    exit
}

SetLocation
dotnet ef migrations add --no-build --project:$project --startup-project:$startupProject --context:$context $migrationName
