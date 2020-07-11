using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using Nowpow.Automation.Features.StepDefinitions;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class TabsNavigationPage : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement patientTab = S("[data-link*='patients'][type]");
        SeleneElement adminTab = S("a[id='nav-item-admin'][type]");

        public TabsNavigationPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        internal PatientCardsPage OpenPatient(string tabName)
        {
            //patientTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-patients") : S(".inset-nav #nav-item-patients");
            //ClickNavigationLink(patientTab);
            //WaitFor(S("#count-top"), Be.Visible);
            patientTab.Click();
            return new PatientCardsPage(DriverContext);
        }

        internal AdminPage OpenAdmin(string tabName)
        {
            adminTab.Click();
            return new AdminPage(DriverContext);
        }
    }
}
