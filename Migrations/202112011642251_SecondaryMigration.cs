namespace WeaponShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "WeaponsId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "Author", c => c.String());
            AddColumn("dbo.Feedbacks", "PublishedOnSite", c => c.DateTime(nullable: false));
            AddColumn("dbo.Feedbacks", "isEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Feedbacks", "Reads", c => c.Long(nullable: false));
            AddColumn("dbo.Feedbacks", "Feedback_Id", c => c.Int());
            AddColumn("dbo.WeaponCategories", "CreatedBy", c => c.String());
            AddColumn("dbo.WeaponCategories", "WeaponCategory_Id", c => c.Int());
            AddColumn("dbo.Weapons", "WeaponCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Weapons", "isEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WeaponCategories", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.WeaponCategories", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Weapons", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Weapons", "Calibre", c => c.Int(nullable: false));
            AlterColumn("dbo.Weapons", "Price", c => c.Double(nullable: false));
            CreateIndex("dbo.Feedbacks", "WeaponsId");
            CreateIndex("dbo.Feedbacks", "Feedback_Id");
            CreateIndex("dbo.Weapons", "WeaponCategoryId");
            CreateIndex("dbo.WeaponCategories", "WeaponCategory_Id");
            AddForeignKey("dbo.Feedbacks", "Feedback_Id", "dbo.Feedbacks", "Id");
            AddForeignKey("dbo.WeaponCategories", "WeaponCategory_Id", "dbo.WeaponCategories", "Id");
            AddForeignKey("dbo.Weapons", "WeaponCategoryId", "dbo.WeaponCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "WeaponsId", "dbo.Weapons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "WeaponsId", "dbo.Weapons");
            DropForeignKey("dbo.Weapons", "WeaponCategoryId", "dbo.WeaponCategories");
            DropForeignKey("dbo.WeaponCategories", "WeaponCategory_Id", "dbo.WeaponCategories");
            DropForeignKey("dbo.Feedbacks", "Feedback_Id", "dbo.Feedbacks");
            DropIndex("dbo.WeaponCategories", new[] { "WeaponCategory_Id" });
            DropIndex("dbo.Weapons", new[] { "WeaponCategoryId" });
            DropIndex("dbo.Feedbacks", new[] { "Feedback_Id" });
            DropIndex("dbo.Feedbacks", new[] { "WeaponsId" });
            AlterColumn("dbo.Weapons", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Weapons", "Calibre", c => c.String());
            AlterColumn("dbo.Weapons", "Name", c => c.String());
            AlterColumn("dbo.WeaponCategories", "Description", c => c.String());
            AlterColumn("dbo.WeaponCategories", "Name", c => c.String());
            DropColumn("dbo.Weapons", "isEnabled");
            DropColumn("dbo.Weapons", "WeaponCategoryId");
            DropColumn("dbo.WeaponCategories", "WeaponCategory_Id");
            DropColumn("dbo.WeaponCategories", "CreatedBy");
            DropColumn("dbo.Feedbacks", "Feedback_Id");
            DropColumn("dbo.Feedbacks", "Reads");
            DropColumn("dbo.Feedbacks", "isEnabled");
            DropColumn("dbo.Feedbacks", "PublishedOnSite");
            DropColumn("dbo.Feedbacks", "Author");
            DropColumn("dbo.Feedbacks", "WeaponsId");
        }
    }
}
