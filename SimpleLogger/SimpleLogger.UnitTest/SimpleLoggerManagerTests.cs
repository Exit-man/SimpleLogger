using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleLogger.DomainModel;
using SimpleLogger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.UnitTest
{
    [TestFixture]
    public class SimpleLoggerManagerTests
    {
        private SimpleLoggerManager _testManager;
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            List<string> events = new List<string>() { "Hello World","Nice Try"};
            _loggerMock.Setup(n=>n.LoggedEvents).Returns(events);

            _testManager = new SimpleLoggerManager(_loggerMock.Object);
        }

        [TestCase("AppleTree")]
        public void SetUpLogPath(string logpath)
        {
            _testManager.SetUpLogPath(logpath);

            _loggerMock.Verify(n => n.LogPath, Times.Once());
        }


        [TestCase(LogTarget.File,"Alma")]
        public void LogToFile_CallsCorrectMethod(LogTarget logTarget, string message)
        {
            _testManager.Log(logTarget, message);

            _loggerMock.Verify(n => n.LogToEventList(message), Times.Never());
            _loggerMock.Verify(n => n.LogToFile(message), Times.Once());
        }

        [TestCase(LogTarget.EventLog, "Alma")]
        public void LogToEventList_CallsCorrectMethod(LogTarget logTarget, string message)
        {
            _testManager.Log(logTarget, message);

            _loggerMock.Verify(n => n.LogToEventList(message), Times.Once());
            _loggerMock.Verify(n => n.LogToFile(message), Times.Never());
        }

        [Test]
        public void EventLog_ReturnsValidCollection()
        {
            List<string> events = new List<string>() { "Hello World", "Nice Try" };
            _loggerMock.Setup(n => n.LoggedEvents).Returns(events);

            var result = _testManager.GetEventLog();

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(events);
        }

        [Test]
        public void EventLog_ReturnsEmptyCollection()
        {

            var result = _testManager.GetEventLog();

            result.Should().NotBeNull();
            result.Count.Should().Be(0);
        }

    }
}
