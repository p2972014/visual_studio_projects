using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreWebApp.Models.db1.Tables;

namespace AspNetCoreWebApp.Models.db1
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

        public virtual DbSet<m_rel_m_t1_m_t2> m_rel_m_t1_m_t2s { get; set; } = null!;
        public virtual DbSet<m_t1> m_t1s { get; set; } = null!;
        public virtual DbSet<m_t2> m_t2s { get; set; } = null!;
        public virtual DbSet<m_t3> m_t3s { get; set; } = null!;
        public virtual DbSet<m_v_1> m_v_1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=m_db1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<m_rel_m_t1_m_t2>(entity =>
            {
                entity.HasKey(e => e.m_id)
                    .HasName("PK_m_rel_m_t1_m_t2_1");

                entity.ToTable("m_rel_m_t1_m_t2");

                entity.HasIndex(e => e.m_t1_m_id, "m_t1_m_id");

                entity.HasIndex(e => e.m_t2_m_id, "m_t2_m_id");

                entity.Property(e => e.m_id).ValueGeneratedNever();

                entity.HasOne(d => d.m_t1_m)
                    .WithMany(p => p.m_rel_m_t1_m_t2s)
                    .HasForeignKey(d => d.m_t1_m_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_4");

                entity.HasOne(d => d.m_t2_m)
                    .WithMany(p => p.m_rel_m_t1_m_t2s)
                    .HasForeignKey(d => d.m_t2_m_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_2");
            });

            modelBuilder.Entity<m_t1>(entity =>
            {
                entity.HasKey(e => e.m_id);

                entity.ToTable("m_t1");

                entity.Property(e => e.m_c1_text).HasMaxLength(50);

                entity.Property(e => e.m_c2_decimal).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<m_t2>(entity =>
            {
                entity.HasKey(e => e.m_id);

                entity.ToTable("m_t2");

                entity.Property(e => e.m_c1_text).HasMaxLength(255);
            });

            modelBuilder.Entity<m_t3>(entity =>
            {
                entity.HasKey(e => e.m_id)
                    .HasName("PK_t3");

                entity.ToTable("m_t3");

                entity.Property(e => e.m_id).ValueGeneratedOnAdd();

                entity.Property(e => e.m_text).HasMaxLength(50);

                entity.HasOne(d => d.m_idNavigation)
                    .WithOne(p => p.m_t3)
                    .HasForeignKey<m_t3>(d => d.m_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_t3_t3");
            });

            modelBuilder.Entity<m_v_1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("m_v_1");

                entity.Property(e => e.m_c2_decimal).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
