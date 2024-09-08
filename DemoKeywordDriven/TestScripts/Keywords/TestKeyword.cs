using DemoKeywordDriven.ComponentHelper;
using DemoKeywordDriven.Configurations;
using DemoKeywordDriven.ExcelReader;
using DemoKeywordDriven.Keyword;
using log4net;
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
            ScriptUrl = ConfigurationManager.AppSettings[ConfigKeys.ScriptUrl];
            Logger.Info("Set up script url: " + ScriptUrl ?? "None");

        }

        [Test]
        public void Test2()
        {
            try
            {
                var keyDataEngine = new DataEngine();
                keyDataEngine.ExecuteScript(ScriptUrl, "TestSuite", "TC01");
            }
            catch (Exception e)
            {
                Logger.Error(e.StackTrace);
                throw;

            }

        }


    }
}
