using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model.Database
{
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext()
        {
        }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BrandStore> BrandStores { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.17;Database=CompanyDB; User=christian; Password=Ch2867566*#$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__brand__companyId__267ABA7A");
            });

            modelBuilder.Entity<BrandStore>(entity =>
            {
                entity.ToTable("brandStore");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdStore).HasColumnName("idStore");

                entity.Property(e => e.Idbrand).HasColumnName("idbrand");

                entity.HasOne(d => d.IdStoreNavigation)
                    .WithMany(p => p.BrandStores)
                    .HasForeignKey(d => d.IdStore)
                    .HasConstraintName("FK__brandStor__idSto__2C3393D0");

                entity.HasOne(d => d.IdbrandNavigation)
                    .WithMany(p => p.BrandStores)
                    .HasForeignKey(d => d.Idbrand)
                    .HasConstraintName("FK__brandStor__idbra__2B3F6F97");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Documento)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.FullName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.IdStore).HasColumnName("idStore");

                entity.HasOne(d => d.IdStoreNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdStore)
                    .HasConstraintName("FK__employee__idStor__2F10007B");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
