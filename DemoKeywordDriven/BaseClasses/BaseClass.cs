using DemoKeywordDriven.ComponentHelper;
using DemoKeywordDriven.Configurations;
using DemoKeywordDriven.CustomException;
using DemoKeywordDriven.Interface;
using DemoKeywordDriven.Log4Net;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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

        private ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            return driver;
        }

        private FirefoxDriver GetFireFoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver();
            return driver;
        }

        private EdgeDriver GetEdgeDriver()
        {
            EdgeDriver driver = new EdgeDriver();
            return driver;
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            //Set up environment for testing 
            ObjectRepository.Config = new ConfigReader();
            switch (ObjectRepository.Config.GetBrowserType())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    Logger.Info("Using Chrome Driver");

                    break;
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFireFoxDriver();
                    Logger.Info("Using Firefox Driver");
                    break;
                case BrowserType.Edge:
                    ObjectRepository.Driver = GetEdgeDriver();
                    Logger.Info("Using Edge Driver");
                    break;
                default:
                    throw new NoWebDriverFoundException();

            }

            if (ObjectRepository.Config.GetScriptUrl() != null)
            {
                Logger.Info($"Using Script at: {ObjectRepository.Config.GetScriptUrl()}");
            }
            else
            {
                Logger.Info($"No Script found");

            }

            ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();

            //define implicit timeout
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
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
