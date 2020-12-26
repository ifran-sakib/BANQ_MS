using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BANQ_MS.Models
{
    public partial class BANQ_MS_DBContext : DbContext
    {
        public BANQ_MS_DBContext()
        {
        }

        public BANQ_MS_DBContext(DbContextOptions<BANQ_MS_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BanqAmenity> BanqAmenity { get; set; }
        public virtual DbSet<BanqCustomer> BanqCustomer { get; set; }
        public virtual DbSet<BanqEventManager> BanqEventManager { get; set; }
        public virtual DbSet<BanqFood> BanqFood { get; set; }
        public virtual DbSet<BanqFoodCategory> BanqFoodCategory { get; set; }
        public virtual DbSet<BanqInfo> BanqInfo { get; set; }
        public virtual DbSet<BanqProgram> BanqProgram { get; set; }
        public virtual DbSet<BanqProgramAmenity> BanqProgramAmenity { get; set; }
        public virtual DbSet<BanqProgramFood> BanqProgramFood { get; set; }
        public virtual DbSet<BanqType> BanqType { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TETVEDS;Database=BANQ_MS_DB;User Id=sa; Password=12345;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BanqAmenity>(entity =>
            {
                entity.Property(e => e.AmenityHead)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Details).HasMaxLength(250);
            });

            modelBuilder.Entity<BanqCustomer>(entity =>
            {
                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nid)
                    .HasColumnName("NID")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);
            });

            modelBuilder.Entity<BanqEventManager>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EventOrganizerName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BanqFood>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FoodNo).HasMaxLength(10);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.BanqFood)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanqFood_BanqFoodCategory");
            });

            modelBuilder.Entity<BanqFoodCategory>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BanqInfo>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Location).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Rent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ScPer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VatPer).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.BanqType)
                    .WithMany(p => p.BanqInfo)
                    .HasForeignKey(d => d.BanqTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanqInfo_BanqType");
            });

            modelBuilder.Entity<BanqProgram>(entity =>
            {
                entity.Property(e => e.AmenityAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DueAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FoodAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HallRent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramDate).HasColumnType("datetime");

                entity.Property(e => e.ProgramName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPayable).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalServiceCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalVat).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Banq)
                    .WithMany(p => p.BanqProgram)
                    .HasForeignKey(d => d.BanqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanqProgram_BanqInfo");

                entity.HasOne(d => d.EventMngr)
                    .WithMany(p => p.BanqProgram)
                    .HasForeignKey(d => d.EventMngrId)
                    .HasConstraintName("FK_BanqProgram_BanqEventManager");
            });

            modelBuilder.Entity<BanqProgramAmenity>(entity =>
            {
                entity.HasOne(d => d.Amenity)
                    .WithMany(p => p.BanqProgramAmenity)
                    .HasForeignKey(d => d.AmenityId)
                    .HasConstraintName("FK_BanqProgramAmenity_BanqAmenity");

                entity.HasOne(d => d.BanqPro)
                    .WithMany(p => p.BanqProgramAmenity)
                    .HasForeignKey(d => d.BanqProId)
                    .HasConstraintName("FK_BanqProgramAmenity_BanqProgram");
            });

            modelBuilder.Entity<BanqProgramFood>(entity =>
            {
                entity.HasOne(d => d.BanqPro)
                    .WithMany(p => p.BanqProgramFood)
                    .HasForeignKey(d => d.BanqProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanqProgramFood_BanqProgram");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.BanqProgramFood)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanqProgramFood_BanqFood");
            });

            modelBuilder.Entity<BanqType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
