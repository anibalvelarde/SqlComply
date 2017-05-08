using Csla;
using Csla.Abstractions.Core;
using Newtonsoft.Json;
using SqlComply.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlComply.Lib.Logic
{
    internal class SqlRuleDataReader : ISqlRuleDataReader
    {
        private const string RULE_DATA_FILE_PATH = @"\Data\data.json";
        private readonly List<SqlRulePoco> _listOfSqlRules;

        public SqlRuleDataReader()
        {
            _listOfSqlRules = GetSqlRuleLst(ReadJsonData());
        }

        private List<SqlRulePoco> GetSqlRuleLst(string data)
        {
            return JsonConvert.DeserializeObject<List<SqlRulePoco>>(data);
        }

    private static string ReadJsonData()
    {
        return File.ReadAllText($@"{AppDomain.CurrentDomain.BaseDirectory}\{RULE_DATA_FILE_PATH}");
    }

    public IEnumerable<SqlRulePoco> SqlRuleData
    {
        get
        {
            return _listOfSqlRules;
        }
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            disposedValue = true;
        }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~SqlRulesReader() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
        // TODO: uncomment the following line if the finalizer is overridden above.
        // GC.SuppressFinalize(this);
    }
    #endregion
}
}
