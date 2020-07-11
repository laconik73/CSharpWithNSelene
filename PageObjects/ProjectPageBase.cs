namespace NowPow.Automation.PageObjects
{
    using NSelene;
    using OpenQA.Selenium;
    using static NSelene.Selene;
    using Ocaramba;

    public partial class ProjectPageBase
    {
        protected SeleneElement smallSpinner = S("#spinnerSmall");
        protected SeleneElement spinner = S("#spinner");        
        
        public ProjectPageBase(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;
            //Driver.Manage().Window.Size = new System.Drawing.Size(1680, 1050);
            Driver.Manage().Window.Maximize();
        }
        protected IWebDriver Driver { get; set; }
        public DriverContext DriverContext { get; set; }
             
    }

}
