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
    public class NowPowDefaultFieldSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;


        public NowPowDefaultFieldSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"I select default field")]
        public void WhenISelectDefaultField()
        {
            new ReferralFormConfiguration(driverContext)
                .SelectDefaultField();
        }
        [Then(@"that particular field is required on the Referral Form")]
        public void ThenThatParticularFieldIsRequiredOnTheReferralForm()
        {
            new ReferralFormConfiguration(driverContext);
            Console.WriteLine(S(".required-label").Text);
        }


    }
}
