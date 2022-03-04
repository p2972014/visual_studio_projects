using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreWebApi.Models
{
    public partial class m_db1Context : DbContext
    {
        public m_db1Context()
        {
        }

        public m_db1Context(DbContextOptions<m_db1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<MRelMT1MT2> MRelMT1MT2s { get; set; } = null!;
        public virtual DbSet<MT1> MT1s { get; set; } = null!;
        public virtual DbSet<MT2> MT2s { get; set; } = null!;
        public virtual DbSet<MT3> MT3s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=m_db1;Trusted_Connection=True;User ID=sa;Password=QWE098spv");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MRelMT1MT2>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK_m_rel_m_t1_m_t2_1");

                entity.ToTable("m_rel_m_t1_m_t2");

                entity.HasIndex(e => e.MT1MId, "m_t1_m_id");

                entity.HasIndex(e => e.MT2MId, "m_t2_m_id");

                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("m_id");

                entity.Property(e => e.MT1MId).HasColumnName("m_t1_m_id");

                entity.Property(e => e.MT2MId).HasColumnName("m_t2_m_id");

                entity.HasOne(d => d.MT1M)
                    .WithMany(p => p.MRelMT1MT2s)
                    .HasForeignKey(d => d.MT1MId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_4");

                entity.HasOne(d => d.MT2M)
                    .WithMany(p => p.MRelMT1MT2s)
                    .HasForeignKey(d => d.MT2MId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_2");
            });

            modelBuilder.Entity<MT1>(entity =>
            {
                entity.HasKey(e => e.MId);

                entity.ToTable("m_t1");

                entity.Property(e => e.MId).HasColumnName("m_id");

                entity.Property(e => e.MC1Text)
                    .HasMaxLength(50)
                    .HasColumnName("m_c1_text");

                entity.Property(e => e.MC2Decimal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("m_c2_decimal");

                entity.Property(e => e.MC3Date).HasColumnName("m_c3_date");
            });

            modelBuilder.Entity<MT2>(entity =>
            {
                entity.HasKey(e => e.MId);

                entity.ToTable("m_t2");

                entity.Property(e => e.MId).HasColumnName("m_id");

                entity.Property(e => e.MC1Text)
                    .HasMaxLength(255)
                    .HasColumnName("m_c1_text");
            });

            modelBuilder.Entity<MT3>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK_t3");

                entity.ToTable("m_t3");

                entity.Property(e => e.MId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("m_id");

                entity.Property(e => e.MT1MId).HasColumnName("m_t1_m_id");

                entity.Property(e => e.MText)
                    .HasMaxLength(50)
                    .HasColumnName("m_text");

                entity.HasOne(d => d.MIdNavigation)
                    .WithOne(p => p.MT3)
                    .HasForeignKey<MT3>(d => d.MId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t3_t3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
