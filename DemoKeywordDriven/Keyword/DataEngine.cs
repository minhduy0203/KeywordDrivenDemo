using DemoKeywordDriven.ComponentHelper;
using DemoKeywordDriven.CustomException;
using DemoKeywordDriven.ExcelReader;
using DemoKeywordDriven.Interface;
using DemoKeywordDriven.Log4Net;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.Keyword
{
    internal class DataEngine
    {
        //number of column in excel
        private ILog Logger = Log4NetHelper.GetXmlLogger(typeof(DataEngine));
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameterCol;
        private readonly int _resultCol;
        private readonly int _exceptionCol;

        public DataEngine(int keywordCol = 4, int locatorTypeCol = 5, int locatorValueCol = 6, int parameterCol = 7, int resultCol = 8, int exceptionCol = 9)
        {
            _keywordCol = keywordCol;
            _locatorTypeCol = locatorTypeCol;
            _locatorValueCol = locatorValueCol;
            _parameterCol = parameterCol;
            _resultCol = resultCol;
            _exceptionCol = exceptionCol;
        }
        public By GetElementLocator(string locatorType, string locatorValue)
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
                case "XPath":
                    return By.XPath(locatorValue);
                default:
                    throw new NoSuchLocatorFoundException();

            }
        }

        public void PerformAction(string keyword, string locatorType, string locatorValue, params string[] args)
        {
            switch (keyword)
            {
                case "Click":
                    GenericHelper.Click(GetElementLocator(locatorType, locatorValue));
                    break;
                case "SendKeys":
                    TextBoxHelper.TypeInTextBox(GetElementLocator(locatorType, locatorValue), args[0]);
                    break;
                case "Select":
                    ComboBoxHelper.SelectElementByValue(GetElementLocator(locatorType, locatorValue), args[0]);
                    break;
                case "WaitForEle":
                    //GenericHelper.WaitForWebElementInPage(GetElementLocator(locatorType, locatorValue),
                    //TimeSpan.FromSeconds(50);
                    break;
                case "Navigate":
                    NavigationHelper.NavigateToUrl(args[0]);
                    break;
                case "ClickByLink":
                    LinkHelper.ClickLink(GetElementLocator(locatorType, locatorValue));
                    break;
                default:
                    throw new NoSuchKeywordFoundException("Keyword Not Found : " + keyword);
            }
        }

        public void ExecuteScript(string xlPath, string sheetName, string testCaseId)
        {
            //Testsuite
            using (var excelUtility = new ExcelReaderHelper(xlPath))
            {
                var totalRow = excelUtility.GetTotalRows(sheetName);
                var testCaseRowNo = excelUtility.GetTestCaseRowNo(sheetName);
                var i = testCaseRowNo[testCaseId];
                try
                {
                    if (!excelUtility.IsWorkSheetFound(testCaseId))
                        throw new NotFoundException("Not found worksheet");

                    if (excelUtility.GetCellData(sheetName, i, 1).Equals(string.Empty))
                        return;

                    if (!"Yes".Equals((string)excelUtility.GetCellData(sheetName, i, 4), StringComparison.OrdinalIgnoreCase))
                        return;

                    ExecuteScript(excelUtility, testCaseId);
                    excelUtility.WriteToCell(sheetName, i, 5, "Pass");
                }
                catch (Exception ex)
                {
                    excelUtility.WriteToCell(sheetName, i, 5, "Fail");
                    excelUtility.WriteToCell(sheetName, i, 6, ex.Message);

                    excelUtility.SaveSheet();
                    throw;
                }
                excelUtility.SaveSheet();
            }
        }

        public void ExecuteScript(ExcelReaderHelper excelUtility, string sheetName)
        {
            //Test case steps
            var i = 2;
            while (((string)excelUtility.GetCellData(sheetName, i, 1)).Contains(sheetName))
            {
                try
                {
                    if (string.Empty.Equals(excelUtility.GetCellData(sheetName, i, _keywordCol)))
                        break;

                    string lctType = (string)excelUtility.GetCellData(sheetName, i, _locatorTypeCol);
                    string lctValue = (string)excelUtility.GetCellData(sheetName, i, _locatorValueCol);
                    string keyword = (string)excelUtility.GetCellData(sheetName, i, _keywordCol);
                    string param = (string)excelUtility.GetCellData(sheetName, i, _parameterCol);

                    PerformAction(keyword, lctType, lctValue, param);
                    excelUtility.WriteToCell(sheetName, i, _resultCol, "Pass");

                }
                catch (Exception ex)
                {
                    excelUtility.WriteToCell(sheetName, i, _resultCol, "Fail");
                    excelUtility.WriteToCell(sheetName, i, _exceptionCol, ex.Message);
                    Logger.Error(ex.StackTrace);
                    throw;
                }
                i++;
            }

        }
    }
}
