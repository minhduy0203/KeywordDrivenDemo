using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.CustomException
{
    public class NoSuchLocatorFoundException : Exception
    {
        public NoSuchLocatorFoundException()
        {
        }

        public NoSuchLocatorFoundException(string? message) : base(message)
        {
        }
    }
}
