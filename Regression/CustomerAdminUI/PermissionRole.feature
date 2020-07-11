Feature: PermissionRole

	Background: 
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel
	And user is on 'Add User' modal

@regression
Scenario:01. Verify NowRx/PowRx user roles
	When user '<license>' permission is selected
	Then 'user roles' permission checkboxes are displayed
	 
	
	Examples: 
	| license |
	| NowRx   |
	| PowRx   |
