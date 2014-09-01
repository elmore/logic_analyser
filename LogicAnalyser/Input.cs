using System;
using LogicAnalyser;

namespace LogicAnalyser.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Input : System.Attribute, IParameter
    {
        public string Name { get; private set; }

        public Input(string name)
        {
            Name = name;
        }
    }
}
