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

        public List<IArgument> GetInputs()
        {
            FieldInfo[] info = Loader.GetFields<Input>(_Type);

            //return info.Select(i => i.GetValue(_Sut) as IArgument).ToList();
            return info.Select(WrapField<Input>).ToList();
        }

        public List<IArgument> GetOutputs()
        {
            FieldInfo[] info = Loader.GetFields<Output>(_Type);

            //return info.Select(i => i.GetValue(_Sut) as IArgument).ToList();
            return info.Select(WrapField<Output>).ToList();
        }

        private IArgument WrapField<T>(FieldInfo field) where T : IParameter
        {
            var attributes = Loader.GetAttributes<T>(field).FirstOrDefault();

            return new Proxy(attributes.Name, field, _Sut);
        }
    }
}
