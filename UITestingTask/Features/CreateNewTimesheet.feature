Feature: CreateNewTimesheet
	As a employee
	I want to add my timesheet	
	So I can get paid per week


Scenario: Create New Timesheet
	Given I am on the Home Page
	And I click Create New
	When I enter valid timesheet
	And I click Save
	Then timesheet is added


Scenario: Remove Day from Timesheet
	Given I am on the Home Page
	And I click Create New
	And I enter valid timesheet with two days
	When I remove day row from timesheet
	Then timesheet only contains 1 day