using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser.UI.Controllers
{
    public class Logic : IAnalysable
    {
        private Argument _input = new Argument(typeof(string), "Input");
        private Argument _input2 = new Argument(typeof(bool), "Input2");
        private Argument _output = new Argument(typeof(bool), "Output");

        private bool Something(string athing)
        {
            return !string.IsNullOrEmpty(athing);
        }

        public void Run()
        {
            _output.Set(Something((string)_input.Get()));
        }

        public List<Argument> GetInputs()
        {
            return new List<Argument> { _input, _input2 };
        }

        public List<Argument> GetOutputs()
        {
            return new List<Argument> { _output };
        }
    }
}
