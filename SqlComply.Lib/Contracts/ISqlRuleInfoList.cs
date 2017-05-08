using Csla.Abstractions.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Contracts
{
    public interface ISqlRuleInfoList : IReadOnlyListBaseCore<ISqlRuleInfo>
    {
        bool Check(string sqlStatement);
        IEnumerable<ISqlRuleInfo> BrokenSqlSyntaxRules { get; }
    }
}
