using KARYA.DATAACCESS.Helpers;
using KARYA.MODEL.Entities.Karya;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Context
{
    public class KaryaContext : DbContext
    {
        public string _connectionString;

        public KaryaContext()
        {
            _connectionString = DbHelper.GetConnectionString("KARYAConnection");
        }
        public KaryaContext(DbContextOptions<KaryaContext> options) : base(options)
        {
            if (((SqlServerOptionsExtension)options.Extensions.Last()).MigrationsAssembly != "-")
            {
                _connectionString = ((SqlServerOptionsExtension)options.Extensions.Last()).ConnectionString;
            }
            else
            {
                _connectionString = DbHelper.GetConnectionString("KARYAConnection");
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<AuthorizeGroup>()
            .HasMany(e => e.AuthorizeGroupDetails).WithOne(x => x.AuthorizeGroup)
            .OnDelete(DeleteBehavior.ClientCascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        #region USER
        public DbSet<Users> Users { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<UserAuthorizeGroup> UserAuthorizeGroup { get; set; }
        #endregion

        #region AUTHORIZE
        public DbSet<AuthorizeGroup> AuthorizeGroup { get; set; }
        public DbSet<AuthorizeGroupDetail> AuthorizeGroupDetail { get; set; }
        public DbSet<AuthorizeGroupDetailFieldAccess> AuthorizeGroupDetailFieldAccess { get; set; }
        public DbSet<AppModule> AppModule { get; set; }
        public DbSet<FieldGroup> FieldGroup { get; set; }
        public DbSet<Field> Field { get; set; }
        #endregion

        #region APP_PARAM
        public DbSet<AppParameter> AppParameter { get; set; }
        #endregion

    }
}
