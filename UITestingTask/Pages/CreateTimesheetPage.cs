using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITestingTask.Pages
{
    public class CreateTimesheetPage
    {
        IWebDriver _driver;
        private string url = "https://codat-qa-task-d5bd.azurewebsites.net/CreateOrEdit";
        public IWebElement employeeId => _driver.FindElement(By.Id("Timesheet_EmployeeId"));
        public IWebElement hourlyRate => _driver.FindElement(By.Id("Timesheet_HourlyRate"));
        public IWebElement dayDropdown => _driver.FindElement(By.Id("newEntry_Day"));
        public IWebElement hoursField => _driver.FindElement(By.Id("newEntry_Hours"));
        public IWebElement minutesField => _driver.FindElement(By.Id("newEntry_Minutes"));
        public IWebElement saveButton => _driver.FindElement(By.ClassName("btn"));
        public IWebElement addRow => _driver.FindElement(By.Id("add-row"));
        public IWebElement removeRow => _driver.FindElement((By.XPath("//button[contains(text(), '-')]")));
        public IWebElement timesheetDaysTable => _driver.FindElement(By.Id("timesheet-table"));

        public CreateTimesheetPage(IWebDriver driver)
        {
            _driver = driver;
        }
        internal void NavigateToCreateTimesheetPage()
        {
            _driver.Navigate().GoToUrl(url);
        }

        internal void EnterEmployeeId(string employeeIdInput)
        {
            employeeId.SendKeys(employeeIdInput);
        }

        internal void EnterHourlyRate(string hourlyRateInput)
        {
            hourlyRate.Clear();
            hourlyRate.SendKeys(hourlyRateInput);
        }

        internal string GetTimesheetId()
        {
            string url = _driver.Url;
            var values = url.Split("=");
            return values[1];
        }

        internal void EnterDay(string dayInput)
        {
            var selectElement = new SelectElement(dayDropdown);
            selectElement.SelectByText(dayInput);
        }



        internal void RemoveDayRow()
        {
            removeRow.Click();
        }

        internal void AddRow()
        {
            addRow.Click();
        }

        internal void EnterHours(string hoursInput)
        {
            hoursField.SendKeys(hoursInput);
        }

        internal void EnterMinutes(string minutesInput)
        {
            minutesField.SendKeys(minutesInput);
        }

        internal void ClickSaveButton()
        {
            saveButton.Click();
        }

        internal int GetNumberOfDaysOnTimesheet()
        {
            //get rows from body
            var tableBody = timesheetDaysTable.FindElement(By.TagName("tbody"));
            var bRows = tableBody.FindElements(By.TagName("tr"));

            //get rows from footer - currently 1
            var tableFoot = timesheetDaysTable.FindElement(By.TagName("tfoot"));
            var fRows = tableFoot.FindElements(By.TagName("tr"));
            return bRows.Count + fRows.Count;
          
        }
    }
}
