provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "api-management-rg"
  location = "eastus"
}

resource "azurerm_api_management" "apim" {
  name                = "terraform-api-management"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  publisher_name      = "Terraform API Demo"
  publisher_email     = "ptd@netcompany.com"

  sku_name = "Developer_1"

}

resource "azurerm_api_management_api" "api" {
  name                = "my-api"
  api_management_name = azurerm_api_management.apim.name
  revision            = "1"
  display_name        = "My API"
  description         = "My API Description"
  path                = "my-api"
  protocols = [
    "https",
  ]

  resource_group_name = azurerm_resource_group.rg.name
}

resource "azurerm_api_management_api_operation" "operation" {
  operation_id        = "Operation"
  api_name            = azurerm_api_management_api.api.name
  api_management_name = azurerm_api_management.apim.name
  method              = "GET"
  url_template        = "/customer/all"
  resource_group_name = azurerm_resource_group.rg.name

  display_name = "Operation"
}

resource "azurerm_api_management_api_policy" "policy" {
  api_name            = azurerm_api_management_api.api.name
  api_management_name = azurerm_api_management.apim.name
  xml_content         = <<XML
    <policies>
    <inbound>
        <base />
        <set-backend-service base-url="https://terraform.azurewebsites.net" />
    </inbound>
    </policies>
    XML

  resource_group_name = azurerm_resource_group.rg.name
}

