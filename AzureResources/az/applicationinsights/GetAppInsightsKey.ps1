#
# GetAppInsightsKey.ps1
#
param([string] $appInsightsName = "NotSet")

Login-AzureRmAccount
$appInsights = Find-AzureRmResource -ResourceNameEquals $appInsightsName -ResourceType "Microsoft.Insights/components"
$details = Get-AzureRmResource -ResourceId $appInsights.ResourceId
$ikey = $details.Properties.InstrumentationKey
Write-Output $ikey