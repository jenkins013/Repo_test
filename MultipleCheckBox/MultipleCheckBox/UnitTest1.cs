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

namespace MultipleCheckBox
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

            IEDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


        }
        [TestMethod]
        public void TestMethod1()
        {
           
            //Navigate to the URL
            IEDriver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form/");
            IEDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //Select radio button for female by ElemenAt method
            IList<IWebElement> radio_btn_sex = IEDriver.FindElements(By.Name("sex"));
            radio_btn_sex.ElementAt(1).Click();
            IEDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //Select profession checkbox
            IList<IWebElement> checkProf = IEDriver.FindElements(By.Name("profession"));
            int proflength = checkProf.Count;
            Console.WriteLine(proflength);
            for (int i = 0; i < proflength; i++)
            {
                if (checkProf.ElementAt(i).GetAttribute("value").Equals("Automation Tester"))
                {
                    checkProf.ElementAt(i).Click();
                    Thread.Sleep(10000);
                    Console.WriteLine("Clicked");
                    break;
                }
            }
            //Automation tool check box select by CSS Selector
            IWebElement autotool = IEDriver.FindElement(By.CssSelector("#tool-2"));
            autotool.Click();
            Thread.Sleep(10000);


        }
     
        [TestCleanup]
        public void Testcleanup()
        {
            IEDriver.Close();
        }
    }
}
