// SQL Database Infrastructure for WEWE-NGO-APP
param location string = resourceGroup().location
param serverName string = 'sql-wewe-${uniqueString(resourceGroup().id)}'
param sqlAdminLogin string = 'weweadmin'

@secure()
param sqlAdminPassword string

resource sqlServer 'Microsoft.Sql/servers@2021-11-01' = {
  name: serverName
  location: location
  properties: {
    administratorLogin: sqlAdminLogin
    administratorPassword: sqlAdminPassword
  }
}

resource sqlDatabase 'Microsoft.Sql/servers/databases@2021-11-01' = {
  parent: sqlServer
  name: 'WidowsDB'
  location: location
  sku: {
    name: 'Basic'
    tier: 'Basic'
  }
}

// Allow Azure Services (like your Functions) to access the DB
resource allowAzureServices 'Microsoft.Sql/servers/firewallRules@2021-11-01' = {
  parent: sqlServer
  name: 'AllowAllWindowsAzureIps'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
  }
}

output sqlFqdn string = sqlServer.properties.fullyQualifiedDomainName
