using Csla.Serialization.Mobile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlComply.Lib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SqlComply.Lib.Tests
{
    /// <summary>
    /// Class to test if a CSLA business object is correctly decorated with all the mandatory attributes.
    /// </summary>
    [TestClass]
    public class SerializationTests
    {
        // Add other excluded types here...
        List<string> _excludedTypes = new List<string> { "PropertyInfoRegistration" };

        [TestMethod]
        public void BusLogicClass_Should_BeSerializable_When_ImplementingIMobileInterface()
        {
            // Arrange..
            var type = typeof(IMobileObject);
            IEnumerable<Type> availableConcreteTypes;

            // Act..
            Assembly curAsm = typeof(ICheckSqlStatement).Assembly;
            availableConcreteTypes = curAsm.GetTypes().Where(t => type.IsAssignableFrom(t) & !t.IsInterface & !t.IsAbstract);

            // Assert..
            foreach (Type item in availableConcreteTypes)
            {
                if (!InExcludedTypes(item))
                {
                    Assert.IsTrue(item.IsSerializable, string.Format("The Type[{0}] is not marked as serializable. Namespace: [{1}].", item.Name, item.Namespace));
                }
            }
        }

        private bool InExcludedTypes(Type t)
        {
            return _excludedTypes.Contains(t.Name);
        }
    }
}