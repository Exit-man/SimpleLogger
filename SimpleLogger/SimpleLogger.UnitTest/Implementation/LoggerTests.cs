using FluentAssertions;
using NUnit.Framework;
using SimpleLogger.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.UnitTest.Implementation
{
    [TestFixture]
    public class LoggerTests
    {
        Logger _testLogger;

        [SetUp]
        public void Setup()
        {
            _testLogger = new Logger();
        }

        [Test]
        public void LogToEventList_AddingNewItem()
        {

            _testLogger.LogToEventList("AppleTree");

            _testLogger.LoggedEvents.Count().Should().Be(1);
            _testLogger.LoggedEvents.Should().Contain("AppleTree");
        }

        [Test]
        public void LogToFile()
        {
            var fileName = "\\SimpleLog" + DateTime.Today.Date.ToString() + ".txt";
            var directoryPath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "\\SimpleLoggerLogs");
            string path = Path.Combine(directoryPath, fileName);

            _testLogger.LogToFile("AppleTree");

            Assert.That(System.IO.Directory.Exists(directoryPath));
            Assert.That(System.IO.File.Exists(path));
        }

        [Test]
        public void SetupLogPath_ReturnsUserInputPath()
        {
            var path = "AppleTree";

            _testLogger.LogPath = path;

            _testLogger.LogPath.Should().Be(path);
        }


    }
}
