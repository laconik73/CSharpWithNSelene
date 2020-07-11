Feature: Configurations
	
Background: 
Given 'CPT8' user is logged in
And user nagivates to 'Admin' page

@regression
Scenario: 01. Configurations side-panel display
	When user chooses <configurations> subpanel
	Then <Referral Form> and <Service Outcome> subtabs are displayed





	
