using System;
using System.Collections.Generic;

namespace LogicAnalyser
{
    public interface IArgument
    {
        string Name { get; }

        object Get();

        void Set(object value);

        List<Object> GetVariations();
    }
}
