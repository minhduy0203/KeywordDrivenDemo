using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ComponentHelper
{
    public class TextBoxHelper
    {

        public static IWebElement webElement;
        private static ILog Logger = Log4NetHelper.GetLogger(typeof(TextBoxHelper));
        public static void TypeInTextBox(By locator, string text)
        {
            webElement = GenericHelper.GetElement(locator);
            webElement.SendKeys(text);
            Logger.Info($" Type in Textbox @ {locator} : value : {text}");
        }

        public static void ClearTextBox(By locator)
        {
            webElement = GenericHelper.GetElement(locator);
            webElement.Clear();
            Logger.Info($" Clear Textbox @ {locator}");
        }
    }
}
