# Run script on VM
# check these commands:
$PublicSettings = '{"commandToExecute":"powershell Add-WindowsFeature Web-Server"}'

Set-AzureRmVMExtension -ExtensionName "IIS" -ResourceGroupName $resourceGroup -VMName $vmName `
  -Publisher "Microsoft.Compute" -ExtensionType "CustomScriptExtension" -TypeHandlerVersion 1.4 `
  -SettingString $PublicSettings -Location $location

  # create vm object
$vm = Get-AzureVM -Name 2016clas -ServiceName 2016clas1313

# set extension
Set-AzureRmVMCustomScriptExtension -ResourceGroupName "ResourceGroup11" `
-Location "Central US" -VMName "VirtualMachine07" `
-Name "ContosoTest" -TypeHandlerVersion "1.1" -StorageAccountName "Contoso" `
-StorageAccountKey <StorageKey> -FileName "ContosoScript.exe" -ContainerName "Scripts"

# update vm
$vm | Update-AzureVM