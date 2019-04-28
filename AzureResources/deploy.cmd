@echo off
REM  need to az login before running this
cls

SET location="westeurope"
SET resourceGroup="we-cosmosdb-nyctaxis-rsg"
REM call az\create-resources az\storage\storagedeploy %resourceGroup% -c %location%
REM call az\create-resources az\applicationinsights\applicationinsights %resourceGroup% -c %location%
REM Get Hold of the App Service Key
REM powershell.exe az\applicationinsights\GetAppInsightsKey.ps1 -appInsightsName "joogla-apin" 
REM Current Key is 92048675-10fd-415f-938b-726707fae07c

REM echo az group delete -n %resourceGroup% --yes 

