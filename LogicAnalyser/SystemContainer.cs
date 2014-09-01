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
            FieldInfo[] info = Loader.GetFields<Input>(_Type);

            return info.Select(i => i.GetValue(_Sut) as Argument).ToList();
            //return info.Select(WrapField).ToList();
        }

        public List<Argument> GetOutputs()
        {
            FieldInfo[] info = Loader.GetFields<Output>(_Type);

            return info.Select(i => i.GetValue(_Sut) as Argument).ToList();
        }

        //private Argument WrapField(FieldInfo field)
        //{
        //    var attributes = field.GetCustomAttributes(true).OfType<Input>();


        //    attributes.First().


        //    var arg = new Argument(inputField.Type, inputField.Name);

        //    arg.Set(field.GetValue(_Sut));

        //    return arg;
        //}
    }
}
