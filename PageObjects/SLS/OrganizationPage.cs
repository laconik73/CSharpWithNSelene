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
    public class OrganizationPage : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();



        public OrganizationPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
