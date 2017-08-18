using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TddErp.Model.Models;
using TddErp.Service.Interface;

namespace TddErp.UnitTest.Service
{
    [TestClass]
    public class PublishServiceTest
    {
        private PublishService service = null;
        private IContext Db = new FakeApplicationDbContext();

        public PublishServiceTest()
        {
            var publishs = new List<Publish>
            {
                new Publish {PublishID="001" },
                new Publish {PublishID="002" }
            };
            Db.Publish = new FakeDbSet<Publish>(publishs);
            service = new PublishService(Db);
        }

        [TestMethod]
        public void AddTest()
        {
            service.Add(new Publish { PublishID = string.Empty, PublishName = "anson" });
            Assert.IsTrue(Db.Publish.Count() == 3);
        }      
    }
}