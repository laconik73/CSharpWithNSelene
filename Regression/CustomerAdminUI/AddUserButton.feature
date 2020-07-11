Feature: AddUserButton
	
Background: 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel
	

Scenario Outline: Verify visibility of "Add Users" button 
	When admin user selects '<organization>' from org level
	Then 'Add Users' button is not displayed
	

	Examples: 
	| org level       | button        |
	| Test Enterprise | not displayed |

	#Add different orgs into examples to test display of the button
	#Examples: 
	#| org level | button	  	 |
	#| nowrx org | displayed     |
	#| network   | not displayed |
	


	


	
	
