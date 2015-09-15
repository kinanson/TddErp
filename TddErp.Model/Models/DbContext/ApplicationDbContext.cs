namespace TddErp.Model.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext
    {
        public ApplicationDbContext()
            : base("Context")
        {
        }

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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(x => x.Employee)
                .WithRequired(x => x.User);
            modelBuilder.Entity<ApplicationUser>()
               .HasOptional(x => x.Member)
               .WithRequired(x => x.User);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
