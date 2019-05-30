using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _2DChart.Data.Models
{
    public partial class ChartDbContext : DbContext
    {
        public ChartDbContext()
        {
        }

        public ChartDbContext(DbContextOptions<ChartDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChaFun> ChaFun { get; set; }
        public virtual DbSet<ChaRep> ChaRep { get; set; }
        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<FunPar> FunPar { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }
        public virtual DbSet<UseRep> UseRep { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=graphdb;GuidFormat=Char36;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChaFun>(entity =>
            {
                entity.HasKey(e => new { e.ChaId, e.FunId })
                    .HasName("PRIMARY");

                entity.ToTable("cha_fun");

                entity.HasIndex(e => e.ChaId)
                    .HasName("ChaId");

                entity.HasIndex(e => e.FunId)
                    .HasName("FunId");

                entity.Property(e => e.ChaId).HasColumnType("char(36)");

                entity.Property(e => e.FunId).HasColumnType("char(36)");

                entity.HasOne(d => d.Cha)
                    .WithMany(p => p.ChaFun)
                    .HasForeignKey(d => d.ChaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cha_fun_ibfk_1");

                entity.HasOne(d => d.Fun)
                    .WithMany(p => p.ChaFun)
                    .HasForeignKey(d => d.FunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cha_fun_ibfk_2");
            });

            modelBuilder.Entity<ChaRep>(entity =>
            {
                entity.HasKey(e => new { e.ChaId, e.RepId })
                    .HasName("PRIMARY");

                entity.ToTable("cha_rep");

                entity.HasIndex(e => e.RepId)
                    .HasName("RepId");

                entity.HasIndex(e => new { e.ChaId, e.RepId })
                    .HasName("ChaId");

                entity.Property(e => e.ChaId).HasColumnType("char(36)");

                entity.Property(e => e.RepId).HasColumnType("char(36)");

                entity.HasOne(d => d.Cha)
                    .WithMany(p => p.ChaRep)
                    .HasForeignKey(d => d.ChaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cha_rep_ibfk_1");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.ChaRep)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cha_rep_ibfk_2");
            });

            modelBuilder.Entity<Chart>(entity =>
            {
                entity.ToTable("chart");

                entity.Property(e => e.ChartId).HasColumnType("char(36)");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<FunPar>(entity =>
            {
                entity.HasKey(e => new { e.FunId, e.ParId })
                    .HasName("PRIMARY");

                entity.ToTable("fun_par");

                entity.HasIndex(e => e.FunId)
                    .HasName("FunId");

                entity.HasIndex(e => e.ParId)
                    .HasName("ParId");

                entity.Property(e => e.FunId).HasColumnType("char(36)");

                entity.Property(e => e.ParId).HasColumnType("char(36)");

                entity.HasOne(d => d.Fun)
                    .WithMany(p => p.FunPar)
                    .HasForeignKey(d => d.FunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fun_par_ibfk_1");

                entity.HasOne(d => d.Par)
                    .WithMany(p => p.FunPar)
                    .HasForeignKey(d => d.ParId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fun_par_ibfk_2");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.Property(e => e.FunctionId).HasColumnType("char(36)");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("parameter");

                entity.Property(e => e.ParameterId).HasColumnType("char(36)");

                entity.Property(e => e.Variable)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.ToTable("repository");

                entity.Property(e => e.RepositoryId).HasColumnType("char(36)");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<UseRep>(entity =>
            {
                entity.HasKey(e => new { e.UseId, e.RepId })
                    .HasName("PRIMARY");

                entity.ToTable("use_rep");

                entity.HasIndex(e => e.RepId)
                    .HasName("RepId");

                entity.HasIndex(e => e.UseId)
                    .HasName("UseId");

                entity.Property(e => e.UseId).HasColumnType("char(36)");

                entity.Property(e => e.RepId).HasColumnType("char(36)");

                entity.Property(e => e.IsOwner).HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Rep)
                    .WithMany(p => p.UseRep)
                    .HasForeignKey(d => d.RepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("use_rep_ibfk_2");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.UseRep)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("use_rep_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnType("char(36)");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128);
            });
        }
    }
}
