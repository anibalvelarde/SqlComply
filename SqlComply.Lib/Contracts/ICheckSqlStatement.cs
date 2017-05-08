using Csla.Abstractions.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Contracts
{
    public interface ICheckSqlStatement : IReadOnlyBaseCore
    {
        string SqlStatement { get; }
        bool Check(string aSqlToParse);
        IEnumerable<string> Issues { get; }
    }
}
