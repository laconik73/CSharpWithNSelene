Feature: TakeAction (CommRx)

Background: 
Given 'CPT5' user is logged in

@regression
Scenario Outline: 03.Take Action (Deactivate)	
	When user selects <action>
	Then <modal> is displayed

	Examples: 
	| action          | modal           |
	| deactivate      | deactivate user |
	

Scenario Outline: 04.Take Action (Activate)	
	When user chooses <action>
	Then <modal> is displayed

	Examples: 
	| action          | modal           |
	| activate        | activate user   |
	


Scenario Outline: 02.Take Action (Resend Password)	
	When user clicks <action>
	Then <modal> is displayed

	Examples: 
	| action          | modal           |	
	| resend password | resend password |
	

Scenario Outline: 01.Take Action (View/Edit)	
	When I select <action>
	Then <modal> is displayed

	Examples: 
	| action          | modal           |	
	| view/edit       | view/edit user  |











