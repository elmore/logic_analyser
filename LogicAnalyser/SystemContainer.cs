using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser
{
    public class SystemContainer : IAnalysable
    {
        private IAnalysable _Sut;

        public SystemContainer(IAnalysable sut)
        {
            _Sut = sut;

        }

        public void Run()
        {
            _Sut.Run();
        }

        public List<Argument> GetInputs()
        {
            return _Sut.GetInputs();
        }

        public List<Argument> GetOutputs()
        {
            return _Sut.GetOutputs();
        }
    }
}
