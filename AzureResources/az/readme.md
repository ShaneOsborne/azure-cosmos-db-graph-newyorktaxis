##Install Powershell Tools
## Install-Module -Name Az -AllowClobber (https://docs.microsoft.com/en-us/powershell/azure/install-az-ps?view=azps-1.8.0)
## https://github.com/PowerShell/PowerShell/releases/tag/v6.2.0
## https://github.com/PowerShell/PowerShell/releases/download/v6.2.0/PowerShell-6.2.0-win-x64.msi
## Connect-AzAccount


# Deploying resources using create-resources script

The `create-resources.cmd ` script is a basic script to allow easy deployment of one ARM template in one resource group. You can deploy to an existing resource group or to create one.

**NOTE**: Alternatively, you can also use the `createresources.sh` bash script which can be used as a second option, convenient if you are using the Azure Cloud Bash Shell, a Mac or Linux machine, or simply, bash on Windows, instead of CMD/CommandPrompt in a local Windows

## Deploying to a existing resource group - Windows CMD

Just type `create-resources [pathfile-to-arm-template] resourcegroup` from command-prompt. Called this way the script will:

1. Search for `path-to-arm-template.json` and `path-to-arm-template.parameters.json` files
2. If they exist, will deploy them in the `resourcegroup` specified (that resource group in Azure has to exist).

## Deploying to a new resource group - Windows CMD

Just type `create-resources [pathfile-to-arm-template] resourcegroup -c location`. Called this way the script will:

1. Search for `path-to-arm-template.json` and `path-to-arm-template.parameters.json` files
2. If they exist, will create the `resourcegroup` specified in the `location` specified.
3. Finally will deploy `path-to-arm-template.json` and `path-to-arm-template.parameters.json` files in the `resourcegroup`



## Deploying to a existing resource group - Bash shell

Just type `createresources.sh [pathfile-to-arm-template] resourcegroup` from command-prompt. Called this way the script will:

1. Search for `path-to-arm-template.json` and `path-to-arm-template.parameters.json` files
2. If they exist, will deploy them in the `resourcegroup` specified (that resource group in Azure has to exist).

## Deploying to a new resource group - Bash shell

Just type `createresources.sh [pathfile-to-arm-template] resourcegroup -c location`. Called this way the script will:

1. Search for `path-to-arm-template.json` and `path-to-arm-template.parameters.json` files
2. If they exist, will create the `resourcegroup` specified in the `location` specified.
3. Finally will deploy `path-to-arm-template.json` and `path-to-arm-template.parameters.json` files in the `resourcegroup`


