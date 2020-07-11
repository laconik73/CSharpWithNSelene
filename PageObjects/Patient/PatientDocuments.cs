using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using AutoIt;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class PatientDocuments : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement uploadDocumentsButton = S(By.Id("btn-add-document"));
        SeleneElement chooseFile = S(By.Id("btn-choose-file"));
        SeleneElement uploadButton = S("#btn-add");

        public PatientDocuments(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        internal PatientDocuments ClickUploadDocuments()
        {
            WaitForNot(S(By.Id("patientDocumentAddModal-container")), Be.InDom);
            uploadDocumentsButton.Click();
            return new PatientDocuments(DriverContext);
        }

        internal PatientDocuments ChooseVirusFile(string documents)
        {
             try
            {
                chooseFile.Click();
            }
            catch(Exception)
            {
                chooseFile.Click();
            }
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX.WinActivate("Open");
            AutoItX.Send("C:\\Users\\sabina.dovlati\\Desktop\\eicar.txt");
            Thread.Sleep(1000);
            AutoItX.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return new PatientDocuments(DriverContext);
        }

        internal PatientDocuments ChooseLargeFile(string documents)
        {
            try
            {
                chooseFile.Click();
            }
            catch (Exception)
            {
                chooseFile.Click();
            }
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX.WinActivate("Open");
            AutoItX.Send("C:\\Users\\sabina.dovlati\\Desktop\\Over4MB.pdf");
            Thread.Sleep(1000);
            AutoItX.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return new PatientDocuments(DriverContext);
        }

        internal PatientDocuments ChooseFile()
        {
            try
            {
                chooseFile.Click();
            }
            catch(Exception)
            {
                chooseFile.Click();
            }
           
            Thread.Sleep(1000);
            //AutoIT= Handles Windows that do not belong to browser.
            AutoItX.WinActivate("Open");
            AutoItX.Send("C:\\Users\\sabina.dovlati\\Desktop\\Scale.pdf");
            Thread.Sleep(1000);
            AutoItX.Send(@"{ENTER}");
            Thread.Sleep(1000);
            return new PatientDocuments(DriverContext);
        }

        internal PatientDocuments Upload()
        {
            uploadButton.Click();
            return new PatientDocuments(DriverContext);
        }
    }
}
