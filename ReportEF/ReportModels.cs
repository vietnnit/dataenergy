namespace ReportEF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReportModels : DbContext
    {
        public ReportModels()
            : base("name=ReportModels")
        {
        }
        public virtual DbSet<DE_UsingSystem> DE_UsingSystem { get; set; }
        public virtual DbSet<DE_ElectrictProduce> DE_ElectrictProduce { get; set; }
        public virtual DbSet<DE_ElectrictTechnology> DE_ElectrictTechnology { get; set; }
        public virtual DbSet<BC_SDNL_DS_TheoNam_Comment> BC_SDNL_DS_TheoNam_Comment { get; set; }
        public virtual DbSet<BC_SDNL_DS_TheoNam> BC_SDNL_DS_TheoNam { get; set; }
        public virtual DbSet<BC_SDNL_HangNam> BC_SDNL_HangNam { get; set; }
        public virtual DbSet<DE_Area> DE_Area { get; set; }
        public virtual DbSet<DE_AuditReport> DE_AuditReport { get; set; }
        public virtual DbSet<DE_Boiler> DE_Boiler { get; set; }
        public virtual DbSet<DE_Compressor> DE_Compressor { get; set; }
        public virtual DbSet<DE_District> DE_District { get; set; }
        public virtual DbSet<DE_ElectricMotors> DE_ElectricMotors { get; set; }
        public virtual DbSet<DE_ElectricSupplying> DE_ElectricSupplying { get; set; }
        public virtual DbSet<DE_ElectrictConsume> DE_ElectrictConsume { get; set; }
        public virtual DbSet<DE_EnergyQuota> DE_EnergyQuota { get; set; }
        public virtual DbSet<DE_Enterprise> DE_Enterprise { get; set; }
        public virtual DbSet<DE_EnterpriseHistory> DE_EnterpriseHistory { get; set; }
        public virtual DbSet<DE_EnterpriseLog> DE_EnterpriseLog { get; set; }
        public virtual DbSet<DE_EnterpriseYear> DE_EnterpriseYear { get; set; }
        public virtual DbSet<DE_Fuel> DE_Fuel { get; set; }
        public virtual DbSet<DE_Furnaces> DE_Furnaces { get; set; }
        public virtual DbSet<DE_GiaiPhap> DE_GiaiPhap { get; set; }
        public virtual DbSet<DE_GroupFuel> DE_GroupFuel { get; set; }
        public virtual DbSet<DE_Infrastructure> DE_Infrastructure { get; set; }
        public virtual DbSet<DE_Measurement> DE_Measurement { get; set; }
        public virtual DbSet<DE_MeasurementFuel> DE_MeasurementFuel { get; set; }
        public virtual DbSet<DE_Member> DE_Member { get; set; }
        public virtual DbSet<DE_OperationArea> DE_OperationArea { get; set; }
        public virtual DbSet<DE_Organization> DE_Organization { get; set; }
        public virtual DbSet<DE_OtherFuelConsume> DE_OtherFuelConsume { get; set; }
        public virtual DbSet<DE_Plan> DE_Plan { get; set; }
        public virtual DbSet<DE_PlanTB> DE_PlanTB { get; set; }
        public virtual DbSet<DE_PlanTKNL> DE_PlanTKNL { get; set; }
        public virtual DbSet<DE_Product> DE_Product { get; set; }
        public virtual DbSet<DE_ProductCapacity> DE_ProductCapacity { get; set; }
        public virtual DbSet<DE_ProductConsume> DE_ProductConsume { get; set; }
        public virtual DbSet<DE_ProductMeasurement> DE_ProductMeasurement { get; set; }
        public virtual DbSet<DE_ProductPlan> DE_ProductPlan { get; set; }
        public virtual DbSet<DE_Province> DE_Province { get; set; }
        public virtual DbSet<DE_Region> DE_Region { get; set; }
        public virtual DbSet<DE_RegionProvince> DE_RegionProvince { get; set; }
        public virtual DbSet<DE_ReportFuel> DE_ReportFuel { get; set; }
        public virtual DbSet<DE_ReportFuelDetail> DE_ReportFuelDetail { get; set; }
        public virtual DbSet<DE_ReportLog> DE_ReportLog { get; set; }
        public virtual DbSet<DE_ReportTemp2014> DE_ReportTemp2014 { get; set; }
        public virtual DbSet<DE_ReportTemplate> DE_ReportTemplate { get; set; }
        public virtual DbSet<DE_SaveSolution> DE_SaveSolution { get; set; }
        public virtual DbSet<DE_SubAreaEnterprise> DE_SubAreaEnterprise { get; set; }
        public virtual DbSet<DE_TestEquipment> DE_TestEquipment { get; set; }
        public virtual DbSet<DE_TOE> DE_TOE { get; set; }
        public virtual DbSet<DE_TOEYear> DE_TOEYear { get; set; }
        public virtual DbSet<DE_UsingElectrict> DE_UsingElectrict { get; set; }
        public virtual DbSet<PR_Project> PR_Project { get; set; }
        public virtual DbSet<PR_ProjectArea> PR_ProjectArea { get; set; }
        public virtual DbSet<PR_ProjectArticle> PR_ProjectArticle { get; set; }
        public virtual DbSet<PR_ProjectType> PR_ProjectType { get; set; }
        public virtual DbSet<Pr_ProType> Pr_ProType { get; set; }
        public virtual DbSet<SYS_PageLayout> SYS_PageLayout { get; set; }
        public virtual DbSet<SYS_TemplatePage> SYS_TemplatePage { get; set; }
        public virtual DbSet<SYS_Widget> SYS_Widget { get; set; }
        public virtual DbSet<SYS_WidgetPage> SYS_WidgetPage { get; set; }
        public virtual DbSet<SYS_WidgetPageLayout> SYS_WidgetPageLayout { get; set; }
        public virtual DbSet<SYS_WidgetType> SYS_WidgetType { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblAlbum> tblAlbums { get; set; }
        public virtual DbSet<tblAlbumsCate> tblAlbumsCates { get; set; }
        public virtual DbSet<tblBrand> tblBrands { get; set; }
        public virtual DbSet<tblCateNew> tblCateNews { get; set; }
        public virtual DbSet<tblCateNewsGroup> tblCateNewsGroups { get; set; }
        public virtual DbSet<tblConfig> tblConfigs { get; set; }
        public virtual DbSet<tblDocumentOrg> tblDocumentOrgs { get; set; }
        public virtual DbSet<tblDocumentType> tblDocumentTypes { get; set; }
        public virtual DbSet<tblFaqsCate> tblFaqsCates { get; set; }
        public virtual DbSet<tblMailContent> tblMailContents { get; set; }
        public virtual DbSet<tblMember> tblMembers { get; set; }
        public virtual DbSet<tblNewsCate> tblNewsCates { get; set; }
        public virtual DbSet<tblNewsEvent> tblNewsEvents { get; set; }
        public virtual DbSet<tblNewsEventRelation> tblNewsEventRelations { get; set; }
        public virtual DbSet<tblNewsGroup> tblNewsGroups { get; set; }
        public virtual DbSet<tblNewsGroupFile> tblNewsGroupFiles { get; set; }
        public virtual DbSet<tblNewsLog> tblNewsLogs { get; set; }
        public virtual DbSet<tblNewsRegister> tblNewsRegisters { get; set; }
        public virtual DbSet<tblNewsRelation> tblNewsRelations { get; set; }
        public virtual DbSet<tblOfficial> tblOfficials { get; set; }
        public virtual DbSet<tblOfficialFile> tblOfficialFiles { get; set; }
        public virtual DbSet<tblPermission> tblPermissions { get; set; }
        public virtual DbSet<tblPicture> tblPictures { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblRegister> tblRegisters { get; set; }
        public virtual DbSet<tblReport> tblReports { get; set; }
        public virtual DbSet<tblRoleCate> tblRoleCates { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblVideo> tblVideos { get; set; }
        public virtual DbSet<tblVideosCate> tblVideosCates { get; set; }
        public virtual DbSet<DE_ReportAttachFile> DE_ReportAttachFile { get; set; }
        public virtual DbSet<tblAdminRole> tblAdminRoles { get; set; }
        public virtual DbSet<tblCateNewsGroupPermission> tblCateNewsGroupPermissions { get; set; }
        public virtual DbSet<tblCateNewsPermission> tblCateNewsPermissions { get; set; }
        public virtual DbSet<tblContact> tblContacts { get; set; }
        public virtual DbSet<tblEmail> tblEmails { get; set; }
        public virtual DbSet<tblMenuLink> tblMenuLinks { get; set; }
        public virtual DbSet<tblModule> tblModules { get; set; }
        public virtual DbSet<tblNewsApprovedComment> tblNewsApprovedComments { get; set; }
        public virtual DbSet<tblNewsComment> tblNewsComments { get; set; }
        public virtual DbSet<tblNewsTag> tblNewsTags { get; set; }
        public virtual DbSet<tblTag> tblTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DE_ElectrictProduce>()
              .Property(e => e.InstalledCapacity)
              .HasPrecision(20, 2);

            modelBuilder.Entity<DE_ElectrictProduce>()
                .Property(e => e.ProduceQty)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_Boiler>()
                .Property(e => e.CapacityInstalled)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DE_District>()
                .Property(e => e.DistrictCode)
                .IsUnicode(false);

            modelBuilder.Entity<DE_ElectricMotors>()
                .Property(e => e.Capacity)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DE_ElectricMotors>()
                .Property(e => e.CapacityUsed)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DE_ElectricSupplying>()
                .Property(e => e.Coefficient)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DE_ElectricSupplying>()
                .Property(e => e.Performance)
                .HasPrecision(5, 2);

            modelBuilder.Entity<DE_ElectricSupplying>()
                .Property(e => e.RateOfSystem)
                .HasPrecision(5, 2);

            modelBuilder.Entity<DE_ElectricSupplying>()
                .Property(e => e.Cos)
                .HasPrecision(5, 2);

            modelBuilder.Entity<DE_EnergyQuota>()
                .Property(e => e.Quantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_EnterpriseYear>()
                .Property(e => e.No_TOE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DE_EnterpriseYear>()
                .Property(e => e.NoTOE_Plan)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DE_Furnaces>()
                .Property(e => e.CapacityInstalled)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DE_GroupFuel>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<DE_MeasurementFuel>()
                .Property(e => e.TOE)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DE_MeasurementFuel>()
                .Property(e => e.From_TOE)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DE_MeasurementFuel>()
                .Property(e => e.To_TOE)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DE_MeasurementFuel>()
                .Property(e => e.NoCO2)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DE_OtherFuelConsume>()
                .Property(e => e.Quantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_OtherFuelConsume>()
                .Property(e => e.Cost)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_Product>()
                .Property(e => e.Quantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_ProductCapacity>()
                .Property(e => e.MaxQuantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_ProductCapacity>()
                .Property(e => e.DesignQuantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_ProductCapacity>()
                .Property(e => e.RateOfCost)
                .HasPrecision(4, 2);

            modelBuilder.Entity<DE_ProductCapacity>()
                .Property(e => e.RateOfRevenue)
                .HasPrecision(4, 2);

            modelBuilder.Entity<DE_ProductConsume>()
                .Property(e => e.Quantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_ProductPlan>()
                .Property(e => e.RateCost)
                .HasPrecision(4, 2);

            modelBuilder.Entity<DE_ProductPlan>()
                .Property(e => e.RateRevenue)
                .HasPrecision(4, 2);

            modelBuilder.Entity<DE_ReportFuel>()
                .Property(e => e.NoFuel_TOE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DE_ReportFuelDetail>()
                .Property(e => e.NoFuel)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_ReportFuelDetail>()
                .Property(e => e.NoFuel_TOE)
                .HasPrecision(30, 2);

            modelBuilder.Entity<DE_ReportFuelDetail>()
                .Property(e => e.No_RateTOE)
                .HasPrecision(20, 10);

            modelBuilder.Entity<DE_ReportFuelDetail>()
                .Property(e => e.Price)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DE_ReportTemp2014>()
                .Property(e => e.No_TOE)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DE_SaveSolution>()
                .Property(e => e.Quantity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_SaveSolution>()
                .Property(e => e.Cost)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_SaveSolution>()
                .Property(e => e.Budget)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_SaveSolution>()
                .Property(e => e.TimeExecuted)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.BuyCost)
                .HasPrecision(20, 0);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.Quantity)
                .HasPrecision(12, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.Capacity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.InstalledCapacity)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.ProduceQty)
                .HasPrecision(12, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.PriceProduce)
                .HasPrecision(12, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.PriceBuy)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.AvgPrice)
                .HasPrecision(20, 2);
            modelBuilder.Entity<DE_UsingElectrict>()
                .Property(e => e.CongSuatBan)
                .HasPrecision(20, 2);

            modelBuilder.Entity<DE_UsingElectrict>()
               .Property(e => e.SanLuongBan)
               .HasPrecision(20, 2);

            modelBuilder.Entity<SYS_PageLayout>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_TemplatePage>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_WidgetPage>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_WidgetPageLayout>()
                .Property(e => e.RegionID)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_WidgetPageLayout>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_Username)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_Permission)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_NickYahoo)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_NickSkype)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Admin_Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbum>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbum>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbum>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbum>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbum>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbumsCate>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbumsCate>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbumsCate>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblAlbumsCate>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblBrand>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<tblBrand>()
                .Property(e => e.BrandUrl)
                .IsUnicode(false);

            modelBuilder.Entity<tblBrand>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNew>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNew>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNew>()
                .Property(e => e.Roles)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNew>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNew>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsGroup>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsGroup>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsGroup>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.new_icon_w)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.new_icon_h)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.new_thumb_w)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.new_thumb_h)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.new_large_w)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.new_large_h)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.product_icon_w)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.product_icon_h)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.product_thumb_w)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.product_thumb_h)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.product_large_w)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.product_large_h)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.productNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.productNoPage)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.currency)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.WebServerIP)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.WebMailServer)
                .IsUnicode(false);

            modelBuilder.Entity<tblConfig>()
                .Property(e => e.WebDomain)
                .IsUnicode(false);

            modelBuilder.Entity<tblFaqsCate>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<tblFaqsCate>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tblFaqsCate>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMailContent>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.NickYahoo)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.NickSkype)
                .IsUnicode(false);

            modelBuilder.Entity<tblMember>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsEvent>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsEvent>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsEvent>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsEvent>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsEvent>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsEvent>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroup>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsGroupFile>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsLog>()
                .Property(e => e.ModifyUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsRegister>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsRegister>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsRegister>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsRegister>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsRegister>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsRegister>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblOfficial>()
                .Property(e => e.Attached)
                .IsUnicode(false);

            modelBuilder.Entity<tblOfficial>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblOfficial>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblOfficial>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblOfficialFile>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblPermission>()
                .Property(e => e.PermissionName)
                .IsUnicode(false);

            modelBuilder.Entity<tblPermission>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<tblPicture>()
                .Property(e => e.PictureThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblPicture>()
                .Property(e => e.PictureLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.Phone1)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.Phone2)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.Phone3)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.NickYahoo)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.NickSkype)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.TN_Nam)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.TN_Mon1)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.TN_Mon2)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.TN_Mon3)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.TN_Mon4)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.TN_Mon5)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.DT_SBD)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.DT_Mon1)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.DT_Mon2)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.DT_Mon3)
                .IsUnicode(false);

            modelBuilder.Entity<tblRegister>()
                .Property(e => e.DT_Khoi)
                .IsUnicode(false);

            modelBuilder.Entity<tblRole>()
                .Property(e => e.Roles_Modules)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.CreatedUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.VideosUrl)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideosCate>()
                .Property(e => e.ImageThumb)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideosCate>()
                .Property(e => e.ImageLarge)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideosCate>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideosCate>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdminRole>()
                .Property(e => e.Admin_UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdminRole>()
                .Property(e => e.Permission)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdminRole>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsGroupPermission>()
                .Property(e => e.Permission)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsGroupPermission>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsGroupPermission>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsPermission>()
                .Property(e => e.Permission)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsPermission>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCateNewsPermission>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.Attact)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuLink>()
                .Property(e => e.MenuLinksIcon)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuLink>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuLink>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuLink>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuLink>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<tblModule>()
                .Property(e => e.Modules_Dir)
                .IsUnicode(false);

            modelBuilder.Entity<tblModule>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsApprovedComment>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblNewsComment>()
                .Property(e => e.ApprovalUserName)
                .IsUnicode(false);
        }
    }
}
