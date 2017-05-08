using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Tests
{
    public static class Sql2016SyntaxShowStopperExamples
    {
        public static string FAST_FIRST_ROW = 
            @"SELECT DISTINCT
              c.Name AS [Client Name]
            , s.Name AS [Contract Name]
            , (SELECT TOP 1 iee.Name
                FROM dbo.Market m WITH (FASTFIRSTROW, NOLOCK)";
    }
}
