Feature: Sales
Background: 
Scenario:  Complete Sales Order flow and verify the available stock on hand
 Given I login to Unleashed Software with below credentials
  | Username      | Password    |
  | qa+yu1@unl.sh | Password123 |
 When I click Sales -> Orders -> Add Sales Order 
 And I create the sales order with the following details
 | CustomerCode | Product   | Quantity | Comments  |
 | WADE         | BOOKSHELF | 1        | QATesting |
 And I click Add button
 And I click Complete button
 Then An alert message contains text
 | Message                                    |
 | You have successfully saved Sales Order |
 #Then The Stock on Hand of the product should display '53'
 