using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TddErp.Model.Models
{
    public interface IContext
    {
        IDbSet<BookGroup> BookGroup { get; set; }
        IDbSet<Books> Books { get; set; }
        IDbSet<BookType> BookType { get; set; }
        IDbSet<DrawDetails> DrawDetails { get; set; }
        IDbSet<DrawMaster> DrawMaster { get; set; }
        IDbSet<Employee> Employee { get; set; }
        IDbSet<Invoice> Invoice { get; set; }
        IDbSet<Member> Member { get; set; }
        IDbSet<Publish> Publish { get; set; }
        IDbSet<PurchaseDetails> PurchaseDetails { get; set; }
        IDbSet<PurchaseMaster> PurchaseMaster { get; set; }
        IDbSet<RecvDetails> RecvDetails { get; set; }
        IDbSet<RecvMaster> RecvMaster { get; set; }
        IDbSet<SalesDetails> SalesDetails { get; set; }
        IDbSet<SalesMaster> SalesMaster { get; set; }
        IDbSet<Vendor> Vendor { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}