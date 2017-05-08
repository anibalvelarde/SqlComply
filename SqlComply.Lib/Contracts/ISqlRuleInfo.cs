using Csla.Abstractions.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Contracts
{
    public interface ISqlRuleInfo : IReadOnlyBaseCore
    {
        bool Check(string sqlStatement);
    }
}
