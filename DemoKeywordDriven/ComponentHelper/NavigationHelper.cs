using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ComponentHelper
{
    public class NavigationHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetLogger(typeof(NavigationHelper));
        public static void NavigateToUrl(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
            Logger.Info("Navigate to " + url);
        }
    }
}
