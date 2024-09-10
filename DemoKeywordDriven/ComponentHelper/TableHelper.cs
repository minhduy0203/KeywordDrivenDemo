using DemoKeywordDriven.Log4Net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ComponentHelper
{
    internal class TableHelper
    {
        private static IWebElement webElement;
        private static readonly log4net.ILog Logger = Log4NetHelper.GetXmlLogger(typeof(TableHelper));

        public static void VerifyTableRow(By locator, int index, string[] verifyContent)
        {
            webElement = GenericHelper.GetElement(locator);
            var rows = webElement.FindElements(By.TagName("tr"));
            if (index >= rows.Count)
            {
                Logger.Error(new ArgumentOutOfRangeException("Index is out of range of table rows"));
                throw new ArgumentOutOfRangeException("Index is out of range of table rows");
            }

            var columns = rows[index].FindElements(By.TagName("td"));
            for (int i = 0; i < columns.Count; i++)
            {
                Assert.Equals(columns[i].Text.ToLower(), verifyContent[i].ToLower());
            }
        }

        public static void VerifyTableData(By locator, string[][] verifyContent)
        {
            webElement = GenericHelper.GetElement(locator);
            var rows = webElement.FindElements(By.TagName("tr"));
            for (int i = 0; i < rows.Count; i++)
            {
                VerifyTableRow(locator, i, verifyContent[i]);
            }
        }
    }
}
