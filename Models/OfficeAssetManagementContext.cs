using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfficeAssetManager.Models
{
    public partial class OfficeAssetManagementContext : DbContext
    {
        public OfficeAssetManagementContext()
        {
        }

        public OfficeAssetManagementContext(DbContextOptions<OfficeAssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<Dictionary> Dictionaries { get; set; } = null!;
        public virtual DbSet<DictionaryValue> DictionaryValues { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<TempAsset> TempAssets { get; set; } = null!;
        public virtual DbSet<Tempdictionary> Tempdictionaries { get; set; } = null!;
        public virtual DbSet<Tempdictionaryvalue> Tempdictionaryvalues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=App\\SQLExpress;Database=OfficeAssetManagement;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AddedBy).HasMaxLength(150);

                entity.Property(e => e.AssetStatusId).HasColumnName("AssetStatusID");

                entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.Property(e => e.RemovedBy).HasMaxLength(150);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Asset__EmployeeI__6A30C649");
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("Dictionary");

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.DisplayName).HasMaxLength(150);
            });

            modelBuilder.Entity<DictionaryValue>(entity =>
            {
                entity.ToTable("DictionaryValue");

                entity.Property(e => e.DictionaryValueId).HasColumnName("DictionaryValueID");

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.HasOne(d => d.Dictionary)
                    .WithMany(p => p.DictionaryValues)
                    .HasForeignKey(d => d.DictionaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dictionar__Dicti__797309D9");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DisplayName).HasMaxLength(75);

                entity.Property(e => e.ExternalSystemId).HasColumnName("ExternalSystemID");

                entity.Property(e => e.FirstName).HasMaxLength(75);

                entity.Property(e => e.LastName).HasMaxLength(75);
            });

            modelBuilder.Entity<TempAsset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tempAssets");

                entity.Property(e => e.AddedBy).HasMaxLength(150);

                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.Property(e => e.RemovedBy).HasMaxLength(150);
            });

            modelBuilder.Entity<Tempdictionary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tempdictionary");

                entity.Property(e => e.DictionaryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DictionaryID");

                entity.Property(e => e.DisplayName).HasMaxLength(150);
            });

            modelBuilder.Entity<Tempdictionaryvalue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tempdictionaryvalue");

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.ValueId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ValueID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
