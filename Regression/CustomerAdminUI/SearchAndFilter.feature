Feature: SearchAndFilter
	
Background: 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel

@regression
Scenario Outline: 01. User search and filtering
	When admin user searches for a user by '<searchBox>'  
	Then search is conducted accross columns

	Examples: 

	| user         | searchBox		 |
	| name         | america	     |
	| title        | qa              |
	| organization | automation      |
	| username     | france@paris.org|
	| email        | iphone@aaa.org  |






	
	
	
