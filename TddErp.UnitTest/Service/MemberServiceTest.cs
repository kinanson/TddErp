using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TddErp.Model.Models;
using TddErp.Service.Interface;
using System.Data.Entity;
using NSubstitute;
using System.Collections.Generic;
using Ploeh.AutoFixture;

namespace TddErp.UnitTest.Service
{
    [TestClass]
    public class MemberServiceTest
    {
        MemberService service = null;
        IContext db=new FakeApplicationDbContext();
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
