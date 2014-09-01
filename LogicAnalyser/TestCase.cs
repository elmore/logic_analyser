using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser
{
    public class TestCase : Dictionary<IArgument, Object>
    {
        public void Evaluate()
        {
            foreach(var test in this)
            {
                test.Key.Set(test.Value);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var el in this)
            {
                sb.AppendFormat("({0} : '{1}') ", el.Key, Stringify(el.Value));
            }

            return sb.ToString();
        }

        private string Stringify(object obj)
        {
            return (obj ?? "null").ToString();
        }
    }
}
