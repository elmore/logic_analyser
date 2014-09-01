using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using LogicAnalyser.Attributes;

namespace LogicAnalyser
{
    public class SystemContainer : IAnalysable
    {
        private Type _Type;
        private IAnalysable _Sut;

        public SystemContainer(Type testibleType)
        {
            _Type = testibleType;
            _Sut = (IAnalysable)Loader.Instantiate(_Type);
        }

        public void Run()
        {
            _Sut.Run();
        }

        public List<Argument> GetInputs()
        {
            FieldInfo[] info = Loader.GetAttributes<Input>(_Type);

            return info.Select(i => i.GetValue(_Sut) as Argument).ToList();
            //return info.Select(i => WrapField(i.GetValue(_Sut), i.Name)).ToList();
        }

        public List<Argument> GetOutputs()
        {
            FieldInfo[] info = Loader.GetAttributes<Output>(_Type);

            return info.Select(i => i.GetValue(_Sut) as Argument).ToList();
        }

        private Argument WrapField(Type obj, string name)
        {
            return new Argument(obj, name);
        }
    }
}
