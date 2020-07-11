Feature: User Roles


@regression

Scenario: Display CommRx user roles
	Given 'CPT5' user is logged in	
	When user expands 'User Roles' filter
	Then filter display roles based on org license


Scenario: Display PowRx user roles
	Given 'CPT8' user is logged in
	And user nagivates to 'Admin' page
	And user chooses 'User Management' subpanel
	When user expands 'User Roles' filter
	Then filter display roles based on org license




