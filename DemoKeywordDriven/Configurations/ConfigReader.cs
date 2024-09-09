using DemoKeywordDriven.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.Configurations
{
    public class ConfigReader : IConfig
    {
        public BrowserType? GetBrowserType()
        {
            string BrowserType = ConfigurationManager.AppSettings[ConfigKeys.Browser];
            return (BrowserType) Enum.Parse(typeof(BrowserType), BrowserType);

        }

        public int GetElementLoadTimeOut()
        {
            string timeOut = ConfigurationManager.AppSettings[ConfigKeys.ElementLoadTimeout] ?? "30";
            return Convert.ToInt32(timeOut);
        }

        public int GetPageLoadTimeOut()
        {
            string timeOut = ConfigurationManager.AppSettings[ConfigKeys.PageLoadTimeout] ?? "30";
            return Convert.ToInt32(timeOut);
        }

        public string GetScriptUrl()
        {
            string ScriptUrl = ConfigurationManager.AppSettings[ConfigKeys.ScriptUrl];
            return ScriptUrl;

        }
    }
}
