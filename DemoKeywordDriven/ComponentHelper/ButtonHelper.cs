using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement webElement;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(ButtonHelper));
        public static void ClickButton(By locator)
        {
            webElement = GenericHelper.GetElement(locator);
            webElement.Click();
            Logger.Info($"Click {locator}");
           
        }

    }
}
