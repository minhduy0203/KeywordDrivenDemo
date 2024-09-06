using DemoKeywordDriven.ExcelReader;
using DemoKeywordDriven.Keyword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.TestScripts.Keywords
{

    public class TestKeyword
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test2()
        {
          
            var keyDataEngine = new DataEngine();
            keyDataEngine.ExecuteScript(@"C:\Users\PC\Desktop\Keyword2.xlsx", "TestSuite", "TC01");

            //Assert.Pass();
        }
    }
}
