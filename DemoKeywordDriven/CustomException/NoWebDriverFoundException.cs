using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.CustomException
{
    public class NoWebDriverFoundException : Exception
    {
        public NoWebDriverFoundException()
        {
        }

        public NoWebDriverFoundException(string message) : base(message)
        {

        }


    }
}
