using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csla.Abstractions;
using SqlComply.Lib.Contracts;
using Spackle.Extensions;
using Csla;
using Autofac;

namespace SqlComply.Lib.Tests
{
    [TestClass]
    public class SqlStatementCheckerTests : UnitTestBase
    {
        [TestMethod]
        public void Should_BeCorrect_When_ParsingACorrectSqlStatement()
        {
            // Arrange...
            var aSqlToParse = "select * from dbo.Table1";

            using (new ObjectActivator(this.MyIoC).Bind(() => ApplicationContext.DataPortalActivator))
            {
                var sqlChecker = new ObjectPortal<ICheckSqlStatement>().Create();

                // Act...
                var sqlCheckResult = sqlChecker.Check(aSqlToParse);

                // Assert...
                Assert.IsTrue(sqlCheckResult);
            }
        }

        [TestMethod]
        public void Should_BeBrokenRule_When_Detecting_FASTFIRSTROW_Violation()
        {
            // Arrange...
            var aSqlToParse = Sql2016SyntaxShowStopperExamples.FAST_FIRST_ROW;

            using (new ObjectActivator(this.MyIoC).Bind(() => ApplicationContext.DataPortalActivator))
            {
                var sqlChecker = new ObjectPortal<ICheckSqlStatement>().Create();

                // Act...
                var sqlCheckResult = sqlChecker.Check(aSqlToParse);
              
                // Assert...
                Assert.IsFalse(sqlCheckResult);
            }
        }

        protected override void RegisterMoreTypesInsideATestClass()
        {
            // nothing to register in this test (yet...)
        }
    }
}
