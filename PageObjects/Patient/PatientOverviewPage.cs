using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;


namespace NowPow.Automation.Features.StepDefinitions

{
    public class PatientOverviewPage : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement documentsSubtab = S(By.Id("documents"));
        SeleneElement referralsSubtab = S(By.Id("referrals"));
        


        public PatientOverviewPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal PatientDocuments OpenDocuments(string subtab)
        {
            documentsSubtab.Click();
            return new PatientDocuments(DriverContext);
        }
    }
}
