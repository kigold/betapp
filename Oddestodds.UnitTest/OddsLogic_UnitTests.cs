using NUnit.Framework;
using Oddestodds.Logic.Interfaces;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private IOddsLogic _sut;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetOdds_FetchOddsData_Success()
        {
            Assert.Pass();
        }
    }
}