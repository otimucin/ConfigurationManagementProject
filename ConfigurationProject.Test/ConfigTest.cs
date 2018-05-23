using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ConfigurationProject.Test
{
    [TestFixture]
    public class ConfigTest
    {
        private IConfigurationReader _configReader;

        public ConfigTest(IConfigurationReader configReader)
        {
            _configReader = configReader;
        }

        [SetUp()]
        public void Setup()
        {
            var appName = "SERVICE-A";
            var connectionString = "mongodb://localhost:27017/Configuration";
            _configReader = new ConfigurationReader(appName, connectionString, 10000);
        }
        [TestCase("MaxItemCount")]
        public void When_Call_Not_ActiveValue_Then_It_Should_Return_Null(string name)
        {
            var configItem2 = _configReader.GetValue<int?>("MaxItemCount");
            Assert.IsTrue(configItem2 == null);
        }
    }
}
