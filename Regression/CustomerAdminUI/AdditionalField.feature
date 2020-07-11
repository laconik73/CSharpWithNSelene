Feature: AdditionalField
	
Background: 
Given 'CPT8' user is logged in
And user nagivates to 'Admin' page
And user is on 'Referral Form'

@regression
Scenario: 01.Verify Additional Fields Section
	When user adds new field	
	Then new additional field becomes required 
	And 'Yes' is displayed in the section

Scenario: 03. Verify tooltip text
	When user mouses over to the tooltip
	Then tooltip displays 'text'

Scenario: 04. Verify 'Delete'
	When user deletes additional field
	Then field is deleted

Scenario: 02. Edit additional field
	When user edits title	
	And user edits service
	Then edited fields display in 'Additional Fields' section

