using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csla.Abstractions;
using Spackle.Extensions;
using Csla;
using Autofac;
using Moq;
using SqlComply.Lib.Contracts;
using System.Collections.Generic;
using SqlComply.Lib.Logic;

namespace SqlComply.Lib.Tests
{

    [TestClass]
    public class SqlRuleTests : UnitTestBase
    {
        private Mock<ISqlRuleDataReader> _mockSqlRuleReader = new Mock<ISqlRuleDataReader>(MockBehavior.Strict);

        [TestMethod]
        public void Should_BeCorrect_When_ReadingLocalJsonDataFile()
        {
            // Arrange...

            // Act...
            using (var reader = new SqlRuleDataReader())
            {
                // Assert...
                foreach (var rule in reader.SqlRuleData)
                {
                    Assert.IsInstanceOfType(rule, typeof(SqlRulePoco));
                }
            }
        }

        [TestMethod]
        public void Shoul_BeCorrect_When_FetchingListOfSqlRules()
        {
            // Arrange...
            using (new ObjectActivator(this.MyIoC).Bind(() => ApplicationContext.DataPortalActivator))
            {
                // Act...
                var sqlRules = new ObjectPortal<ISqlRuleInfoList>().Fetch();

                // Assert...
                Assert.IsTrue(sqlRules.Count > 0);

                // Verify...
                _mockSqlRuleReader.VerifyAll();
            }
        }

        protected override void RegisterMoreTypesInsideATestClass()
        {
            _mockSqlRuleReader.Setup(_ => _.SqlRuleData).Returns(MakeFakeSqlRuleData());
            _mockSqlRuleReader.Setup(_ => _.Dispose());
            _builder.RegisterInstance<ISqlRuleDataReader>(_mockSqlRuleReader.Object);
        }

        private IEnumerable<SqlRulePoco> MakeFakeSqlRuleData()
        {
            var aList = new List<SqlRulePoco>();
            aList.Add(new SqlRulePoco() { RdbmsType = "SqlServer", Version = "2016", AvoidThis = "FIRSTFASTROW", UseThis = "THIS_OTHER" });
            return aList;
        }
    }
}
