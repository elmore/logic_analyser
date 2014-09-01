using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser.UI.Controllers
{
    [Attributes.UnderTest]
    public class Logic : IAnalysable
    {
        [Attributes.Input(typeof(string), "Input")]
        public Argument _input = new Argument(typeof(string), "Input");

        [Attributes.Input(typeof(bool), "Input2")]
        private Argument _input2 = new Argument(typeof(bool), "Input2");


        [Attributes.Output(typeof(bool), "Output")]
        private Argument _output = new Argument(typeof(bool), "Output");

        [Attributes.Output(typeof(string), "Output2")]
        private Argument _output2 = new Argument(typeof(string), "Output2");

        private void Something(string athing)
        {
            _output2.Set(!string.IsNullOrEmpty(athing));
            _output.Set(_output2.Get().GetType().ToString());
        }

        public void Run()
        {
            Something((string)_input.Get());
        }
    }
}
