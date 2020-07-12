using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UITestingTask.Pages;

namespace UITestingTask.Steps
{
    [Binding]
    public class DeleteTimesheetSteps
    {
        HomePage _homePage;
        DeleteTimesheetPage _deleteTimesheetPage;
        string _timesheetId;
        public DeleteTimesheetSteps(HomePage homePage, DeleteTimesheetPage deleteTimesheetPage)
        {
            _homePage = homePage;
            _deleteTimesheetPage = deleteTimesheetPage;
        }

        [When(@"I Delete timesheet")]
        public void WhenIDeleteTimesheet()
        {
            _deleteTimesheetPage.DeleteTimesheet();
        }


        [Then(@"timesheet is deleted")]
        public void ThenTimesheetIsDeleted()
        {
            Assert.IsFalse(_homePage.IsTimesheetVisible(_timesheetId));
        }
    }
}
