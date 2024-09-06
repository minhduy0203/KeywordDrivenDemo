using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.CustomException
{
    public class NoSuchElementException : Exception
    {
        public NoSuchElementException(string msg) : base(msg)
        {
        }

        
    }
}
