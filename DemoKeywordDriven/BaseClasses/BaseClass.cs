using DemoKeywordDriven.ComponentHelper;
using log4net;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.TestScripts.Keywords
{

    [SetUpFixture]
    public class BaseClass
    {
        private static ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));

        [OneTimeSetUp]
        public void SetUp()
        {
            ObjectRepository.Driver = new ChromeDriver();
            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
            Logger.Info("Open driver");
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
                Logger.Info("Close driver");
            }
        }
    }
}
