using DemoKeywordDriven.Log4Net;
using log4net;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ComponentHelper
{
    //use to locate element
    public class GenericHelper
    {
        private static ILog Logger = Log4NetHelper.GetXmlLogger(typeof(GenericHelper));
        public static bool IsElemetPresent(By locator)
        {
            try
            {
                Logger.Info($"Checking Present of Element: {locator}");
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static IWebElement GetElement(By locator)
        {
            if(IsElemetPresent(locator))
            {
                Logger.Info($"Get Element: {locator}");
                return ObjectRepository.Driver.FindElement(locator);
            } else
            {
                throw new NoSuchElementException();
            }
            
        }

        public static WebDriverWait GetWaitDriverElement(TimeSpan timeout)
        {
            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Logger.Info(" Wait Object Created ");
            return wait;
        }
    }
}
