Feature: Product
Background: 
Scenario:  Test
 Given I login to Unleashed Software with below credentials
  | Username      | Password    |
  | qa+yu1@unl.sh | Password123 |
 When I click Add Product
 #And I enter the following details
 #| ProductCode    | ProductDescription           |
 #| QAProductCode1 | Sample Product description 1 |
 And I create the following product details
 | ProductCode    | ProductDescription           |
 | QAProductCode1 | Sample Product description 1 |
 Then An alert message appears with text
 | Message                                    |
 | You have updated the product successfully. |