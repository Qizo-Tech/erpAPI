using Microsoft.EntityFrameworkCore;
using qizoErpWebApiApp.Model.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qizoErpWebApiApp.Model.Transactions;


namespace qizoErpApi.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
           : base(options)
        {
        }
        //************** C
        // public DbSet<classNamefor the table> database table name map to class { get; set; }

        public virtual DbSet<Mconditions> Mconditions { get; set; }
        public virtual DbSet<MuserGroups> MuserGroups { get; set; }
        public virtual DbSet<Musers> Musers { get; set; }
        public virtual DbSet<ProductToSpare> ProductToSpare { get; set; }

        public virtual DbSet<MCompanyProfile> MCompanyProfile { get; set; }
        public virtual DbSet<RelPricingLevelItems> RelPricingLevelItems { get; set; }
        public virtual DbSet<RelPurchaseOrderIndendHeader> RelPurchaseOrderIndendHeader { get; set; }
        public virtual DbSet<RelPurchaseOrderSupplierDetails> RelPurchaseOrderSupplierDetails { get; set; }
        public virtual DbSet<TPurchaseIndentDetails> TPurchaseIndentDetails { get; set; }
        public virtual DbSet<TPurchaseIndentHeader> TPurchaseIndentHeader { get; set; }
        public virtual DbSet<TPurchaseOrderHeader> TPurchaseOrderHeader { get; set; }
        public virtual DbSet<TblMasterCompanyProfile> TblMasterCompanyProfile { get; set; }

        public virtual DbSet<MLedgerHeads> MLedgerHeads { get; set; }
        public virtual DbSet<Mstate> Mstate { get; set; }
        public virtual DbSet<RelItemImage> RelItemImage { get; set; }
        public virtual DbSet<MpricingLevel> MpricingLevel { get; set; }
        public virtual DbSet<MledgerGroup> MledgerGroup { get; set; }
        public DbSet<ItemType> MItemType { get; set; }

        //***********Godwon with rack master
        public DbSet<MGodown> mGodown { get; set; }
        public DbSet<mGodownInCharge> MGodownInCharge { get; set; }
        public DbSet<RelMGodownRack> relMGodownRack { get; set; }

        public virtual DbSet<MIadditionalTax> MIadditionalTax { get; set; }
        public virtual DbSet<MItemGroup> MItemGroup { get; set; }
        public virtual DbSet<MItemSubGroup> MItemSubGroup { get; set; }

        public virtual DbSet<MProductTypeStatic> MProductTypeStatic { get; set; }
        public virtual DbSet<MStockTypeStatic> MStockTypeStatic { get; set; }
        public virtual DbSet<MTax> MTax { get; set; }
        public virtual DbSet<MTaxType> MTaxType { get; set; }
        public DbSet<MBrand> MBrand { get; set; }

        /****Rajesh updation Start****/
        public virtual DbSet<TPifrightDetails> TPifrightDetails { get; set; }

        /****Rajesh updation End****/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /****Rajesh updation Start****/
            modelBuilder.Entity<TPifrightDetails>(entity =>
            {
                entity.ToTable("tPIFrightDetails");

                entity.Property(e => e.PifClosingDate)
                    .HasColumnName("PIF_ClosingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PifEta)
                    .HasColumnName("PIF_ETA")
                    .HasColumnType("datetime");

                entity.Property(e => e.PifEtd)
                    .HasColumnName("PIF_ETD")
                    .HasColumnType("datetime");

                entity.Property(e => e.PifFrightParyId)
                    .HasColumnName("PIF_FrightParyId")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PifFrigthAmount)
                    .HasColumnName("PIF_FrigthAmount")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PifPiid).HasColumnName("PIF_PIid");

                entity.Property(e => e.PifRoute)
                    .HasColumnName("PIF_Route")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PifRouteDescription)
                    .HasColumnName("PIF_RouteDescription")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PifShippingLineParyId).HasColumnName("PIF_ShippingLineParyId");

                entity.Property(e => e.PifTransitTime).HasColumnName("PIF_TransitTime");

                entity.HasOne(d => d.PifFrightPary)
                    .WithMany(p => p.TPifrightDetails)
                    .HasForeignKey(d => d.PifFrightParyId)
                    .HasConstraintName("FK__tPIFright__PIF_F__6D6238AF");

                entity.HasOne(d => d.PifShippingLinePary)
                    .WithMany(p => p.TPifrightDetails)
                    .HasForeignKey(d => d.PifShippingLineParyId)
                    .HasConstraintName("FK__tPIFright__PIF_S__6E565CE8");
            });

            modelBuilder.Entity<MShippingLine>(entity =>
            {
                entity.ToTable("mShippingLine");

                entity.Property(e => e.SlAddress)
                    .HasColumnName("SL_Address")
                    .HasMaxLength(500);

                entity.Property(e => e.SlBranchId).HasColumnName("SL_BranchId");

                entity.Property(e => e.SlShippingName)
                    .HasColumnName("SL_ShippingName")
                    .HasMaxLength(100);

                entity.Property(e => e.SlUserId).HasColumnName("SL_UserId");
            });





            /****Rajesh updation End****/



            //modelBuilder.Entity<mGodownModel>(entity =>
            //{
            //    entity.HasMany(d => d.Racks )
            //      .WithOne(p => p.mGodown )
            //      .OnDelete(DeleteBehavior.Cascade);

            //});
            //******************************
            modelBuilder.Entity<Mconditions>(entity =>
            {
                entity.ToTable("MConditions");

                entity.Property(e => e.ConBaranchId).HasColumnName("Con_BaranchId");

                entity.Property(e => e.ConDescription)
                    .HasColumnName("Con_Description")
                    .HasMaxLength(250);

                entity.Property(e => e.ConUserId).HasColumnName("Con_UserId");
            });

            modelBuilder.Entity<MuserGroups>(entity =>
            {
                entity.ToTable("MUserGroups");

                entity.Property(e => e.UserGrpBranchId).HasColumnName("UserGrp_BranchId");

                entity.Property(e => e.UserGrpDescription)
                    .HasColumnName("UserGrp_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.UserGrpUserId).HasColumnName("UserGrp_UserId");
            });

            modelBuilder.Entity<Musers>(entity =>
            {
                entity.ToTable("MUsers");

                entity.Property(e => e.UserAddress1)
                    .HasColumnName("User_Address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddress2)
                    .HasColumnName("User_Address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddress3)
                    .HasColumnName("User_Address3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserBranchId).HasColumnName("User_BranchId");

                entity.Property(e => e.UserContactNos)
                    .HasColumnName("User_ContactNos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreatedUserId).HasColumnName("User_CreatedUserId");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("User_Email")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupId).HasColumnName("User_GroupId");

                entity.Property(e => e.UserImage)
                    .HasColumnName("User_Image")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobileNo)
                    .HasColumnName("User_MobileNO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("User_Password")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserPinCode)
                    .HasColumnName("User_PinCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserUserName)
                    .IsRequired()
                    .HasColumnName("User_UserName")
                    .HasMaxLength(100);

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.Musers)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK__MUsers__User_Gro__1209AD79");
            });

            modelBuilder.Entity<ProductToSpare>(entity =>
            {
                entity.Property(e => e.PtsBranchId).HasColumnName("Pts_BranchId");

                entity.Property(e => e.PtsProductId).HasColumnName("Pts_ProductId");

                entity.Property(e => e.PtsQty)
                    .HasColumnName("Pts_qty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PtsSpareId).HasColumnName("Pts_SpareId");

                entity.Property(e => e.PtsUserId).HasColumnName("Pts_UserId");

                entity.HasOne(d => d.PtsProduct)
                    .WithMany(p => p.ProductToSparePtsProduct)
                    .HasForeignKey(d => d.PtsProductId)
                    .HasConstraintName("FK__ProductTo__Pts_P__16CE6296");

                entity.HasOne(d => d.PtsSpare)
                    .WithMany(p => p.ProductToSparePtsSpare)
                    .HasForeignKey(d => d.PtsSpareId)
                    .HasConstraintName("FK__ProductTo__Pts_S__17C286CF");
            });
            modelBuilder.Entity<MCompanyProfile>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("mCompanyProfile");

                entity.Property(e => e.CompanyProfileAccountNo)
                    .HasColumnName("CompanyProfile_AccountNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileAddress1)
                    .HasColumnName("CompanyProfile_Address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileAddress2)
                    .HasColumnName("CompanyProfile_Address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileAddress3)
                    .HasColumnName("CompanyProfile_Address3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileBankName)
                    .HasColumnName("CompanyProfile_BankName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileBranch)
                    .HasColumnName("CompanyProfile_Branch")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileContact)
                    .HasColumnName("CompanyProfile_Contact")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileEmail)
                    .HasColumnName("CompanyProfile_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileGstNo)
                    .HasColumnName("CompanyProfile_GstNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileId)
                    .HasColumnName("CompanyProfile_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyProfileIfsc)
                    .HasColumnName("CompanyProfile_IFSC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileImagePath)
                    .HasColumnName("CompanyProfile_ImagePath")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileIsPrintHead).HasColumnName("CompanyProfile_IsPrintHead");

                entity.Property(e => e.CompanyProfileMailingName)
                    .HasColumnName("CompanyProfile_MailingName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileMobile)
                    .HasColumnName("CompanyProfile_Mobile")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileName)
                    .HasColumnName("CompanyProfile_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfilePan)
                    .HasColumnName("CompanyProfile_PAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileShortName)
                    .HasColumnName("CompanyProfile_ShortName")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyProfileStateId).HasColumnName("CompanyProfile_StateID");

                entity.Property(e => e.CompanyProfileWeb)
                    .HasColumnName("CompanyProfile_Web")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Mstate>(entity =>
            {
                entity.ToTable("MState");

                entity.Property(e => e.MsName)
                    .HasColumnName("Ms_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MsStateCode)
                    .HasColumnName("Ms_StateCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<RelItemImage>(entity =>
            {
                entity.ToTable("relItemImage");

                entity.Property(e => e.ItmImgItemId).HasColumnName("ItmImg_ItemId");

                entity.Property(e => e.ItmImgPath)
                    .HasColumnName("ItmImg_path")
                    .HasMaxLength(50);

                entity.HasOne(d => d.ItmImgItem)
                    .WithMany(p => p.RelItemImage)
                    .HasForeignKey(d => d.ItmImgItemId)
                    .HasConstraintName("FK__relItemIm__ItmIm__4E53A1AA");
            });

            modelBuilder.Entity<MLedgerHeads>(entity =>
            {
                entity.ToTable("mLedgerHeads");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LhAccountNo)
                    .HasColumnName("lh_AccountNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhAliasName)
                    .HasColumnName("lh_AliasName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhBankBranch)
                    .HasColumnName("lh_BankBranch")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhBankName)
                    .HasColumnName("lh_BankName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhBranchId).HasColumnName("lh_BranchId");

                entity.Property(e => e.LhContactNo)
                    .HasColumnName("lh_ContactNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhContactPerson)
                    .HasColumnName("lh_ContactPerson")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhCreditPeriod).HasColumnName("lh_CreditPeriod");

                entity.Property(e => e.LhEmail)
                    .HasColumnName("lh_Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhGroupId).HasColumnName("lh_GroupId");

                entity.Property(e => e.LhGstno)
                    .HasColumnName("lh_GSTNo")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LhIfscCode)
                    .HasColumnName("lh_IfscCode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhMailingAddress1)
                    .HasColumnName("lh_MailingAddress1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhMailingAddress2)
                    .HasColumnName("lh_MailingAddress2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhMailingAddress3)
                    .HasColumnName("lh_MailingAddress3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhMailingName)
                    .HasColumnName("lh_MailingName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhMaintainBillByBill).HasColumnName("lh_MaintainBillByBill");

                entity.Property(e => e.LhName)
                    .HasColumnName("lh_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LhOpeningBalance)
                    .HasColumnName("lh_OpeningBalance")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LhOpeningType)
                    .HasColumnName("lh_OpeningType")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.LhPanNo)
                    .HasColumnName("lh_PanNo")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LhPincode)
                    .HasColumnName("lh_Pincode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LhPricingLevelId).HasColumnName("lh_PricingLevelId");

                entity.Property(e => e.LhStateId).HasColumnName("lh_StateId");

                entity.Property(e => e.LhType)
                    .HasColumnName("lh_type")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LhUserId).HasColumnName("lh_UserId");

                entity.HasOne(d => d.LhGroup)
                    .WithMany(p => p.MLedgerHeads)
                    .HasForeignKey(d => d.LhGroupId)
                    .HasConstraintName("FK__mLedgerHe__lh_Gr__5F7E2DAC");

                entity.HasOne(d => d.LhPricingLevel)
                    .WithMany(p => p.MLedgerHeads)
                    .HasForeignKey(d => d.LhPricingLevelId)
                    .HasConstraintName("FK__mLedgerHe__lh_Pr__607251E5");

                entity.HasOne(d => d.LhState)
                    .WithMany(p => p.MLedgerHeads)
                    .HasForeignKey(d => d.LhStateId)
                    .HasConstraintName("FK__mLedgerHe__lh_St__6166761E");
            });

            modelBuilder.Entity<MledgerGroup>(entity =>
            {
                entity.ToTable("MLedgerGroup");

                entity.Property(e => e.LgAliasName)
                    .HasColumnName("Lg_AliasName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LgBranchId).HasColumnName("Lg_BranchId");

                entity.Property(e => e.LgName)
                    .HasColumnName("Lg_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LgPrimaryId).HasColumnName("Lg_PrimaryID");
                entity.Property(e => e.LgGrpBehaveSubLedger).HasColumnName("lg_GrpBehaveSubLedger");
                entity.Property(e => e.LgPrimaryName)
                    .HasColumnName("Lg_PrimaryName")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.LgType)
                    .HasColumnName("lg_Type")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LgUnderGruupId).HasColumnName("Lg_UnderGruupID");

                entity.Property(e => e.LgUserId).HasColumnName("Lg_UserId");
            });

            modelBuilder.Entity<MpricingLevel>(entity =>
            {
                entity.ToTable("MPricingLevel");

                entity.Property(e => e.PlBranchId).HasColumnName("Pl_BranchId");

                entity.Property(e => e.PlDescription)
                    .HasColumnName("Pl_Description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlDiscountAmount)
                    .HasColumnName("Pl_DiscountAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlDiscountPercentage)
                    .HasColumnName("Pl_discountPercentage")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlNarration)
                    .HasColumnName("Pl_Narration")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlUserId).HasColumnName("Pl_UserId");
            });

            modelBuilder.Entity<MProductTypeStatic>(entity =>
            {
                entity.ToTable("mProductTypeStatic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MStockTypeStatic>(entity =>
            {
                entity.ToTable("mStockTypeStatic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StockType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<MBrand>(entity =>
            {
                entity.HasKey(e => e.BrndId)
                    .HasName("PK__mBrand__625CE023D48A4EB2");

                entity.ToTable("mBrand");

                entity.Property(e => e.BrndId).HasColumnName("brnd_Id");

                entity.Property(e => e.BrndBranchId).HasColumnName("brnd_BranchId");

                entity.Property(e => e.BrndDescription)
                    .HasColumnName("brnd_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.BrndUserId).HasColumnName("brnd_UserId");
            });
            modelBuilder.Entity<MItemMaster>(entity =>
            {
                entity.ToTable("mItemMaster");

                entity.Property(e => e.ItmBarCode)
                    .HasColumnName("itm_BarCode")
                    .HasMaxLength(50);

                entity.Property(e => e.ItmBranchId).HasColumnName("itm_BranchID");

                entity.Property(e => e.ItmBrandId).HasColumnName("itm_BrandId");

                entity.Property(e => e.ItmCode)
                    .HasColumnName("itm_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.ItmDescription)
                    .HasColumnName("itm_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.ItmGdnId).HasColumnName("itm_GdnId");

                entity.Property(e => e.ItmHsn)
                    .HasColumnName("itm_HSN")
                    .HasMaxLength(50);

                entity.Property(e => e.ItmIsTaxAplicable).HasColumnName("itm_isTaxAplicable");

                entity.Property(e => e.ItmMaxQty)
                    .HasColumnName("itm_MaxQty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmMfrId).HasColumnName("itm_MfrId");

                entity.Property(e => e.ItmMinQty)
                    .HasColumnName("itm_MinQty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmModel)
                    .HasColumnName("itm_Model")
                    .HasMaxLength(50);

                entity.Property(e => e.ItmMonthlyTarget)
                    .HasColumnName("itm_monthlyTarget")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmName)
                    .HasColumnName("itm_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.ItmOpeningStock)
                    .HasColumnName("itm_OpeningStock")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmPrintCaption)
                    .HasColumnName("itm_PrintCaption")
                    .HasMaxLength(500);

                entity.Property(e => e.ItmProductTypeId).HasColumnName("itm_ProductTypeId");

                entity.Property(e => e.ItmPunitToSunit)
                    .HasColumnName("itm_PunitToSUnit")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmPurchaseUnitId).HasColumnName("itm_PurchaseUnitId");

                entity.Property(e => e.ItmRackId).HasColumnName("itm_RackId");

                entity.Property(e => e.ItmRol)
                    .HasColumnName("itm_ROL")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmRoq)
                    .HasColumnName("itm_ROQ")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItmSalesUnitId).HasColumnName("itm_SalesUnitId");

                entity.Property(e => e.ItmSpecification)
                    .HasColumnName("itm_Specification")
                    .HasMaxLength(50);

                entity.Property(e => e.ItmStkTypeId).HasColumnName("itm_StkTypeId");

                entity.Property(e => e.ItmSubGrpId).HasColumnName("itm_SubGrpId");

                entity.Property(e => e.ItmUserId).HasColumnName("itm_UserId");

                entity.Property(e => e.ItmWarrantyInMonths).HasColumnName("itm_WarrantyInMonths");

                entity.HasOne(d => d.ItmBrand)
                    .WithMany(p => p.MItemMaster)
                    .HasForeignKey(d => d.ItmBrandId)
                    .HasConstraintName("FK__mItemMast__itm_B__18EBB532");

                entity.HasOne(d => d.ItmGdn)
                    .WithMany(p => p.MItemMaster)
                    .HasForeignKey(d => d.ItmGdnId)
                    .HasConstraintName("FK__mItemMast__itm_G__19DFD96B");

                entity.HasOne(d => d.ItmMfr)
                    .WithMany(p => p.MItemMaster)
                    .HasForeignKey(d => d.ItmMfrId)
                    .HasConstraintName("FK__mItemMast__itm_M__17F790F9");

                entity.HasOne(d => d.ItmProductType)
                    .WithMany(p => p.MItemMaster)
                    .HasForeignKey(d => d.ItmProductTypeId)
                    .HasConstraintName("FK__mItemMast__itm_P__14270015");

                entity.HasOne(d => d.ItmPurchaseUnit)
                    .WithMany(p => p.MItemMasterItmPurchaseUnit)
                    .HasForeignKey(d => d.ItmPurchaseUnitId)
                    .HasConstraintName("FK__mItemMast__itm_P__160F4887");

                //entity.HasOne(d => d.ItmRack)
                //    .WithMany(p => p.mGodown)
                //    .HasForeignKey(d => d.ItmRackId)
                //    .HasConstraintName("FK__mItemMast__itm_R__1AD3FDA4");

                entity.HasOne(d => d.ItmSalesUnit)
                    .WithMany(p => p.MItemMasterItmSalesUnit)
                    .HasForeignKey(d => d.ItmSalesUnitId)
                    .HasConstraintName("FK__mItemMast__itm_S__17036CC0");

                entity.HasOne(d => d.ItmStkType)
                    .WithMany(p => p.MItemMaster)
                    .HasForeignKey(d => d.ItmStkTypeId)
                    .HasConstraintName("FK__mItemMast__itm_S__1332DBDC");

                entity.HasOne(d => d.ItmSubGrp)
                    .WithMany(p => p.MItemMaster)
                    .HasForeignKey(d => d.ItmSubGrpId)
                    .HasConstraintName("FK__mItemMast__itm_S__151B244E");
            });
            modelBuilder.Entity<MManufacturer>(entity =>
            {
                entity.HasKey(e => e.MfrId)
                    .HasName("PK__mManufac__8112742E6141AE4C");

                entity.ToTable("mManufacturer");

                entity.Property(e => e.MfrId).HasColumnName("mfr_Id");

                entity.Property(e => e.MfrBranchId).HasColumnName("mfr_BranchId");

                entity.Property(e => e.MfrDescription)
                    .HasColumnName("mfr_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.MfrUserId).HasColumnName("mfr_UserId");
            });

            modelBuilder.Entity<MProductTypeStatic>(entity =>
            {
                entity.ToTable("mProductTypeStatic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MStockTypeStatic>(entity =>
            {
                entity.ToTable("mStockTypeStatic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StockType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //******************************

            modelBuilder.Entity<MGodown>(entity =>
            {
                ////entity.HasOne(d => d.incharge)
                ////    .WithMany(p => p.GdnIncharge)
                ////    .HasForeignKey(d => d.GdnInCharge)
                ////    .HasConstraintName("FK__mGodown__gdn_InC__04E4BC85");

                entity.HasMany(d => d.Racks )
                  .WithOne(p => p.mGodown )
                  .HasForeignKey(c=>c.gdnRk_GodownId)
                  .OnDelete(DeleteBehavior.Cascade);
              
            });


            modelBuilder.Entity<MIadditionalTax>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PK__mIAdditi__61F955B0000B9F45");

                entity.ToTable("mIAdditionalTax");

                entity.Property(e => e.AtId).HasColumnName("at_Id");

                entity.Property(e => e.AtApplicableOn)
                    .HasColumnName("at_ApplicableOn")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AtBranchId).HasColumnName("at_BranchId");

                entity.Property(e => e.AtDescription)
                    .HasColumnName("at_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.AtPercentage)
                    .HasColumnName("at_Percentage")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AtUserId).HasColumnName("at_UserId");
            });
            modelBuilder.Entity<MTax>(entity =>
            {
                entity.HasKey(e => e.TxId)
                    .HasName("PK__mTax__65EDB0F9CEB32BD7");

                entity.ToTable("mTax");

                entity.Property(e => e.TxId).HasColumnName("tx_Id");

                entity.Property(e => e.TxAccountHeadId).HasColumnName("tx_AccountHeadId");

                entity.Property(e => e.TxBranchId).HasColumnName("tx_BranchId");

                entity.Property(e => e.TxDescription)
                    .HasColumnName("tx_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.TxPercentage)
                    .HasColumnName("tx_Percentage")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TxTaxTypeId).HasColumnName("tx_TaxTypeId");

                entity.Property(e => e.TxUserId).HasColumnName("tx_UserId");

                entity.HasOne(d => d.TxTaxType)
                    .WithMany(p => p.MTax)
                    .HasForeignKey(d => d.TxTaxTypeId)
                    .HasConstraintName("FK__mTax__tx_taxType__1920BF5C");
            });

            modelBuilder.Entity<MTaxType>(entity =>
            {
                entity.HasKey(e => e.TxTypId)
                    .HasName("PK__mTaxType__03916151C26F9A1F");

                entity.ToTable("mTaxType");

                entity.Property(e => e.TxTypId).HasColumnName("txTyp_Id");

                entity.Property(e => e.TxTypBranchId).HasColumnName("txTyp_BranchId");

                entity.Property(e => e.TxTypDescription)
                    .HasColumnName("txTyp_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.TxTypUserId).HasColumnName("txTyp_UserId");
            });
            modelBuilder.Entity<MItemGroup>(entity =>
            {
                entity.HasKey(e => e.IgId)
                    .HasName("PK__mItemGro__4BB28B71F7D2D72B");

                entity.ToTable("mItemGroup");

                entity.Property(e => e.IgId).HasColumnName("ig_Id");

                entity.Property(e => e.IgBranchId).HasColumnName("ig_BranchId");

                entity.Property(e => e.IgDescription)
                    .HasColumnName("ig_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.IgItemTypeId).HasColumnName("ig_ItemTypeId");

                entity.Property(e => e.IgUserId).HasColumnName("ig_UserId");

                entity.HasOne(d => d.IgItemType)
                    .WithMany(p => p.MItemGroup)
                    .HasForeignKey(d => d.IgItemTypeId)
                    .HasConstraintName("FK__mItemGrou__ig_it__145C0A3F");
            });

            modelBuilder.Entity<MItemSubGroup>(entity =>
            {
                entity.HasKey(e => e.IsgId)
                    .HasName("PK__mItemSub__53413C2F39A271ED");

                entity.ToTable("mItemSubGroup");

                entity.Property(e => e.IsgId).HasColumnName("isg_Id");

                entity.Property(e => e.IsgAdditionalTaxId).HasColumnName("isg_AdditionalTaxId");

                entity.Property(e => e.IsgBranchId).HasColumnName("isg_BranchId");

                entity.Property(e => e.IsgDescription)
                    .HasColumnName("isg_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.IsgIsDisplay).HasColumnName("isg_isDisplay");

                entity.Property(e => e.IsgIsTaxInclusive).HasColumnName("isg_IsTaxInclusive");

                entity.Property(e => e.IsgItemGroupId).HasColumnName("isg_itemGroupId");

                entity.Property(e => e.IsgTaxId).HasColumnName("isg_TaxId");

                entity.Property(e => e.IsgUserId).HasColumnName("isg_UserId");

                entity.HasOne(d => d.IsgAdditionalTax)
                    .WithMany(p => p.MItemSubGroup)
                    .HasForeignKey(d => d.IsgAdditionalTaxId)
                    .HasConstraintName("FK__mItemSubG__isg_A__1FCDBCEB");

                entity.HasOne(d => d.IsgItemGroup)
                    .WithMany(p => p.MItemSubGroup)
                    .HasForeignKey(d => d.IsgItemGroupId)
                    .HasConstraintName("FK__mItemSubG__isg_i__1DE57479");

                entity.HasOne(d => d.IsgTax)
                    .WithMany(p => p.MItemSubGroup)
                    .HasForeignKey(d => d.IsgTaxId)
                    .HasConstraintName("FK__mItemSubG__isg_T__1ED998B2");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.it_Id);

                entity.ToTable("mItemType");

                entity.Property(e => e.it_Id).HasColumnName("it_Id");

                entity.Property(e => e.it_BranchId).HasColumnName("it_BranchId");

                entity.Property(e => e.It_Description)
                    .HasColumnName("it_Description")
                    .HasMaxLength(100);

                entity.Property(e => e.it_UserId).HasColumnName("it_UserId");
            });
        }

       
        public DbSet<qizoErpWebApiApp.Model.Masters.MManufacturer> MManufacturer { get; set; }

       
        public DbSet<qizoErpWebApiApp.Model.Masters.MUnitMaster> MUnitMaster { get; set; }

       
        public DbSet<qizoErpWebApiApp.Model.Masters.MItemMaster> MItemMaster { get; set; }

       
        public DbSet<qizoErpWebApiApp.Model.Masters.MShippingLine> MShippingLine { get; set; }

       
       
    }
}
