using DemoKeywordDriven.ComponentHelper;
using DemoKeywordDriven.Configurations;
using DemoKeywordDriven.ExcelReader;
using DemoKeywordDriven.Interface;
using DemoKeywordDriven.Keyword;
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

        private string ScriptUrl;
        private static ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));


        [SetUp]
        public void SetUp()
        {
            try
            {
                ScriptUrl = ConfigurationManager.AppSettings[ConfigKeys.ScriptUrl];
                Logger.Info("Set up script url: " + ScriptUrl ?? "None");
            }
            catch (Exception)
            {
                Logger.Error(e.StackTrace);
                throw;
            }
          

        }

        [TestCaseSource(nameof(GetTestCases))]
        public void Test2(string testCaseId)
        {
            try
            {
                var keyDataEngine = new DataEngine();
                keyDataEngine.ExecuteScript(ScriptUrl, "TestSuite", testCaseId);
            }
            catch (Exception e)
            {
                Logger.Error(e.StackTrace);
                throw;

            }

        }


        public static IEnumerable<string> GetTestCases()
        {
            string ScriptUrl = ConfigurationManager.AppSettings[ConfigKeys.ScriptUrl];
            using (var excelUtility = new ExcelReaderHelper(ScriptUrl))
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
