Feature: Accounting
Background: This tests features of the Accounting module.
Scenario:  Add bank account
 Given I login to Xero with below credentials
  | Username      | Password    |
  | guen_yu@yahoo.com | password123 |
 When I click 'Accounting' from menu
 When I click Bank accounts from Accounting submenu
 Then I add new bank account
  | BankName | AccountName | AccountType           | AccountNumber |
  | ANZ (NZ) | Guen Yu     | Everyday (day-to-day) | 061123456     |
 
 