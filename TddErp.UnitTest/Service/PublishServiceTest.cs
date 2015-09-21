using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddErp.Model.Models;
using System.Collections.Generic;
using TddErp.Service.Interface;
using NSubstitute;
using System.Linq;

namespace TddErp.UnitTest.Service
{
    [TestClass]
    public class PublishServiceTest
    {
        PublishService service = null;
        IContext db = new FakeApplicationDbContext();
        public PublishServiceTest()
        {
            var publishs = new List<Publish>
            {
                new Publish {PublishID="001" },
                new Publish {PublishID="002" }
            };
            db.Publish = new FakeDbSet<Publish>(publishs);
            service = new PublishService(db);
        }

        [TestMethod]
        public void AddTest()
        {
            service.Add(new Publish { PublishID = string.Empty, PublishName = "anson" });
            Assert.IsTrue(db.Publish.Count() == 3);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var actuall = service.GetAll();
            Assert.IsTrue(actuall.Count() == 2);
        }
    }
}
