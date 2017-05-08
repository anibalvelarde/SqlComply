using Csla;
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
    internal sealed class SqlRuleInfo : Csla.Abstractions.Core.ReadOnlyBaseScopeCore<SqlRuleInfo>, ISqlRuleInfo
    {
        private void Child_Fetch(SqlRulePoco data)
        {
                SetReadOnlyProperties(data); 
        }

        private void SetReadOnlyProperties(SqlRulePoco data)
        {
            this.RdbmsType = data.RdbmsType;
            this.Version = data.Version;
            this.AvoidThisSyntax = data.AvoidThis;
            this.UseThisInstead = data.UseThis;
        }
        public bool Check(string sqlString)
        {
            return !sqlString.Contains(this.AvoidThisSyntax);
        }


        public static readonly PropertyInfo<string> RdbmsTypeProperty =
            PropertyInfoRegistration.Register<SqlRuleInfo, string>(_ => _.RdbmsType);
        public string RdbmsType
        {
            get { return this.ReadProperty(SqlRuleInfo.RdbmsTypeProperty); }
            private set { this.LoadProperty(SqlRuleInfo.RdbmsTypeProperty, value); }
        }
        public static readonly PropertyInfo<string> VersionProperty =
            PropertyInfoRegistration.Register<SqlRuleInfo, string>(_ => _.Version);
        public string Version
        {
            get { return this.ReadProperty(SqlRuleInfo.VersionProperty); }
            private set { this.LoadProperty(SqlRuleInfo.VersionProperty, value); }
        }
        public static readonly PropertyInfo<string> AvoidThisSyntaxProperty =
            PropertyInfoRegistration.Register<SqlRuleInfo, string>(_ => _.AvoidThisSyntax);
        public string AvoidThisSyntax
        {
            get { return this.ReadProperty(SqlRuleInfo.AvoidThisSyntaxProperty); }
            private set { this.LoadProperty(SqlRuleInfo.AvoidThisSyntaxProperty, value); }
        }
        public static readonly PropertyInfo<string> UseThisInsteadProperty =
            PropertyInfoRegistration.Register<SqlRuleInfo, string>(_ => _.UseThisInstead);
        public string UseThisInstead
        {
            get { return this.ReadProperty(SqlRuleInfo.UseThisInsteadProperty); }
            private set { this.LoadProperty(SqlRuleInfo.UseThisInsteadProperty, value); }
        }
    }
}
