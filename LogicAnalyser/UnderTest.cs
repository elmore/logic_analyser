using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAnalyser.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class UnderTest : System.Attribute
    {
        public UnderTest()
        {

        }
    }
}
