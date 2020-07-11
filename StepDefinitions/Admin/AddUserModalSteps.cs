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
    public class AddUserModalSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private string note;
        



        public AddUserModalSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user is on '(.*)' modal")]
        public void GivenUserIsOnModal(string button)
        {
            new UserManagement(driverContext).AddUsers(button);
        }
        [When(@"user adds duplicate email '(.*)'")]
        public void WhenUserAddsDuplicateEmail(string email)
        {
            new AddUserModal(driverContext).InputEmail(email);
        }
        [When(@"user adds duplicate username '(.*)'")]
        public void WhenUserAddsDuplicateUsername(string username)
        {
            new AddUserModal(driverContext)
                .CheckUsername()
                .InputUsername(username);
        }
        [When(@"user '(.*)' permission is selected")]
        public void WhenUserPermissionIsSelected(string license)
        {
            new AddUserModal(driverContext)
                .SelectNowRx(license)
                .SelectPowRx(license);            
        }
        [When(@"signle user is added")]
        public void WhenSignleUserIsAdded()
        {
            new AddUserModal(driverContext)
                .InputFirstName("sabina")
                .InputLastName("test")
                .InputTitle("qa")
                .InputDepartment("n/a")
                .InputEmail()
                .SelectNowRx()
                .Create()
                .Create()
                .Close();
        }


        [Then(@"user should see error message")]
        public void ThenUserShouldSeeErrorMessage()
        {
            new AddUserModal(driverContext).VerifyExistingUser();
        }
        [Then(@"'(.*)' permission checkboxes are displayed")]
        public void ThenPermissionCheckboxesAreDisplayed(string userRoles)
        {
            new AddUserModal(driverContext);
            userRoles = S("#checkbox-group").Text;
            Console.WriteLine(userRoles.ToString());
        }
        

























    }
}
