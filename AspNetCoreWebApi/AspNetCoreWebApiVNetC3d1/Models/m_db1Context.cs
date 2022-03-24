using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreWebApiVNetC3d1.Models
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

        public virtual DbSet<m_rel_m_t1_m_t2> m_rel_m_t1_m_t2 { get; set; }
        public virtual DbSet<m_t1> m_t1 { get; set; }
        public virtual DbSet<m_t2> m_t2 { get; set; }
        public virtual DbSet<m_t3> m_t3 { get; set; }
        public virtual DbSet<m_v_1> m_v_1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=m_db1;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<m_rel_m_t1_m_t2>(entity =>
            {
                entity.HasKey(e => e.m_id)
                    .HasName("PK_m_rel_m_t1_m_t2_1");

                entity.HasIndex(e => e.m_t1_m_id)
                    .HasName("m_t1_m_id");

                entity.HasIndex(e => e.m_t2_m_id)
                    .HasName("m_t2_m_id");

                entity.Property(e => e.m_id).ValueGeneratedNever();

                entity.HasOne(d => d.m_t1_m_)
                    .WithMany(p => p.m_rel_m_t1_m_t2)
                    .HasForeignKey(d => d.m_t1_m_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_4");

                entity.HasOne(d => d.m_t2_m_)
                    .WithMany(p => p.m_rel_m_t1_m_t2)
                    .HasForeignKey(d => d.m_t2_m_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_2");
            });

            modelBuilder.Entity<m_t1>(entity =>
            {
                entity.HasKey(e => e.m_id);

                entity.Property(e => e.m_c1_text).HasMaxLength(50);

                entity.Property(e => e.m_c2_decimal).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<m_t2>(entity =>
            {
                entity.HasKey(e => e.m_id);

                entity.Property(e => e.m_c1_text)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<m_t3>(entity =>
            {
                entity.HasKey(e => e.m_id)
                    .HasName("PK_t3");

                entity.Property(e => e.m_id).ValueGeneratedOnAdd();

                entity.Property(e => e.m_text)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.m_)
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
