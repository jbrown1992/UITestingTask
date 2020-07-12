using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UITestingTask.Pages;

namespace UITestingTask.Steps
{
    [Binding]
    public class CreateNewTimesheetSteps
    {
        HomePage _homePage;
        CreateTimesheetPage _createTimesheetPage;
        string _timesheetId;
        public CreateNewTimesheetSteps(HomePage homePage, CreateTimesheetPage createTimesheetPage)
        {
            _homePage = homePage;
            _createTimesheetPage = createTimesheetPage;
        }

        [Given(@"I am on the Home Page")]
        public void GivenIAmOnTheHomePage()
        {
            _homePage.NavigateToHomePage();
        }

        [Given(@"I click Create New")]
        public void GivenIClickCreateNew()
        {
            _homePage.ClickCreateNew();
        }

        [Given(@"I click Delete")]
        public void GivenIClickDelete()
        {
            _homePage.ClickDelete();
        }

        [Given(@"I enter valid timesheet")]
        [When(@"I enter valid timesheet")]
        public void WhenIEnterValidTimesheet()
        {
            //TODO: builder class to create default timesheet so can be used across steps (if had more time)
            _createTimesheetPage.EnterEmployeeId("CTD111");
            _createTimesheetPage.EnterHourlyRate("12.34");
            _createTimesheetPage.EnterDay("Wednesday");
            _createTimesheetPage.EnterHours("7");
            _createTimesheetPage.EnterMinutes("30");
        }

        [Given(@"I enter valid timesheet with two days")]
        public void GivenIEnterValidTimesheetWithTwoDays()
        {
            _createTimesheetPage.EnterEmployeeId("CTD111");
            _createTimesheetPage.EnterHourlyRate("12.34");
            _createTimesheetPage.EnterDay("Wednesday");
            _createTimesheetPage.EnterHours("7");
            _createTimesheetPage.EnterMinutes("30");
            _createTimesheetPage.AddRow();
        }



        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            _createTimesheetPage.ClickSaveButton();
            _timesheetId = _createTimesheetPage.GetTimesheetId();
            //need to navigate to home page due to bug to continue writing test
            _homePage.NavigateToHomePage();
        }

        [Then(@"timesheet is added")]
        public void ThenTimesheetIsAdded()
        {
            Assert.IsTrue(_homePage.IsTimesheetVisible(_timesheetId));
        }

        [When(@"I remove day row from timesheet")]
        public void WhenIRemoveDayRowFromTimesheet()
        {
            _createTimesheetPage.RemoveDayRow();
        }


        [Then(@"timesheet only contains (.*) days")]
        [Then(@"timesheet only contains (.*) day")]
        public void ThenTimesheetOnlyContainsDays(int numberOfDays)
        {
            var actualCount = _createTimesheetPage.GetNumberOfDaysOnTimesheet();
            Assert.AreEqual(numberOfDays, actualCount);
        }

  



    }
}
