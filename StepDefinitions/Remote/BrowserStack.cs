namespace NowPow.Automation.Features
{
    using System;
    using static NSelene.Selene;
    using TechTalk.SpecFlow;
    using Ocaramba;
    using Ocaramba.Logger;
    using NUnit.Framework;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using OpenQA.Selenium.Chrome;





    /// <summary>
    /// The base class for all tests <see href="https://github.com/ObjectivityLtd/NowPow/wiki/ProjectTestBase-class">More details on wiki</see>
    /// </summary>
    [Binding]
    public class ProjectTestBase : TestBase
    {
        private readonly ScenarioContext scenarioContext;
        private DriverContext driverContext = new DriverContext();


        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTestBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"> Scenario Context </param>
        public ProjectTestBase(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Gets or sets logger instance for driver
        /// </summary>
        public TestLogger LogTest
        {
            get
            {
                return this.DriverContext.LogTest;
            }

            set
            {
                this.DriverContext.LogTest = value;
            }
        }

        /// <summary>
        /// Gets the browser manager
        /// </summary>
        protected DriverContext DriverContext
        {
            get
            {
                return this.driverContext;
            }
            set { this.driverContext = value; }
        }

        public object TimeUnit { get; private set; }
        public ChromeDriver driver { get; private set; }


        /// <summary>
        /// Before the class.
        /// </summary>
        [BeforeFeature]
        public static void BeforeClass()
        {

        }

        /// <summary>
        /// After the class.
        /// </summary>
        [AfterFeature]
        public static void AfterClass(FeatureContext featureContext)
        {
            //((DriverContext)(featureContext["DriverContext"])).Stop();
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [Before]
        public void BeforeTest(FeatureContext featureContext)
        {
            this.DriverContext.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.DriverContext.TestTitle = this.scenarioContext.ScenarioInfo.Title;
            this.LogTest.LogTestStarting(this.driverContext);

            if (false)
            {
                SetBrowserStack();
            }
            else
            {
                this.DriverContext.Start();
            }

            this.scenarioContext["DriverContext"] = this.DriverContext;
            featureContext["DriverContext"] = this.DriverContext;

            SetWebDriver(DriverContext.Driver);
            DriverContext.Driver.Manage().Window.Maximize();

        }

        public void SetBrowserStack()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("browserName", "Chrome");
            capabilities.SetCapability("browserVersion", "79.0");
            capabilities.SetCapability("resolution", "1920x1080");
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("resolution", "1920x1080");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("seleniumVersion", "3.5.2");
            browserstackOptions.Add("userName", "sabinadovlati2");
            browserstackOptions.Add("accessKey", "Natzs5qz4gqA615Sizrr");
            capabilities.SetCapability("bstack:options", browserstackOptions);

            IWebDriver dr = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities
            );
            dr.Manage().Window.Maximize();
            //dr.Navigate().GoToUrl("http://www.google.com"); 

        }

        /// <summary>
        /// After the test.
        /// </summary>
        [After]
        public void AfterTest()
        {
            try
            {
                this.DriverContext.IsTestFailed = this.scenarioContext.TestError != null || !this.driverContext.VerifyMessages.Count.Equals(0);
                var filePaths = this.SaveTestDetailsIfTestFailed(this.driverContext);
                this.SaveAttachmentsToTestContext(filePaths);
                var javaScriptErrors = this.DriverContext.LogJavaScriptErrors();

                this.LogTest.LogTestEnding(this.driverContext);
                if (this.IsVerifyFailedAndClearMessages(this.driverContext) && this.scenarioContext.TestError == null)
                {
                    Assert.Fail();
                }

                if (javaScriptErrors)
                {
                    Assert.Fail("JavaScript errors found. See the logs for details");
                }
            }
            finally
            {
                // the context should be cleaned up no matter what
                this.DriverContext.Stop();
            }
        }

        private void SaveAttachmentsToTestContext(string[] filePaths)
        {
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    this.LogTest.Info("Uploading file [{0}] to test context", filePath);
                    TestContext.AddTestAttachment(filePath);
                }
            }
        }
    }
}
