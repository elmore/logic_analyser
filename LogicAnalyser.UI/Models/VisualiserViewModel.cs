using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicAnalyser.UI.Models
{
    public class Row
    {
        public string Name = string.Empty;

        public List<string> Fields = new List<string>();
    }

    public class VisualiserViewModel
    {
        public List<string> Headings = new List<string>();

        public List<Row> Rows = new List<Row>();
    }
}
