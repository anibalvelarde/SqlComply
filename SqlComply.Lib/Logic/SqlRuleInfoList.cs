using Csla.Abstractions;
using Csla.Abstractions.Attributes;
using Csla.Abstractions.Core.Contracts;
using SqlComply.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Logic
{
    [Serializable]
    internal sealed class SqlRuleInfoList : Csla.Abstractions.Core.ReadOnlyListBaseScopeCore<SqlRuleInfoList, ISqlRuleInfo>, ISqlRuleInfoList
    {
        [NonSerialized]
        ISqlRuleDataReader _sqlRuleReaderPortal;
        [NonSerialized]
        IObjectPortal<SqlRuleInfo> _sqlRuleInfoPortal;
        private readonly List<ISqlRuleInfo> _brokenRules;

        public SqlRuleInfoList()
        {
            _brokenRules = new List<ISqlRuleInfo>();
        }

        private void DataPortal_Fetch()
        {
            LoadListItems();
        }

        public bool Check(string sqlStatement)
        {
            foreach (var rule in this)
            {
                if(!rule.Check(sqlStatement))
                {
                    _brokenRules.Add(rule);
                }
            }
            return _brokenRules.Count.Equals(0);
        }
        public IEnumerable<ISqlRuleInfo> BrokenRules
        {
            get { return _brokenRules; }
        }
        private void LoadListItems()
        {
            IsReadOnly = false;
            RaiseListChangedEvents = false;

            using (var reader = this.SqlRuleReader)
            {
                foreach (var rule in reader.SqlRuleData)
                {
                    Add(this.SqlRuleInfoPortal.FetchChild(rule));
                }
            }

            RaiseListChangedEvents = true;
            IsReadOnly = true;
        }
        
        [Dependency]
        internal IObjectPortal<SqlRuleInfo> SqlRuleInfoPortal
        {
            private get { return _sqlRuleInfoPortal; }
            set { _sqlRuleInfoPortal = value; }
        }
        [Dependency]
        internal ISqlRuleDataReader SqlRuleReader
        {
            private get { return _sqlRuleReaderPortal; }
            set { _sqlRuleReaderPortal = value; }
        }
    }
}
