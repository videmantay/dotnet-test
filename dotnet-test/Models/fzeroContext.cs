using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_test.Models
{
    public partial class fzeroContext : DbContext
    {
        public fzeroContext()
        {
        }

        public fzeroContext(DbContextOptions<fzeroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crafts> Crafts { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Platforms> Platforms { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TestPoints> TestPoints { get; set; }
        public virtual DbSet<TestingBlock> TestingBlock { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersHasRoles> UsersHasRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Authentication=SqlPassword;Server=.;Database=fzero;User ID=sa;Password=tanilo,Dedman75");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crafts>(entity =>
            {
                entity.HasKey(e => e.SerialNum)
                    .HasName("PK__Crafts__EB2672A3D4E359CC");

                entity.HasIndex(e => e.PlatformId)
                    .HasName("platform_fk_idx");

                entity.Property(e => e.SerialNum).ValueGeneratedNever();

                entity.Property(e => e.CommisionDate).HasColumnType("datetime");

                entity.Property(e => e.DecommisionDate).HasColumnType("datetime");

                entity.Property(e => e.TopSpeed).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Torque).HasColumnType("decimal(6, 0)");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.Crafts)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("platform_fk");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.HasKey(e => new { e.TestId, e.CraftSerialNum, e.UserId })
                    .HasName("PK__Particip__25E001AB8B5249B0");

                entity.HasIndex(e => new { e.UserId, e.TestId, e.CraftSerialNum })
                    .HasName("fk_Tests_has_Users_Tests_idx");

                entity.Property(e => e.Duty)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Quals)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tests_has_Users_Users");

                entity.HasOne(d => d.Tests)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => new { d.TestId, d.CraftSerialNum })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tests_has_Users_Tests1");
            });

            modelBuilder.Entity<Platforms>(entity =>
            {
                entity.HasKey(e => e.PlatformId)
                    .HasName("PK__Platform__F559F6FABB92C0B1");

                entity.Property(e => e.PlatformId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Maxload).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Topspeed).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(4, 0)");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1A2ED4015E");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestPoints>(entity =>
            {
                entity.HasKey(e => new { e.TestPointId, e.TestingBlockId, e.TestId, e.TestCraftSerialNum })
                    .HasName("PK__TestPoin__535D1111E1E42452");

                entity.HasIndex(e => new { e.TestingBlockId, e.TestId, e.TestCraftSerialNum })
                    .HasName("fk_TestPoints_TestingBlock1_idx");

                entity.Property(e => e.Conditions)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Result).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestPoints)
                    .HasForeignKey(d => new { d.TestingBlockId, d.TestId, d.TestCraftSerialNum })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TestPoints_TestingBlock1");
            });

            modelBuilder.Entity<TestingBlock>(entity =>
            {
                entity.HasKey(e => new { e.TestingBlockId, e.TestId, e.TestCraftSerialNum })
                    .HasName("PK__TestingB__CDACE70538A5776C");

                entity.HasIndex(e => new { e.TestId, e.TestCraftSerialNum })
                    .HasName("fk_TestingBlock_Tests1_idx");

                entity.Property(e => e.Focus)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestingBlock)
                    .HasForeignKey(d => new { d.TestId, d.TestCraftSerialNum })
                    .HasConstraintName("fk_TestingBlock_Tests");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasKey(e => new { e.TestId, e.CraftSerialNum })
                    .HasName("PK__Tests__68F789675992A98A");

                entity.HasIndex(e => e.CraftSerialNum)
                    .HasName("fk_Tests_Crafts1_idx");

                entity.Property(e => e.TestDate).HasColumnType("datetime");

                entity.HasOne(d => d.CraftSerialNumNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.CraftSerialNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tests_Crafts1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4CF1B27AF1");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CallName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersHasRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__UsersHas__AF2760AD4BE79315");

                entity.HasIndex(e => e.RoleId)
                    .HasName("fk_Users_has_Roles_Roles1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Users_has_Roles_Users_idx");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersHasRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_Users_has_Roles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersHasRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Users_has_Roles_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
