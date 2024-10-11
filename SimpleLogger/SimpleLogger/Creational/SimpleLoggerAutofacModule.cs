using System;
using System.Collections.Generic;
using Autofac;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace SimpleLogger.Creational
{
    [ExcludeFromCodeCoverage]
    public class SimpleLoggerAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SimpleLoggerManagerFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterType<SimpleLoggerModule>().As< ISimpleLoggerModule>().InstancePerLifetimeScope();
        }
    }
}
