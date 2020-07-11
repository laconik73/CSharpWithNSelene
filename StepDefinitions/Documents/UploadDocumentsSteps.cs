using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;
using System.Threading;
using System.Collections.Generic;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class UploadDocumentsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        IList<IWebElement> allFiles = SS(By.XPath("//td//h4"));

        public UploadDocumentsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [When(@"user uploads '(.*)'")]
        public void WhenUserUploads(string documents)
        {
            new PatientDocuments(driverContext)
                .ClickUploadDocuments()
                .ChooseVirusFile(documents)
                .Upload();
            Thread.Sleep(1000);
        }
        [When(@"user uploads large '(.*)'")]
        public void WhenUserUploadsLarge(string documents)
        {
            new PatientDocuments(driverContext)
                .ClickUploadDocuments()
                .ChooseLargeFile(documents)
                .Upload();
            Thread.Sleep(2000);
        }
        [When(@"user uploads documents")]
        public void WhenUserUploadsDocuments()
        {
            new PatientDocuments(driverContext)
                 .ClickUploadDocuments()
                 .ChooseFile()
                 .Upload();
            Thread.Sleep(500);
            
        }
        [When(@"user uploads same document")]
        public void WhenUserUploadsSameDocument()
        {
            new PatientDocuments(driverContext)                
                 .ClickUploadDocuments()
                 .ChooseFile()
                 .Upload();
            Thread.Sleep(500);
        }

        [Then(@"user should see a warning message")]
        public void ThenUserShouldSeeAWarningMessage()
        {
            new PatientDocuments(driverContext);

            Console.WriteLine(S(".error-area.row").Text);
            Thread.Sleep(1000);
            
        }
        [Then(@"duplicate files name are displayed with '(.*)' increase")]
        public void ThenDuplicateFilesNameAreDisplayedWithIncrease(string unitIncrease)
        {
            new PatientDocuments(driverContext);
            
            List<string> unit = new List<string>();
            foreach (IWebElement element in allFiles)
            {
                unit.Add(element.ToString());              
                
            }
           
        }



    }
}
