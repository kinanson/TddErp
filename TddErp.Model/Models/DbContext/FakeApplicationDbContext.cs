using System.Data.Entity;

namespace TddErp.Model.Models
{
    public class FakeApplicationDbContext : DbContext, IContext
    {
        public IDbSet<BookGroup> BookGroup { get; set; }
        public IDbSet<Books> Books { get; set; }
        public IDbSet<BookType> BookType { get; set; }
        public IDbSet<DrawDetails> DrawDetails { get; set; }
        public IDbSet<DrawMaster> DrawMaster { get; set; }
        public IDbSet<Employee> Employee { get; set; }
        public IDbSet<Invoice> Invoice { get; set; }
        public IDbSet<Member> Member { get; set; }
        public IDbSet<Publish> Publish { get; set; }
        public IDbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public IDbSet<PurchaseMaster> PurchaseMaster { get; set; }
        public IDbSet<RecvDetails> RecvDetails { get; set; }
        public IDbSet<RecvMaster> RecvMaster { get; set; }
        public IDbSet<SalesDetails> SalesDetails { get; set; }
        public IDbSet<SalesMaster> SalesMaster { get; set; }
        public IDbSet<Vendor> Vendor { get; set; }
    }
}