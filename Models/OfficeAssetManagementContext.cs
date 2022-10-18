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
        public virtual DbSet<AssetAssignment> AssetAssignments { get; set; } = null!;
        public virtual DbSet<Dictionary> Dictionaries { get; set; } = null!;
        public virtual DbSet<DictionaryValue> DictionaryValues { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

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

                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.Property(e => e.RemovedBy).HasMaxLength(150);
            });

            modelBuilder.Entity<AssetAssignment>(entity =>
            {
                entity.ToTable("AssetAssignment");

                entity.Property(e => e.AssetAssignmentId).HasColumnName("AssetAssignmentID");

                entity.Property(e => e.AddedBy).HasMaxLength(150);

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.RemovedBy).HasMaxLength(150);

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetAssignments)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK__AssetAssi__Asset__66603565");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssetAssignments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__AssetAssi__Emplo__656C112C");
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("Dictionary");

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.DisplayName).HasMaxLength(150);
            });

            modelBuilder.Entity<DictionaryValue>(entity =>
            {
                entity.HasKey(e => e.ValueId)
                    .HasName("PK__Dictiona__93364E686B96F2E2");

                entity.ToTable("DictionaryValue");

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.HasOne(d => d.Dictionary)
                    .WithMany(p => p.DictionaryValues)
                    .HasForeignKey(d => d.DictionaryId)
                    .HasConstraintName("FK__Dictionar__Dicti__4D94879B");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
