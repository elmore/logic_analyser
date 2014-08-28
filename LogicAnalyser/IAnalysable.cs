﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicAnalyser
{
    public interface IAnalysable
    {
        void Run();
        List<Argument> GetInputs();
        List<Argument> GetOutputs();
    }
}