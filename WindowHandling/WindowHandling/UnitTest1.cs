using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace WindowHandling
{
    [TestClass]
    public class UnitTest1
    {
        InternetExplorerOptions options = new InternetExplorerOptions();

        IWebDriver IEDriver = null;
        [TestInitialize]
        public void initialize()
        {
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IEDriver = new InternetExplorerDriver(options);

            IEDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));


        }
        [TestMethod]
        public void TestMethod1()
        {
            //Navigate to the URL
            IEDriver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-switch-windows/");
            IEDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            IEDriver.Manage().Window.Maximize();
            string parentwindow = IEDriver.CurrentWindowHandle;
            Console.WriteLine("parent window value is " + parentwindow);
            IWebElement newbrowserwindow = IEDriver.FindElement(By.Id("button1"));
            newbrowserwindow.Click();
            Thread.Sleep(5000);
            IEDriver.SwitchTo().Window(IEDriver.WindowHandles.Last());
            IEDriver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            IEDriver.Navigate().GoToUrl("http://google.com");
            Thread.Sleep(10000);
            IEDriver.Close();
            Thread.Sleep(10000);
            IEDriver.SwitchTo().Window(parentwindow);
            ////This will open 3 new browser window
            //for (int i = 0; i < 3; i++)
            //{
            //    //clicking on New Browser button
            //    newbrowserwindow.Click();
            //    Console.WriteLine(i);
            //    Thread.Sleep(5000);
            //}
            ////store all the open window in a list
            //IList<string> windowvalues = IEDriver.WindowHandles.ToList();
            ////print each and every items of the list
            //foreach(string windowvalue in windowvalues )
            //{
            //    Console.WriteLine(windowvalue);
            //    //switch to desired window
            //    IEDriver.SwitchTo().Window(windowvalue);
            //    //Navigate to google
            //    IEDriver.Navigate().GoToUrl("http://google.com");
            //}
        }
        [TestCleanup]
        public void Testcleanup()
        {
            IEDriver.Close();
        }
    }
}
