namespace TddErp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookGroup",
                c => new
                    {
                        BookGroupID = c.String(nullable: false, maxLength: 2),
                        BookGroupName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.BookGroupID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.String(nullable: false, maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 30),
                        Price = c.Int(nullable: false),
                        WarehouseStock = c.Int(nullable: false),
                        ShopStock = c.Int(nullable: false),
                        BookGroupID = c.String(nullable: false, maxLength: 2),
                        BookTypeID = c.String(nullable: false, maxLength: 3),
                        PublishID = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.BookGroup", t => t.BookGroupID, cascadeDelete: true)
                .ForeignKey("dbo.BookType", t => t.BookTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Publish", t => t.PublishID, cascadeDelete: true)
                .Index(t => t.BookGroupID)
                .Index(t => t.BookTypeID)
                .Index(t => t.PublishID);
            
            CreateTable(
                "dbo.BookType",
                c => new
                    {
                        BookTypeID = c.String(nullable: false, maxLength: 3),
                        BookTypeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.BookTypeID);
            
            CreateTable(
                "dbo.DrawDetails",
                c => new
                    {
                        DrawID = c.String(nullable: false, maxLength: 10),
                        Seq = c.Byte(nullable: false),
                        Quantity = c.Int(),
                        BookID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.DrawID, t.Seq })
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.DrawMaster", t => t.DrawID, cascadeDelete: true)
                .Index(t => t.DrawID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.DrawMaster",
                c => new
                    {
                        DrawID = c.String(nullable: false, maxLength: 10),
                        DrawDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DrawID);
            
            CreateTable(
                "dbo.Publish",
                c => new
                    {
                        PublishID = c.String(nullable: false, maxLength: 5),
                        PublishName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.PublishID);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        PurchaseID = c.String(nullable: false, maxLength: 10),
                        Seq = c.Byte(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        BookID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.PurchaseID, t.Seq })
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseMaster", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.PurchaseMaster",
                c => new
                    {
                        PurchaseID = c.String(nullable: false, maxLength: 10),
                        PurchaseDate = c.DateTime(nullable: false, storeType: "date"),
                        InvoiceNo = c.String(maxLength: 10),
                        GrandTotal = c.Int(nullable: false),
                        ValueAddTax = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        VendorID = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Vendor", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.VendorID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorID = c.String(nullable: false, maxLength: 5),
                        VendorName = c.String(nullable: false, maxLength: 40),
                        Tel = c.String(nullable: false, maxLength: 15),
                        Fax = c.String(maxLength: 15),
                        EarNo = c.String(maxLength: 8),
                        Address = c.String(nullable: false, maxLength: 50),
                        Web = c.String(maxLength: 30),
                        Contact = c.String(nullable: false, maxLength: 10),
                        MobilePhone = c.String(nullable: false, maxLength: 10),
                        EMail = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.VendorID);
            
            CreateTable(
                "dbo.RecvDetails",
                c => new
                    {
                        RecvID = c.String(nullable: false, maxLength: 10),
                        Seq = c.Byte(nullable: false),
                        Quantity = c.Int(nullable: false),
                        BookID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.RecvID, t.Seq })
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.RecvMaster", t => t.RecvID, cascadeDelete: true)
                .Index(t => t.RecvID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.RecvMaster",
                c => new
                    {
                        RecvID = c.String(nullable: false, maxLength: 10),
                        RecvDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecvID);
            
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        SalesID = c.String(nullable: false, maxLength: 10),
                        Seq = c.Byte(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Discount = c.Byte(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        SalesAmount = c.Int(nullable: false),
                        BookID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.SalesID, t.Seq })
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.SalesMaster", t => t.SalesID, cascadeDelete: true)
                .Index(t => t.SalesID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.SalesMaster",
                c => new
                    {
                        SalesID = c.String(nullable: false, maxLength: 10),
                        SalesDate = c.DateTime(nullable: false),
                        SalesTime = c.Time(nullable: false, precision: 7),
                        InvoiceNo = c.String(maxLength: 10),
                        GrandTotal = c.Int(),
                        ValueAddTax = c.Int(),
                        Amount = c.Int(),
                        CustomerGroup = c.String(nullable: false, maxLength: 1),
                        Employee_Id = c.String(maxLength: 128),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SalesID)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .ForeignKey("dbo.Member", t => t.Member_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ArriveDate = c.DateTime(nullable: false),
                        ExitDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RealName = c.String(nullable: false, maxLength: 12),
                        Sex = c.String(nullable: false, maxLength: 2),
                        BirthDate = c.DateTime(),
                        RocID = c.String(maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        JoinDate = c.DateTime(nullable: false),
                        Blog = c.String(maxLength: 30),
                        Hob01 = c.Boolean(nullable: false),
                        Hob02 = c.Boolean(nullable: false),
                        Hob03 = c.Boolean(nullable: false),
                        Hob04 = c.Boolean(nullable: false),
                        Hob05 = c.Boolean(nullable: false),
                        Hob06 = c.Boolean(nullable: false),
                        Hob07 = c.Boolean(nullable: false),
                        Hob08 = c.Boolean(nullable: false),
                        Hob09 = c.Boolean(nullable: false),
                        Hob10 = c.Boolean(nullable: false),
                        Hob11 = c.Boolean(nullable: false),
                        Hob12 = c.Boolean(nullable: false),
                        Hob13 = c.Boolean(nullable: false),
                        Hob14 = c.Boolean(nullable: false),
                        Hob15 = c.Boolean(nullable: false),
                        Hob16 = c.Boolean(nullable: false),
                        Hob17 = c.Boolean(nullable: false),
                        Hob18 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceNo = c.String(nullable: false, maxLength: 10),
                        InvoiceYear = c.String(maxLength: 4),
                        InvoiceMonth = c.String(maxLength: 2),
                        InvoiceDate = c.DateTime(storeType: "date"),
                        EarNo = c.String(maxLength: 8),
                        InvoiceType = c.String(maxLength: 1),
                        GrandTotal = c.Int(),
                        ValueAddTax = c.Int(),
                        IsUsed = c.String(maxLength: 1),
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.InvoiceNo);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SalesDetails", "SalesID", "dbo.SalesMaster");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Member", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesMaster", "Member_Id", "dbo.Member");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employee", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SalesMaster", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.SalesDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.RecvDetails", "RecvID", "dbo.RecvMaster");
            DropForeignKey("dbo.RecvDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.PurchaseMaster", "VendorID", "dbo.Vendor");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseID", "dbo.PurchaseMaster");
            DropForeignKey("dbo.PurchaseDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "PublishID", "dbo.Publish");
            DropForeignKey("dbo.DrawDetails", "DrawID", "dbo.DrawMaster");
            DropForeignKey("dbo.DrawDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "BookTypeID", "dbo.BookType");
            DropForeignKey("dbo.Books", "BookGroupID", "dbo.BookGroup");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Member", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.SalesMaster", new[] { "Member_Id" });
            DropIndex("dbo.SalesMaster", new[] { "Employee_Id" });
            DropIndex("dbo.SalesDetails", new[] { "BookID" });
            DropIndex("dbo.SalesDetails", new[] { "SalesID" });
            DropIndex("dbo.RecvDetails", new[] { "BookID" });
            DropIndex("dbo.RecvDetails", new[] { "RecvID" });
            DropIndex("dbo.PurchaseMaster", new[] { "VendorID" });
            DropIndex("dbo.PurchaseDetails", new[] { "BookID" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseID" });
            DropIndex("dbo.DrawDetails", new[] { "BookID" });
            DropIndex("dbo.DrawDetails", new[] { "DrawID" });
            DropIndex("dbo.Books", new[] { "PublishID" });
            DropIndex("dbo.Books", new[] { "BookTypeID" });
            DropIndex("dbo.Books", new[] { "BookGroupID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Invoice");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Member");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Employee");
            DropTable("dbo.SalesMaster");
            DropTable("dbo.SalesDetails");
            DropTable("dbo.RecvMaster");
            DropTable("dbo.RecvDetails");
            DropTable("dbo.Vendor");
            DropTable("dbo.PurchaseMaster");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Publish");
            DropTable("dbo.DrawMaster");
            DropTable("dbo.DrawDetails");
            DropTable("dbo.BookType");
            DropTable("dbo.Books");
            DropTable("dbo.BookGroup");
        }
    }
}
