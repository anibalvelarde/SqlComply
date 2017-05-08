using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Contracts
{
    public class SqlRulePoco
    {
        public string RdbmsType { get; set; }
        public string Version { get; set; }
        public string AvoidThis { get; set; }
        public string UseThis { get; set; }
    }
}
