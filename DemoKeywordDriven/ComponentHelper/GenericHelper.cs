using NUnit.Framework.Internal;
using OpenQA.Selenium;
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

        public static bool IsElemetPresent(By locator)
        {
            try
            {
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
                return ObjectRepository.Driver.FindElement(locator);
            } else
            {
                throw new NoSuchElementException();
            }
            
        }
    }
}
