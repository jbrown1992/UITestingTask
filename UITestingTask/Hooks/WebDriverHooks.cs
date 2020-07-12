using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace UITestingTask.Hooks
{
        [Binding]
        public class WebDriverHooks
        {
            private readonly IObjectContainer container;

            public WebDriverHooks(IObjectContainer container)
            {
                this.container = container;
            }

            [BeforeScenario]
            public void CreateWebDriver()
            {   
                ChromeDriver driver = new ChromeDriver();
                container.RegisterInstanceAs<IWebDriver>(driver);
            }

            [AfterScenario]
            public void DestroyWebDriver()
            {
                var driver = container.Resolve<IWebDriver>();

                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
        }
}
