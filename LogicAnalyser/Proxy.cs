using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LogicAnalyser
{
    public class Proxy : IArgument
    {
        private FieldInfo _Field;
        private Object _Obj;

        public string Name { get; private set; }

        public Proxy(string name, FieldInfo field, Object obj)
        {
            _Field = field;

            _Obj = obj;

            Name = name;
        }

        public object Get()
        {
            return _Field.GetValue(_Obj);
        }

        public void Set(object value)
        {
            _Field.SetValue(_Obj, value);
        }

        public List<Object> GetVariations()
        {
            if (_Field.FieldType == typeof(Boolean))
            {
                return new List<Object> { true, false };
            }

            if (_Field.FieldType == typeof(String))
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
