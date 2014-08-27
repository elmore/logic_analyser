using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser
{
    public class TestResult : Dictionary<string, Object>
    {
        public TestCase TestCase { get; set; }
    }
}
