using System;
using LogicAnalyser;

namespace LogicAnalyser.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Input : System.Attribute, IParameter
    {
        public Type Type { get; private set; }
        public string Name { get; private set; }

        public Input(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
