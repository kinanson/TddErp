using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddErp.Model.Models;

namespace TddErp.Service.Interface
{
    public interface IMemberService : IEntityService<Member>
    {
        string GetId(string memberId);
    }

    public class MemberService:EntityService<Member>,IMemberService
    {
        public MemberService(IContext db)
            :base(db)
        {
            this.db = db;
        }

        public string GetId(string memberId)
        {
            return SeriaNumber.GetYMTen(memberId);
        }
    }
}
