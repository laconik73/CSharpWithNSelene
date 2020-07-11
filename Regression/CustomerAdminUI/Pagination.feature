Feature: Pagination
	
Background: 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel

@regression
Scenario:01. Users Table Paging (PowRx)	
	When user table shows paging controls
	Then user able to page through the result set
	
