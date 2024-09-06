using DemoKeywordDriven.ComponentHelper;
using DemoKeywordDriven.CustomException;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.Keyword
{
    internal class DataEngine
    {
        //number of column in excel
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameterCol;

        public DataEngine(int keywordCol = 2, int locatorTypeCol = 3, int locatorValueCol = 4, int parameterCol = 5)
        {
            _keywordCol = keywordCol;
            _locatorTypeCol = locatorTypeCol;
            _locatorValueCol = locatorValueCol;
            _parameterCol = parameterCol;
        }
        private By GetElementLocator(string locatorType, string locatorValue)
        {
            switch (locatorType)
            {
                case "ClassName":
                    return By.ClassName(locatorValue);
                case "CssSelector":
                    return By.CssSelector(locatorValue);
                case "Id":
                    return By.Id(locatorValue);
                case "Linktext":
                    return By.LinkText(locatorValue);
                default:
                    return By.Id(locatorValue);


            }
        }

        private void PerformAction(string keyword, string locatorType, string locatorValue, params string[] args)
        {
            switch (keyword)
            {
                case "Click":
                    GenericHelper.GetElement(GetElementLocator(locatorType, locatorValue)).Click();
                    //ButtonHelper.ClickButton(GetElementLocator(locatorType, locatorValue));
                    break;
                case "SendKeys":
                    //TextBoxHelper.TypeInTextBox(GetElementLocator(locatorType, locatorValue), args[0]);
                    break;
                case "Select":
                    //ComboBoxHelper.SelectElementByValue(GetElementLocator(locatorType, locatorValue), args[0]);
                    break;
                case "WaitForEle":
                    //GenericHelper.WaitForWebElementInPage(GetElementLocator(locatorType, locatorValue),
                    TimeSpan.FromSeconds(50));
                    break;
                case "Navigate":
                    ObjectRepository.Driver.Navigate().GoToUrl(args[0]);
                    //NavigationHelper.NavigateToUrl(args[0]);
                    break;
                default:
                    throw new NoSuchKeywordFoundException("Keyword Not Found : " + keyword);
            }
        }
    }
}
