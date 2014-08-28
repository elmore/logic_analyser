using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAnalyser.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Input : System.Attribute
    {
        public Input(Type type, string name)
        {

        }
    }
}
