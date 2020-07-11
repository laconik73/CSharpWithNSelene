using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class AdditionalFieldModal : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement inputText = S("input.form-control");
        IList<IWebElement> checkboxes = SS(".custom-checkbox");
        IList<IWebElement> buttons = SS(".modal-footer button");

        public AdditionalFieldModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal AdditionalFieldModal InputFieldTitle(string text)
        {
            inputText.SendKeys(text);
            return this;
        }       

        internal AdditionalFieldModal MarkRequired()
        {
            checkboxes.ElementAt(9).Click();
            return this;
        }
        internal AdditionalFieldModal SelectService()
        {
            checkboxes.ElementAt(11).Click();
            return this;
        }
        internal ReferralFormConfiguration AddField()
        {
            buttons.ElementAt(1).Click();
            return new ReferralFormConfiguration(DriverContext);
        }
    }
}

