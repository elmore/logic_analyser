using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser
{
    public class Analyser
    {
        private SystemContainer _system;

        public Analyser(SystemContainer system)
        {
            _system = system;
        }

        public Results AllPermutations()
        {
            List<IArgument> inputs = _system.GetInputs();
            List<IArgument> outputs = _system.GetOutputs();

            List<TestCase> testCases = MakeTestCases(inputs);

            return RunTestCases(testCases, outputs, inputs);
        }

        private Results RunTestCases(List<TestCase> testCases, List<IArgument> outputs, List<IArgument> inputs)
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

                foreach (IArgument outputArg in outputs)
                {
                    testResult.Add(outputArg.Name, outputArg.Get());
                }

                results.TestCases.Add(testResult);
            }

            return results;
        }

        /// <summary>
        /// This is a recursing method which takes a list which is effectively a multi-dimensional array. It treats it as 
        /// a tree structure which defines all possible combinations of test cases. It flattens the structure to a list 
        /// with an element per valid path through the tree.
        /// </summary>
        /// <param name="args">a list of the arguments that need to be permutated to get all possible test cases</param>
        /// <returns>a flat list of the TestCases that need to be run</returns>
        private List<TestCase> MakeTestCases(List<IArgument> args)
        {
            // new list for each layer of the tree
            List<TestCase> nt = new List<TestCase>();

            // represents a real node. 
            // if the list is empty then we have dropped off the bottom
            if (args.Count > 0)
            {
                // this is essentially just popping the firstArgument off the 
                // args list..
                var firstArgument = args.First();

                // ... leaving remainingArguments as everything else
                var remainingArguments = args.Skip(1).ToList();

                // ask the argument for the possible variations eg for a bool it 
                // will return the list new { true, false }
                foreach (Object val in firstArgument.GetVariations())
                {
                    // get the test case list from lower nodes. there is a test 
                    // case per path to a leaf. if nothing is below this will 
                    // return a list with one empty test case.
                    List<TestCase> subNodes = MakeTestCases(remainingArguments);

                    // for each path add in this node to the test case. we are 
                    // working back up the tree
                    foreach (TestCase tc in subNodes)
                    {
                        tc.Add(firstArgument, val);
                    }

                    // add the paths to our collection
                    nt.AddRange(subNodes);
                }
            }
            // if the list is empty we want to create a TestCase and return it 
            // since this represents one valid path through the tree.
            else
            {
                nt.Add( new TestCase() );
            }

            // always return a list even if its a single test case as in the case of
            // dropping off the bottom of the tree
            return nt;
        }

    }
}
