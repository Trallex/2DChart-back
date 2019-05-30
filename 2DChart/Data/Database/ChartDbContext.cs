using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Models;

namespace _2DChart.Data.Database
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

        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }
        public virtual DbSet<UseRep> UseRep { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chart>(entity =>
            {
                entity.ToTable("chart");

                entity.HasIndex(e => e.RepositoryId)
                    .HasName("chart_ibfk_1_idx");

                entity.Property(e => e.ChartId).HasColumnType("char(36)");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.RepositoryId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.Charts)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chart_ibfk_1");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.HasIndex(e => e.ChartId)
                    .HasName("function_ibfk_1_idx");

                entity.Property(e => e.FunctionId).HasColumnType("char(36)");

                entity.Property(e => e.ChartId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Chart)
                    .WithMany(p => p.Functions)
                    .HasForeignKey(d => d.ChartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("function_ibfk_1");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("parameter");

                entity.HasIndex(e => e.FunctionId)
                    .HasName("parameter_ibfk_1_idx");

                entity.Property(e => e.ParameterId).HasColumnType("char(36)");

                entity.Property(e => e.FunctionId)
                    .IsRequired()
                    .HasColumnType("char(36)");

                entity.Property(e => e.Variable)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("parameter_ibfk_1");
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
