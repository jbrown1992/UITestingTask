using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITestingTask.Pages
{
    public class DeleteTimesheetPage
    {
        IWebDriver _driver;
        public IWebElement deleteButton => _driver.FindElement(By.ClassName("btn"));


        public DeleteTimesheetPage(IWebDriver driver)
        {
            _driver = driver;
        }

        internal string GetTimesheetId()
        {
            //need to get Id from here as timesheet id on page is incorrect 
            string url = _driver.Url;
            var values = url.Split("=");
            return values[1];
        }

        internal void DeleteTimesheet()
        {
            deleteButton.Click();
        }



    }
}
