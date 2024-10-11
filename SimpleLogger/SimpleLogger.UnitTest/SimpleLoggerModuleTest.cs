using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleLogger.Creational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.UnitTest
{
    [TestFixture]
    public class SimpleLoggerModuleTest
    {
        private SimpleLoggerModule _testModule;

        private Mock<ISimpleLoggerManagerFactory> _simpleLoggerManagerFactoryMock;
        private Mock<ISimpleLoggerManager> _simpleLoggerManagerMock;

        [SetUp]
        public void Setup()
        {
            _simpleLoggerManagerFactoryMock = new Mock<ISimpleLoggerManagerFactory>();
            _simpleLoggerManagerMock = new Mock<ISimpleLoggerManager>();

            _simpleLoggerManagerFactoryMock.Setup(n=>n.CreateManager())
                .Returns(_simpleLoggerManagerMock.Object);

            _testModule = new SimpleLoggerModule(_simpleLoggerManagerFactoryMock.Object);
        }

        [Test]
        public void GetManager_ReturnsValidObject()
        {
            var result = _testModule.GetManager();

            result.Should().Be(_simpleLoggerManagerMock.Object);
        }


    }
}
