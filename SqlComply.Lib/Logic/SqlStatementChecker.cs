using Csla;
using Csla.Abstractions.Attributes;
using Csla.Abstractions.Core.Contracts;
using Csla.Abstractions.Utils;
using SqlComply.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Logic
{
    [Serializable]
    internal sealed class SqlStatementChecker : Csla.Abstractions.Core.ReadOnlyBaseScopeCore<SqlStatementChecker>, ICheckSqlStatement
    {
        [NonSerialized]
        IObjectPortal<SqlRuleInfoList> _sqlRuleListPortal;


        private void DataPortal_Create()
        {
            this.Rules = this.SqlRuleListPortal.Fetch();
        }

        public IEnumerable<string> Issues
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool Check(string aSqlToParse)
        {
            this.SqlStatement = aSqlToParse;
            return this.Rules.Check(aSqlToParse);
        }

        public static readonly PropertyInfo<string> SqlStatementProperty =
            PropertyInfoRegistration.Register<SqlStatementChecker, string>(_ => _.SqlStatement);
        public string SqlStatement
        {
            get { return this.ReadProperty(SqlStatementChecker.SqlStatementProperty); }
            private set { this.LoadProperty(SqlStatementChecker.SqlStatementProperty, value); }
        }
        private ISqlRuleInfoList Rules { get; set; }


        [Dependency]
        internal IObjectPortal<SqlRuleInfoList> SqlRuleListPortal
        {
            private get { return _sqlRuleListPortal; }
            set { _sqlRuleListPortal = value; }
        }
    }
}
