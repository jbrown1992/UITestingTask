using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITestingTask.Pages
{
    public class HomePage
    {
        IWebDriver _driver;
        private string url = "https://codat-qa-task-d5bd.azurewebsites.net/";
        public IWebElement createNewButton => _driver.FindElement(By.LinkText("Create New"));
        public IWebElement deleteButton => _driver.FindElement(By.LinkText("Delete"));
        public IWebElement timesheetTable => _driver.FindElement(By.TagName("table"));


        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }
        internal void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(url);
            Assert.IsTrue(createNewButton.Displayed);
        }

        internal void ClickCreateNew()
        {
            createNewButton.Click();
        }

        internal void ClickDelete()
        {
            deleteButton.Click();
        }

        internal bool IsTimesheetVisible(string timesheetId)
        {
            var rows = timesheetTable.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var rowTds = row.FindElements(By.TagName("td"));
                foreach (var td in rowTds)
                {
                    if (td.Text == timesheetId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
