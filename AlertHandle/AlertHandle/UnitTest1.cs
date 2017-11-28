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

            IEDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));


        }
        [TestMethod]
        public void TestMethod1()
        {

            //Navigate to the URL
            IEDriver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            IEDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            IEDriver.Manage().Window.Maximize();
            //Click on jS alert....check for simple alert which contains only an OK button.
            IWebElement jsAlert = IEDriver.FindElement(By.XPath("//*[@id='content']/div/ul/li[1]/button"));
            jsAlert.Click();
            //wait for 10 seconds to see the alert message
            Thread.Sleep(10000);
            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = IEDriver.SwitchTo().Alert();

            

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();

            Thread.Sleep(10000);
            //Click on jS confirm alert....check for confirmation alert which contains only an OK and Cancel button.
            IWebElement jsconfirmAlert = IEDriver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button"));
            jsconfirmAlert.Click();
            Thread.Sleep(10000);
            // Switch the control of 'driver' to the Alert from main Window
            IAlert confirmAlert = IEDriver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String confirmText = confirmAlert.Text;
            Console.WriteLine("Alert text is " + confirmText);

            // '.Dismiss()' is used to accept the alert '(click on the Ok button)'
            confirmAlert.Dismiss();

            //Click on jS confirm alert....check for prompt alert which contains only an OK and Cancel button with text field.
            IWebElement jspromptAlert = IEDriver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button"));
            jspromptAlert.Click();
            Thread.Sleep(10000);
            // Switch the control of 'driver' to the Alert from main Window
            IAlert promtAlert = IEDriver.SwitchTo().Alert();
            promtAlert.SendKeys("Accepting the alert");
            Thread.Sleep(10000);
            // '.Text' is used to get the text from the Alert
            String promptText = promtAlert.Text;
            Console.WriteLine("Alert text is " + promptText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            promtAlert.Accept();



        }

        [TestCleanup]
        public void Testcleanup()
        {
            IEDriver.Close();
        }
    }
}
