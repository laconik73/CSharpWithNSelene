using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class TabSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;

        public TabSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses tab '(.*)'")]
        public void GivenUserChoosesTab(string tabName)
        {
            new TabsNavigationPage(driverContext)
                .OpenPatient(tabName)
                .ChoosePatientCard();
        }
        [Given(@"user nagivates to '(.*)' page")]
        public void GivenUserNagivatesToPage(string tabName)
        {
            new TabsNavigationPage(driverContext).OpenAdmin(tabName);
        }

    }
}

