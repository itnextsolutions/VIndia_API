//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace VastraIndiaWebAPI.Models
//{
//    public partial class CoreDbContext : DbContext
//    {
//        public CoreDbContext()
//        {
//        }

//        public CoreDbContext(DbContextOptions<CoreDbContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<TblBlog> TblBlog { get; set; }
//        public virtual DbSet<TblCustomerReview> TblCustomerReview { get; set; }
//        public virtual DbSet<TblLogin> TblLogin { get; set; }
//        public virtual DbSet<TblLookupDetails> TblLookupDetails { get; set; }
//        public virtual DbSet<TblLookupMaster> TblLookupMaster { get; set; }
//        public virtual DbSet<TblProduct> TblProduct { get; set; }
//        public virtual DbSet<TblProductCategory> TblProductCategory { get; set; }
//        public virtual DbSet<TblProductColor> TblProductColor { get; set; }
//        public virtual DbSet<TblProductSize> TblProductSize { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-44Q6036;Database=VastraIndia;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<TblCustomerReview>(entity =>
//            {
//                entity.HasKey(e => e.CustomerReviewId)
//                    .HasName("PK_tbl_Customer-Review");
//            });

//            modelBuilder.Entity<TblLookupDetails>(entity =>
//            {
//                entity.HasKey(e => e.LookupDetailsId)
//                    .HasName("PK_tbl_Lookup-Details");
//            });

//            modelBuilder.Entity<TblLookupMaster>(entity =>
//            {
//                entity.HasKey(e => e.LookupId)
//                    .HasName("PK_tbl_Lookup-Master");
//            });

//            modelBuilder.Entity<TblProductCategory>(entity =>
//            {
//                entity.HasKey(e => e.Category_Id)
//                    .HasName("PK_tbl_Product-Category");
//            });

//            modelBuilder.Entity<TblProductColor>(entity =>
//            {
//                entity.HasKey(e => e.ProductColorId)
//                    .HasName("PK_tbl_Product-Color");
//            });

//            modelBuilder.Entity<TblProductSize>(entity =>
//            {
//                entity.HasKey(e => e.ProductSizeId)
//                    .HasName("PK_tbl_Product-Size");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
