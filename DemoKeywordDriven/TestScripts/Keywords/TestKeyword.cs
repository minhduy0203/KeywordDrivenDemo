using DemoKeywordDriven.ComponentHelper;
using DemoKeywordDriven.Configurations;
using DemoKeywordDriven.ExcelReader;
using DemoKeywordDriven.Interface;
using DemoKeywordDriven.Keyword;
using DemoKeywordDriven.Log4Net;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.TestScripts.Keywords
{
    [TestFixture]
    public class TestKeyword
    {

        private static ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));


       

        [TestCaseSource(nameof(GetTestCases))]
        public void Test2(string testCaseId)
        {
            try
            {
                var keyDataEngine = new DataEngine();
                keyDataEngine.ExecuteScript(ObjectRepository.Config.GetScriptUrl(), "TestSuite", testCaseId);
            }
            catch (Exception e)
            {
                Logger.Error(e.StackTrace);
                throw;
            }

        }

        public static IEnumerable<string> GetTestCases()
        {
            using (var excelUtility = new ExcelReaderHelper(ConfigurationManager.AppSettings[ConfigKeys.ScriptUrl]))
            {
                var TestCases = excelUtility.GetTestCaseRowNo("TestSuite");
                foreach (var testCase in TestCases)
                {
                    yield return testCase.Key;
                }

            }
        }


    }
}
