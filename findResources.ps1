Login-AzureRmAccount
$subscriptions = Get-AzureRmSubscription
foreach ($sub in $subscriptions) {
  Set-AzureRmContext -SubscriptionId $sub.SubscriptionId -TenantId $sub.TenantId
  $resources = Get-AzureRmResource
  foreach ($resource in $resources) {
     If ($resource.ResourceType -eq "Microsoft.Storage/storageAccounts") {
         $y = Invoke-AzureRmResourceAction -Action listKeys -ResourceType "Microsoft.Storage/storageAccounts" `
         -ResourceGroupName $resource.ResourceGroupName -Name $resource.ResourceName
         echo $y
     }
  }
}
