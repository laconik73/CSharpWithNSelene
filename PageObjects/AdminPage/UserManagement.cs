using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class UserManagement : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement userRolesFilter = S(".filter-dropdown-container");
        SeleneElement orgLevelFilter = S("#organization-dropdown-container");
        IList<IWebElement> actionButton = SS(".take-action-dropdown");
        SeleneElement activateButton = S(".reactivate-btn");
        SeleneElement deactivateAction = S(By.PartialLinkText("Deactiva"));
        SeleneElement resendPasswordAction = S(By.PartialLinkText("Resend Passwo"));
        SeleneElement viewEditAction = S(By.PartialLinkText("View/Ed"));      
        IList<IWebElement> confirmButton = SS(".modal-footer button");
        SeleneElement addUsersButton = S("button[class*='add-users-button']");
        IList<IWebElement> pagination = SS("#pagination-control li");
        SeleneElement userSearch = S("#user-search");
        SeleneElement buttonSearch = S("#btn-search");
        IList<IWebElement> organizations = SS(".ent-org-btn");

        public UserManagement(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal UserManagement OpenFilter(string userRoles)
        {
            userRolesFilter.Hover().Click();                        
            return this;
        }       

        internal UserManagement TakeAction()
        {
            actionButton.ElementAt(0).Click();
            return this;
        }        

        internal UserManagement Activate()
        {
            activateButton.Hover().Click();
            return new UserManagement(DriverContext);
        }       

        internal UserManagement DeactivateUser(string action)
        {
            deactivateAction.Hover().Click();
            return new UserManagement(DriverContext);
        }

        internal UserManagement ViewEditUser()
        {
            viewEditAction.Hover().Click();
            return new UserManagement(DriverContext);
        }
        
        internal UserManagement ResendPassword()
        {
            resendPasswordAction.Hover().Click();
            return new UserManagement(DriverContext);
        }

        internal UserManagement ConfirmAction(string modal)
        {
            modal = S(".modal-header h5").Text;            
            Console.WriteLine(modal.ToString());            

            try
            {
                confirmButton.ElementAt(1).Click();
            }
            catch(Exception e)
            {
                confirmButton.ElementAt(1).Click();
            }
            
            return new UserManagement(DriverContext);
        }
        internal AddUserModal AddUsers(string button)
        {
            addUsersButton.Hover().Click();
            return new AddUserModal(DriverContext);
        }
        internal UserManagement GoThroughResultSet()
        {
            pagination.ElementAt(3).Click();
            pagination.ElementAt(4).Click();
            pagination.ElementAt(1).Click();
            pagination.ElementAt(0).Click();
            return new UserManagement(DriverContext);
        }
        internal UserManagement SearchUser(string searchBox)
        {
            userSearch.SendKeys(searchBox);
            return this;
        }
        internal UserManagement Submit()
        {
            buttonSearch.Click();
            return new UserManagement(DriverContext);
        }
        internal UserManagement SelectEnterprise(string filter)
        {
            //open filter
            orgLevelFilter.Hover().Click();
            //select enterprise
            S("div.org-to-be-acted-on > span:nth-child(3)").Click();                  
            return this;
        }
        internal UserManagement SelectOrganization(string filter)
        {
            //open filter
            orgLevelFilter.Hover().Click();

            //select organization
            organizations.ElementAt(20).Click();
            Assert.IsTrue(S(".add-users-button").Displayed);
            return this;
        }
    }
}

