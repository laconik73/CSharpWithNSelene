Feature: NowPowDefaultField
	
Background: 
Given 'CPT8' user is logged in
And user nagivates to 'Admin' page
And user is on 'Referral Form'

Scenario: Verify NowPow Default Fields Section
	When I select default field
	Then that particular field is required on the Referral Form
