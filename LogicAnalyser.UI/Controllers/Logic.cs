using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser.UI.Controllers
{
    [Attributes.UnderTest]
    public class Logic : IAnalysable
    {
        [Attributes.Input("Input")]
        public string _input = "";

        [Attributes.Input("Input2")]
        private bool _input2 = false;

        [Attributes.Output("Output")]
        private string _output = "";

        [Attributes.Output("Output2")]
        private bool _output2 = false;

        private void Something(string athing)
        {
            _output2 = !string.IsNullOrEmpty(athing);
            _output = _output2.ToString();
        }

        [Attributes.EntryPoint]
        public void Run()
        {
            Something(_input);
        }

    }
}
