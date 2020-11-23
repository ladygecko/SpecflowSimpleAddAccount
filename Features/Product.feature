Feature: Product
Background: 
Scenario:  Navigate to Add Product page and create a new product
 Given I login to Unleashed Software with below credentials
  | Username      | Password    |
  | qa+yu1@unl.sh | Password123 |
 When I click Inventory -> Products -> Add Product
 And I create the following product details
 | ProductCode    | ProductDescription           |
 | QAProductCode1 | Sample Product description 1 |
 Then An alert message appears with text
 | Message                                    |
 | You have updated the product successfully. |