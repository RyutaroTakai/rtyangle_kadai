. "./ps1/set-location.ps1"
. "./ps1/variable.ps1"

Write-Output "最後に追加されたマイグレーションを削除します。よろしいですか？"
$accept = Read-Host "問題なければyを入力後、エンターキーを押してください"
if ($accept -ne "y") {
    exit
}

SetLocation
dotnet ef migrations remove -f --no-build --project:$project --startup-project:$startupProject --context:$context