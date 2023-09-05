using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetCodeReact.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMaping()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new Services.Mapping.MappingProfile()));
            var mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}