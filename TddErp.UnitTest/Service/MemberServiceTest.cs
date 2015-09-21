using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TddErp.Model.Models;
using TddErp.Service.Interface;

namespace TddErp.UnitTest.Service
{
    [TestClass]
    public class MemberServiceTest
    {
        private MemberService service = null;
        private IContext db = new FakeApplicationDbContext();

        public MemberServiceTest()
        {
            var members = new List<Member>
            {
                new Member {Id="001" },
                new Member {Id="002" },
                new Member {Id="003" }
            };
            db.Member = new FakeDbSet<Member>(members);
            service = new MemberService(db);
        }
    }
}