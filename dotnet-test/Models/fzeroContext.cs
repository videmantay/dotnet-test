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
          /*   if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer();
            } */
        }

    }
}
