using LogicAnalyser.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogicAnalyser.UI.Controllers
{
    public class VisualiserController : Controller
    {
        public ActionResult Index()
        {
            IAnalysable sut = new Logic();

            var anyalsyer = new Analyser(sut);

            Results results = anyalsyer.AllPermutations();

            VisualiserViewModel model = BuildModel(results);

            return View(model);
        }

        private VisualiserViewModel BuildModel(Results results)
        {
            var retval = new VisualiserViewModel();

            foreach(string output in results.Outputs)
            {
                retval.Headings.Add(output);
            }

            foreach(TestResult testCase in results.TestCases)
            {
                var row = new Row { Name = testCase.TestCase.ToString() };

                foreach(string heading in results.Outputs)
                {
                    row.Fields.Add((testCase[heading] ?? string.Empty).ToString());
                }

                retval.Rows.Add(row);
            }

            return retval;
        }
    }
}
