// Main Infrastructure Deployment for WEWE-NGO-APP
targetScope = 'resourceGroup'

param location string = resourceGroup().location

@secure()
param databasePassword string = 'P@ssw0rdWEWE2026!' // Best practice: Use Key Vault

module sqlResources 'sql.bicep' = {
  name: 'sqlDeployment'
  params: {
    location: location
    sqlAdminPassword: databasePassword
  }
}

module functionResources 'functions.bicep' = {
  name: 'functionDeployment'
  params: {
    location: location
  }
}

output sqlServerUrl string = sqlResources.outputs.sqlFqdn
