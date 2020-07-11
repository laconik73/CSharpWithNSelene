Feature: Add User Modal (PowRx license)

#Data Driven approach in BDD 

Background: 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel
	And user is on 'Add User' modal

@regression
Scenario Outline: Check for existing user
	When user adds duplicate email '<email>'	
	And user adds duplicate username '<username>'
	Then user should see error message  

	Examples: 
	   | email          | username        |
	   | bubu9@kuku.com | bubu9@kuku.com  |
	   | kuku@kuku.com  | kuku@kuku.com   |
	    

#Add as many examples as you need to test.
#For none existing/new username/email test shall always fail

Scenario: Add single user
	When signle user is added
	Then user management list is refreshed















	
	
