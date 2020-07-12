Feature: DeleteTimesheet
	As a employee
	I want to delete my timesheet	
	So I dont get paid incorrecly 


Scenario: Delete Timesheet
	Given I am on the Home Page
	And I click Delete
	When I Delete timesheet
	Then timesheet is deleted
	