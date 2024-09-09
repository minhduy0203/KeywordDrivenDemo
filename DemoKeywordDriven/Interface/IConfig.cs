using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoKeywordDriven.Configurations;

namespace DemoKeywordDriven.Interface
{
    public interface IConfig
    {

        public abstract BrowserType? GetBrowserType();
        public abstract int GetElementLoadTimeOut();
        public abstract int GetPageLoadTimeOut();

        public abstract string GetScriptUrl();
       
    }
}
