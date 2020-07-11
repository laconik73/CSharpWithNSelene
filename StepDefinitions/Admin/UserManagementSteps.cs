using System;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using static NSelene.Selene;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;
using System.Collections.Generic;
using System.Linq;

namespace Nowpow.Automation.Features.StepDefinitions
{
    [Binding]
    public class UserManagementSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        IList<IWebElement> tableColumns = SS(By.TagName("td"));
        IList<IWebElement> rows = SS(By.XPath("//tr"));




        public UserManagementSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        
        [When(@"user table shows paging controls")]
        public void WhenUserTableShowsPagingControls()
        {
            new UserManagement(driverContext);
            Assert.IsTrue(S("#pagination-control").Displayed);
        }
        [When(@"admin user searches for a user by '(.*)'")]
        public void WhenAdminUserSearchesForAUserBy(string searchBox)
        {
            new UserManagement(driverContext)
                .SearchUser(searchBox)
                .Submit();
        }
        [When(@"admin user selects '(.*)' from org level")]
        public void WhenAdminUserSelectsFromOrgLevel(string filter)
        {
            new UserManagement(driverContext)
                .SelectOrganization(filter)
                .SelectEnterprise(filter);                
        }

        [Then(@"user able to page through the result set")]
        public void ThenUserAbleToPageThroughTheResultSet()
        {
            new UserManagement(driverContext).GoThroughResultSet();
        }
        [Then(@"search is conducted accross columns")]
        public void ThenSearchIsConductedAccrossColumns()
        {
            new UserManagement(driverContext);
            
            IList<string> rows = new List<string>();
            foreach (IWebElement element in tableColumns)
            {
                rows.Add(element.ToString());
                rows.Count().ToString();
            }
        }
        [Then(@"user management list is refreshed")]
        public void ThenUserManagementListIsRefreshed()
        {
            new UserManagement(driverContext);
            String showUsers = S(".current-users-label").Text;
            Console.WriteLine(showUsers.ToString());
            rows.Count.ToString();
        }
        [Then(@"'(.*)' button is not displayed")]
        public void ThenButtonIsNotDisplayed(string addUsers)
        {
            new UserManagement(driverContext);
            //verify 'AddUsers' button is not displayed
            S(".add-users-button").ShouldNot(Be.Visible);
           
        }   

    }
}
