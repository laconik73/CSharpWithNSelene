


namespace Ocaramba.Tests.PageObjects
{
    using Ocaramba;
    using OpenQA.Selenium;

    public partial class ProjectPageBase
    {
        public ProjectPageBase(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;
            //Driver.Manage().Window.Size = new System.Drawing.Size(1680, 1050);
            Driver.Manage().Window.Maximize();
        }

        protected IWebDriver Driver { get; set; }

        public ProjectPageBase()
        {

        }
        protected DriverContext DriverContext { get; set; }
    }
}
