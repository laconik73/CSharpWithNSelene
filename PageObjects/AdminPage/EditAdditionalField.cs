using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class EditAdditionalField : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement inputText = S(By.ClassName("form-control"));
        IList<IWebElement> checkboxes = SS(".custom-checkbox");
        IList<IWebElement> buttons = SS(".modal-footer button");

        public EditAdditionalField(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal EditAdditionalField EditTitle()
        {
            inputText.Clear().SendKeys("edit test");
            return this;
        }

        internal EditAdditionalField EditService()
        {
            checkboxes.ElementAt(10).Click();
            return this;
        }

        internal ReferralFormConfiguration EditField()
        {
            buttons.ElementAt(1).Click();
            return new ReferralFormConfiguration(DriverContext);
        }
    }
}

