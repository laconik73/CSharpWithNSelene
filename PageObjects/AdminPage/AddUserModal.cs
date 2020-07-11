using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class AddUserModal : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        IList<IWebElement> inputFields = SS(".form-control.invalid");
        SeleneElement usernameCheckbox = S(".custom-control.custom-checkbox");
        SeleneElement blueLink = S(".btn.existing-user-btn.btn-link");
        SeleneElement permissionDropdown = S("#powrx-permission button");
        SeleneElement nowRxRole = S(By.PartialLinkText("NowRx"));
        SeleneElement powRxRole = S(By.PartialLinkText("PowRx"));
        IList<IWebElement> checkboxes = SS("div.col-6");
        IList<IWebElement> buttons = SS(".modal-footer button");
        public AddUserModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal AddUserModal InputEmail(string email)
        {
            inputFields.ElementAt(4).SendKeys(email);

            //click anywhere inside the modal 
            inputFields.ElementAt(0).Click();
            return this;
        }
        
        internal AddUserModal CheckUsername()
        {
            usernameCheckbox.Hover().Click();
            return this;
        }

        internal AddUserModal InputUsername(string username)
        {
            //not a duplicate code. Must use data provider 'username' 
            inputFields.ElementAt(4).SendKeys(username);
            //click anywhere inside the modal 
            inputFields.ElementAt(0).Click();

            return this;
        }       

        internal AddUserModal VerifyExistingUser()
        {
            Assert.IsTrue(S(".existing-user-text").Displayed);
            Assert.IsTrue(blueLink.Displayed);
            return this;
        }      

        internal AddUserModal SelectNowRx(string license)
        {
            permissionDropdown.Hover().Click();
            nowRxRole.Click();
            Assert.IsTrue(checkboxes[5].Displayed);
            IList<string> checkbox = new List<string>();
            foreach (IWebElement element in checkboxes)
            {
                checkbox.Add(element.ToString());
                Console.WriteLine(element.Text);
            }
            return this;
        }       

        internal AddUserModal SelectPowRx(string license)
        {
            permissionDropdown.Hover().Click();
            powRxRole.Click();            
            return this;
        }
        internal AddUserModal InputFirstName(string firstName)
        {
            inputFields.ElementAt(0).SendKeys(firstName);
            return this;
        }
        internal AddUserModal InputLastName(string lastName)
        {
            inputFields.ElementAt(1).SendKeys(lastName);
            Thread.Sleep(500);
            return this;
        }
        internal AddUserModal InputTitle(string title)
        {
            inputFields.ElementAt(1).SendKeys(title);
            Thread.Sleep(500);
            return this;
        }
        internal AddUserModal InputDepartment(string department)
        {
            inputFields.ElementAt(1).SendKeys(department);
            Thread.Sleep(500);
            return this;
        }
        internal AddUserModal InputEmail()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 10;
            char[] charList = Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray();
            string newEmail = "Ab1" + new string(charList) + "@email.com";

            inputFields.ElementAt(1).SendKeys(newEmail);
            return this;
        }
        internal AddUserModal SelectNowRx()
        {
            permissionDropdown.Hover().Click();
            nowRxRole.Click();
            return this;
        }
        internal AddUserModal Create()
        {
            buttons.ElementAt(1).Click();
            return new AddUserModal(DriverContext);
        }
        internal UserManagement Close()
        {            
            String userCreation = S(".modal-body span").Text;
            Console.WriteLine(userCreation.ToString());
            buttons.ElementAt(0).Click();
            return new UserManagement(DriverContext);
        }
        
            


    }
}

