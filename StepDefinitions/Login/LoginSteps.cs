using System;
using System.Configuration;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;


namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private object userType;

        public object Driver { get; private set; }

        public LoginSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
       

        [Given(@"'(.*)' user is logged in")]
        public void GivenUserIsLoggedIn(string userType)
        {
            

            if (userType.Contains("CPT"))
            {
                var userIndex = userType.Replace("CPT", "");
                //var envConsoleParameter = TestContext.Parameters["environment"];
                //var envURL = ConfigurationManager.AppSettings[envConsoleParameter + "_url"];
                var userName = ConfigurationManager.AppSettings["cpt_username"].Replace("@", userIndex + "@");
                new LoginPage(driverContext)
                                 .GoTo()
                                 .EnterEmail(userName)
                                 .Submit()
                                 .EnterPassword(ConfigurationManager.AppSettings["cpt_password"])
                                 .SignIn();
            }
            else if (userType == "SLS")
            {

                new SLSLoginPage(driverContext)
                    .GoTo(ConfigurationManager.AppSettings["sls_url"])
                    .EnterUsername(ConfigurationManager.AppSettings["sls_username"])
                    .EnterPassword(ConfigurationManager.AppSettings["sls_password"])
                    .LoginButton();
            }           
            
        }    
                
        
    }
}

