using Autofac;
using FluentAssertions;
using NUnit.Framework;
using SimpleLogger.Creational;

namespace SimpleLogger.IntegTest;

[TestFixture]
public class SimpleLoggerModlueTest
{
    private IContainer _container;

    [SetUp]
    public void TestSetup()
    {
        _container = RegisterModuleContainer();
    }

    [Test]
    public void Resolve_SimpleLoggerAutofacModule_DoNotThrowExceptionAndCreatingObject()
    {
        using var scope = _container.BeginLifetimeScope();

        var simpleLogModule = scope.Resolve<ISimpleLoggerModule>();

        simpleLogModule.Should().NotBeNull();
    }

    private IContainer RegisterModuleContainer()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterModule(new SimpleLoggerAutofacModule());
        return containerBuilder.Build();
    }

}
