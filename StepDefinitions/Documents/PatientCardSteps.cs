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
    public class PatientCardSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;

        public PatientCardSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user clicks on '(.*)'")]
        public void WhenUserClicksOn(string subtab)
        {
            new PatientOverviewPage(driverContext).OpenDocuments(subtab);
        }
        


    }
}

