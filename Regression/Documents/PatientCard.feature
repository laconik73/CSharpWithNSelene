Feature: PatientCard
	
	Background: 
	Given 'CPT4' user is logged in
	And user chooses tab 'Patient'	
		


Scenario Outline: 03. Verify Error Message display (virus doc)
	When user clicks on '<subtab>'
	And user uploads '<documents>' 
	Then user should see a warning message 

	Examples: 
	| subtab    | documents      | error message               |
	| documents | virus document | potencial security danger   |
	
	
Scenario Outline: 02. Verify Error Message display (over 4MB)
	When user clicks on '<subtab>'
	And user uploads large '<documents>' 
	Then user should see a warning message

	Examples: 
	| subtab    | documents      | error message               |
	| documents | over 4MB       | try uploading a smaller file|


Scenario Outline: 01. Verify N increase
	When user clicks on '<subtab>'
	And user uploads documents
	And user uploads same document
	Then duplicate files name are displayed with 'N' increase

	Examples: 
	| subtab    | duplate name NIncrease   |
	| documents | Scale.pdf (1)			   |
