using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ComponentHelper
{
    public class LinkHelper
    {
        public static IWebElement webElement;
        public static void ClickLink(By locator)
        {
            webElement = GenericHelper.GetElement(locator);
            webElement.Click(); 
        }
    }
}
