using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using System.Collections.Generic;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class TakeActionSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        IList<IWebElement> userRoles = SS(".card.dropdown");

        public TakeActionSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user expands '(.*)' filter")]
        public void WhenUserExpandsFilter(string userRoles)
        {
            new UserManagement(driverContext).OpenFilter(userRoles);
        }
        
        [When(@"user selects (.*)")]
        public void WhenUserSelects(string action)
        {            
            new UserManagement(driverContext)
                .TakeAction()
                .DeactivateUser(action);     
                               
        }
        [When(@"user chooses activate")]
        public void WhenUserChoosesActivate()
        {            
            new UserManagement(driverContext).Activate();
        }
        [When(@"user clicks resend password")]
        public void WhenUserClicksResendPassword()
        {            
            new UserManagement(driverContext)
                .TakeAction()
                .ResendPassword();
        }
        [When(@"I select view/edit")]
        public void WhenISelectViewEdit()
        {            
            new UserManagement(driverContext)
                .TakeAction()
                .ViewEditUser();
        }

        [Then(@"filter display roles based on org license")]
        public void ThenFilterDisplayRolesBasedOnOrgLicense()
        {
            new UserManagement(driverContext);            
            Console.WriteLine(userRoles.ElementAt(1).ToString());
        }
        
        [Then(@"(.*) is displayed")]
        public void ThenIsDisplayed(string modal)
        {
            new UserManagement(driverContext).ConfirmAction(modal);
        }




    }
}
