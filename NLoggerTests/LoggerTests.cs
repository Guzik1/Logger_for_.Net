using NUnit.Framework;
using NLogger;
using System;

namespace NLoggerTests
{
    public class LoggerTests
    {
        [Test]
        public void FormaterTest()
        {
            Logger logger = new Logger();
            logger.AddOutput(new TestOutput(), new TestLogFormater());

            try
            {
                logger.Info("test");
                Assert.Pass();
            }
            catch (NotImplementedException e)
            {
                Assert.AreEqual("test", e.Message);
            }
        }

        [Test]
        public void LoggerSystemTest()
        {
            Logger logger = new Logger();
            logger.AddOutput(new TestOutput(), new TestImplementedLogFormater());

            try
            {
                logger.Info("test");
                Assert.Pass();
            }
            catch (NotImplementedException e)
            {
                Assert.AreEqual("Info: test", e.Message);
            }
        }
    }
}