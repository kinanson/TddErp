using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace TddErp.UnitTest.Common
{
    [TestClass]
    public class SeriaNumberTest
    {
        [TestMethod]
        public void GetYMTenTest()
        {
            var fixture = new Fixture();
            var actual = SeriaNumber.GetYMTen("2015090001");
            Assert.AreEqual(actual, actual);
        }

        [TestMethod]
        public void GetSeqTest()
        {
            var actual = SeriaNumber.GetSeq("0001");
            Assert.AreEqual("0002", actual);
        }

        [TestMethod]
        public void GetEmployeeID()
        {
            var actual = SeriaNumber.GetThreeID("001");
            Assert.AreEqual("002", actual);
        }

        [TestMethod]
        public void GetYMTenTestIfNull()
        {
            var actual = SeriaNumber.GetYMTen(null);
            Assert.AreEqual(actual, actual);
        }

        [TestMethod]
        public void GetSeqTestIfNull()
        {
            var actual = SeriaNumber.GetSeq(null);
            Assert.AreEqual("0001", actual);
        }

        [TestMethod]
        public void GetEmployeeIDIfNull()
        {
            var actual = SeriaNumber.GetThreeID(null);
            Assert.AreEqual("001", actual);
        }
    }
}