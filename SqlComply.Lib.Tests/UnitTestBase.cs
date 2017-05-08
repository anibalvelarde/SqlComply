using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlComply.Lib.Tests
{
    /// <summary>
    /// Summary description for Setup
    /// </summary>
    [TestClass]
    public abstract class UnitTestBase
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private IContainer _anIoCContainer = null;
        protected ContainerBuilder _builder = null;

        protected IContainer MyIoC
        {
            get
            {
                return _anIoCContainer;
            }
        }
        private string NamespaceRootUnderTest
        {
            get
            {
                return "SqlComply.Lib";
            }
        }

        [TestInitialize]
        public void Initialilze()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterModule(new SqlComply.Lib.IoC.SqlComplyModule());

            RegisterMoreTypesInsideATestClass();

            _anIoCContainer = _builder.Build();
        }

        protected abstract void RegisterMoreTypesInsideATestClass();
    }
}
