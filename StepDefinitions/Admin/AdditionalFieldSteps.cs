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
    public class AdditionalFieldSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        IList<IWebElement> additionalField = SS("tbody > tr");


        public AdditionalFieldSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user adds new field")]
        public void WhenUserAddsNewField()
        {
            new ReferralFormConfiguration(driverContext)
                .AddNewField()
                .InputFieldTitle("automation")
                .MarkRequired()
                .SelectService()
                .AddField();
        }
        [When(@"user edits title")]
        public void WhenUserEditsTitle()
        {
            new ReferralFormConfiguration(driverContext)
                .EditAdditionalField()
                .EditTitle();                
        }
        [When(@"user edits service")]
        public void WhenUserEditsService()
        {
            new EditAdditionalField(driverContext)
                .EditService()
                .EditField();
        }

        [When(@"user mouses over to the tooltip")]
        public void WhenUserMousesOverToTheTooltip()
        {
            new ReferralFormConfiguration(driverContext).HoverToTooltip();
        }
        [When(@"user deletes additional field")]
        public void WhenUserDeletesAdditionalField()
        {
            new ReferralFormConfiguration(driverContext).DeleteField();
        }


        [Then(@"new additional field becomes required")]
        public void ThenNewAdditionalFieldBecomesRequired()
        {
            new ReferralFormConfiguration(driverContext);

            
            foreach (var row in additionalField)
            {
                if (row.Text.Contains("automation"))
                {
                    Console.WriteLine(row.Text);

                    var tds = row.FindElements(By.TagName("td"));
                    foreach (var entry in tds)
                    {
                        Console.WriteLine(entry.Text);

                    }
                }


            }
        }
        [Then(@"'(.*)' is displayed in the section")]
        public void ThenIsDisplayedInTheSection(string requiredField)
        {
            new ReferralFormConfiguration(driverContext).VerifyTable();
           
        }
        [Then(@"tooltip displays '(.*)'")]
        public void ThenTooltipDisplays(string tooltipText)
        {
            new ReferralFormConfiguration(driverContext);
            tooltipText = S(By.ClassName("tooltip-inner")).Text;
            Console.WriteLine(tooltipText.ToString());
        }
        [Then(@"field is deleted")]
        public void ThenFieldIsDeleted()
        {
            new ReferralFormConfiguration(driverContext);           
            additionalField.Count.ToString();
        }
        [Then(@"edited fields display in '(.*)' section")]
        public void ThenEditedFieldsDisplayInSection(string editedField)
        {
            Console.WriteLine(S(By.XPath("//tr[1]//td[3]")).Text);
        }




    }
}
