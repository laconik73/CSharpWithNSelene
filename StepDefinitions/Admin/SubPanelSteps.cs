using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;
using System.Collections.Generic;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class SubPanelSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        IList<IWebElement> subtabs = SS(".col-12.side-panel-subtab");

        public SubPanelSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user is on '(.*)'")]
        public void GivenUserIsOn(string subPanel)
        {
            new AdminPage(driverContext)
                .OpenConfigurations(subPanel)
                .OpenReferralForm();
        }
        [Given(@"user chooses '(.*)' subpanel")]
        public void GivenUserChoosesSubpanel(string subPanel)
        {
            new AdminPage(driverContext).OpenUserManagement(subPanel);
        }

        [When(@"user chooses (.*) subpanel")]
        public void WhenUserChoosesSubpanel(string subPanel)
        {
            new AdminPage(driverContext).OpenConfigurations(subPanel);
        }
        [Then(@"(.*) and (.*) subtabs are displayed")]
        public void ThenAndSubtabsAreDisplayed(string referralForm, string serviceOutcome)
        {
            new AdminPage(driverContext);
            
            IList<string> subtab = new List<string>();
            foreach (IWebElement element in subtabs)
            {
                subtab.Add(element.ToString());
                Console.WriteLine(element.Text);
            }            

        }

    }
}
