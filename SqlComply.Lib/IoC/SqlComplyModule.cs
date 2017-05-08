using Autofac;
using Csla.Abstractions;
using Csla.Abstractions.Core.Contracts;
using Csla.Serialization.Mobile;
using SqlComply.Lib.Contracts;
using SqlComply.Lib.Logic;

namespace SqlComply.Lib.IoC
{
    public class SqlComplyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ObjectPortal<>))
                   .As(typeof(IObjectPortal<>))
                   .InstancePerLifetimeScope();

            var cslaTypes = ThisAssembly;
            var cslaMobileObject = typeof(IMobileObject);
            builder.RegisterAssemblyTypes(cslaTypes)
                   .Where(t => cslaMobileObject.IsAssignableFrom(t) & !t.IsInterface & !t.IsAbstract)
                   .AsImplementedInterfaces();

            builder.RegisterType<SqlRuleDataReader>()
                   .As<ISqlRuleDataReader>()
                   .SingleInstance();
        }
    }
}
