using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.Extensions;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class ReferralFormConfiguration : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement addNewFieldButton = S(".add-additional-button");
        IList<IWebElement> requiredFields = SS(By.XPath("//tr//td[4]"));
        SeleneElement tooltip = S("#additional-field-tooltip");
        SeleneElement deleteIcon = S("[data-icon='minus-circle']");
        SeleneElement editIcon = S("[data-icon='pencil-alt']");
        IList <IWebElement> checkboxes = SS(".custom-checkbox");

        public ReferralFormConfiguration(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }        

        internal AdditionalFieldModal AddNewField()
        {
            addNewFieldButton.Hover().Click();
            return new AdditionalFieldModal(DriverContext);
        }

        internal ReferralFormConfiguration VerifyTable()
        {
            
            IList<string> fields = new List<string>();
            foreach (IWebElement element in requiredFields)
            {
                fields.Add(element.ToString());
                Console.WriteLine(element.Text);
            }
            return this;
        }        

        internal ReferralFormConfiguration HoverToTooltip()
        {
            tooltip.Hover().Click();
            return this;
        }

        internal ReferralFormConfiguration DeleteField()
        {
            deleteIcon.Click();
            //confirm action
            S(".btn.btn-warning").Click();
            return this;
        }
        internal EditAdditionalField EditAdditionalField()
        {
            editIcon.Click();
            return new EditAdditionalField(DriverContext);
               
        }
        internal ReferralFormConfiguration SelectDefaultField()
        {
            checkboxes.ElementAt(4).Click();
            return this;
        }
    }
}