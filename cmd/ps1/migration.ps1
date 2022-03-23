. "./ps1/variable.ps1"

$ErrorActionPreference = "Stop"
dotnet build $solutionFolder
dotnet tool update -g dotnet-ef

$typeName = "System.Management.Automation.Host.ChoiceDescription"
$addMigration = New-Object $typeName("マイグレーションの追加(&1)", "マイグレーション名を指定して、新規マイグレーションを追加します")
$removeMigration = New-Object $typeName("マイグレーションの削除(&2)", "直前に追加したマイグレーションを削除します")
$updateMigration = New-Object $typeName("DBの定義を最新に更新(&3)", "DBの定義を最新の状態に更新します")

$options = New-Object "System.Collections.ObjectModel.Collection``1[[$typeName]]"
$options.add($addMigration)
$options.add($removeMigration)
$options.add($updateMigration)

$result = $host.ui.PromptForChoice("操作", "実行する操作を選択してください", $options, 0)

switch ($result) {
    0 { powershell "../cmd/ps1/add-migration.ps1"; break }
    1 { powershell "../cmd/ps1/remove-migration.ps1"; break }
    2 { powershell "../cmd/ps1/update-database.ps1"; break }
}
