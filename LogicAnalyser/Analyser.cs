using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser
{
    public class Analyser
    {
        private IAnalysable _system;

        public Analyser(IAnalysable system)
        {
            _system = system;
        }

        public Results AllPermutations()
        {
            List<Argument> inputs = _system.GetInputs();
            List<Argument> outputs = _system.GetOutputs();

            List<TestCase> testCases = MakeTestCases(inputs);

            return RunTestCases(testCases, outputs, inputs);
        }

        private Results RunTestCases(List<TestCase> testCases, List<Argument> outputs, List<Argument> inputs)
        {
            var results = new Results();

            results.Outputs = outputs.Select(o => o.Name).ToList();
            results.Inputs = inputs.Select(o => o.Name).ToList();

            foreach(TestCase test in testCases)
            {
                test.Evaluate();

                _system.Run();

                var testResult = new TestResult();

                testResult.TestCase = test;

                foreach(var outputArg in outputs)
                {
                    testResult.Add(outputArg.Name, outputArg.Get());
                }

                results.TestCases.Add(testResult);
            }

            return results;
        }


        private List<TestCase> MakeTestCases(List<Argument> args, List<TestCase> suite = null, TestCase testCase = null, int depth = 0)
        {
            testCase = testCase ?? new TestCase();

            suite = suite ?? new List<TestCase>();

            if (args.Count > 0)
            {
                var firstArgument = args.First();

                foreach (Object val in firstArgument.GetVariations())
                {
                    if (depth == 0)
                    {
                        // root

                        //testCase = new TestCase();
                    }

                    testCase.Add(firstArgument, val);

                    MakeTestCases(args.Skip(1).ToList(), suite, testCase, depth + 1);

                    testCase = new TestCase();
                }
            }
            else
            {
                // leaf
                suite.Add(testCase);
            }

            return suite;
        }

    }
}
