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
    public class LoginPage : ProjectPageBase

    { 
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement emailTextbox = S("#inputEmail");
        SeleneElement nextButton = S("#btn-next");
        SeleneElement passwordTextbox = S("#inputPassword");
        SeleneElement signInButton = S("#btn-signin");
       
        

        public LoginPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }       
                   
        internal LoginPage GoTo()
        {
            var url = BaseConfiguration.GetUrlValue;
            this.Driver.NavigateTo(new Uri(url));
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            return this;
        }
        internal LoginPage EnterEmail(string email)
        {
            emailTextbox.SendKeys(email);
            return this;
        }
        internal LoginPage Submit()
        {
            nextButton.Click();
            return this;
        }

        internal LoginPage EnterPassword(string password)
        {
            passwordTextbox.SendKeys(password);
            return this;
        }        
        internal DashboardPage SignIn()
        {
            signInButton.Click();
            return new DashboardPage(DriverContext);
        }       
       
    }

}


