@echo off
REM  need to az login before running this
REM Also need to ensure can run powershell scripts "Set-ExecutionPolicy unrestricted"
cls

SET location="westeurope"
REM Change this to we-nyctaxis-rsg
SET resourceGroup="we-cosmosdb-nyctaxis-rsg" 
REM call az\create-resources az\storage\storagedeploy %resourceGroup% -c %location%
call az\create-resources az\cosmosdb\cosmosdb %resourceGroup% -c %location%
REM call az\create-resources az\applicationinsights\applicationinsights %resourceGroup% -c %location%
REM Get Hold of the App Service Key
REM powershell.exe az\applicationinsights\GetAppInsightsKey.ps1 -appInsightsName "azuredemos-nyctaxis-apin" 
REM Current Key is 4da69620-8016-4b25-b940-3df957086c90

REM echo az group delete -n %resourceGroup% --yes 

