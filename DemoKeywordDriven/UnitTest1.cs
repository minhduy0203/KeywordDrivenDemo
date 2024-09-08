using DemoKeywordDriven.ComponentHelper;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System.Configuration;

namespace DemoKeywordDriven
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            string test = ConfigurationManager.AppSettings["TestKey"];
        }

        [Test]
        public void Test1()
        {


            Assert.Pass();
        }
    }
}