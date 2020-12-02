using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class ThreatDescriber
    {
        public string FieldName { get; set; }
        public string Field { get; set; }

        public ThreatDescriber(string fieldName, string field)
        {
            FieldName = fieldName;
            Field = field;
        }
    }
}
