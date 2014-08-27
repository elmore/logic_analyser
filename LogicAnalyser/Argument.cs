using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser
{
    public class Argument
    {
        private object _anything;
        private Type _type;

        public string Name { get; private set; }

        public Argument(Type type, string name)
        {
            _anything = null;

            _type = type;

            Name = name;
        }

        public object Get()
        {
            return _anything;
        }

        public void Set(object value)
        {
            _anything = value;
        }

        public List<Object> GetVariations()
        {
            if (_type == typeof(Boolean))
            {
                return new List<Object> { true, false };
            }

            if (_type == typeof(String))
            {
                return new List<Object> { "", "test", null };
            }

            return new List<Object>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
