using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class PatientCardsPage : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        IList<IWebElement> patientCards = SS(".patient");


        public PatientCardsPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        internal PatientOverviewPage ChoosePatientCard()
        {
            WaitForNot(spinner, Be.Selected);
            patientCards.ElementAt(0).Click();
            return new PatientOverviewPage(DriverContext);
        }
    }
}

