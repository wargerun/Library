namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BOOKs",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 38, scale: 0, identity: true),
                        ISBN = c.String(nullable: false, maxLength: 20, unicode: false),
                        NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                        AUTHOR = c.String(maxLength: 30, unicode: false),
                        PUBLISHING = c.String(maxLength: 50, unicode: false),
                        COUNT = c.Decimal(precision: 18, scale: 2),
                        STATUS = c.String(maxLength: 50, unicode: false),
                        DESCRIPTION = c.String(unicode: false),
                        PRICE = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BOOKS_ISSUED",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 38, scale: 0, identity: true),
                        ISSUED_DATE = c.DateTime(nullable: false),
                        RETURN_DATE = c.DateTime(nullable: false),
                        BOOKS_ID = c.Decimal(precision: 38, scale: 0),
                        VIEWERS_ID = c.Decimal(precision: 38, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BOOKs", t => t.BOOKS_ID)
                .ForeignKey("dbo.VIEWERs", t => t.VIEWERS_ID)
                .Index(t => t.BOOKS_ID)
                .Index(t => t.VIEWERS_ID);
            
            CreateTable(
                "dbo.VIEWERs",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 38, scale: 0, identity: true),
                        NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                        SURNAME = c.String(maxLength: 100, unicode: false),
                        MIDDLE_NAME = c.String(maxLength: 100, unicode: false),
                        ADDRESS = c.String(maxLength: 200, unicode: false),
                        PHONE = c.String(nullable: false, maxLength: 50, unicode: false),
                        EMAIL = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BOOKS_ISSUED", "VIEWERS_ID", "dbo.VIEWERs");
            DropForeignKey("dbo.BOOKS_ISSUED", "BOOKS_ID", "dbo.BOOKs");
            DropIndex("dbo.BOOKS_ISSUED", new[] { "VIEWERS_ID" });
            DropIndex("dbo.BOOKS_ISSUED", new[] { "BOOKS_ID" });
            DropTable("dbo.VIEWERs");
            DropTable("dbo.BOOKS_ISSUED");
            DropTable("dbo.BOOKs");
        }
    }
}
