using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAnalyser.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Output : System.Attribute, IParameter
    {
        public Type Type { get; private set; }
        public string Name { get; private set; }

        public Output(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
