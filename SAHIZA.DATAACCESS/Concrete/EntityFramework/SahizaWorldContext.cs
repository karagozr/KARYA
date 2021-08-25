using KARYA.CORE.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using SAHIZA.MODEL.Entities;
using System.Linq;

namespace SAHIZA.DATAACCESS.Concrete.EntityFramework
{
    public class SahizaWorldContext : DbContext
    {
        public string _connectionString;
        public SahizaWorldContext()
        {
            _connectionString = DbConnectionHelper.GetConnectionString("SAHIZAWORLDConnection");
        }
       
        public SahizaWorldContext(DbContextOptions<SahizaWorldContext> options) : base(options)
        {
            if (((SqlServerOptionsExtension)options.Extensions.Last()).MigrationsAssembly != "-")
            {
                _connectionString = ((SqlServerOptionsExtension)options.Extensions.Last()).ConnectionString;
            }
            else
            {
                _connectionString = DbConnectionHelper.GetConnectionString("SAHIZAWORLDConnection");
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BelgeDetay>()
            //    .HasOne<DizaynDetay>(s => s.DizaynDetay)
            //    .WithMany(ta => ta.BelgeDetays)
            //    .HasForeignKey(u => u.DizaynDetayId)
            //    .OnDelete(DeleteBehavior.SetNull);
        }

        #region STOK
        public DbSet<Stok> Stok { get; set; }
        public DbSet<StokHaraket> StokHaraket { get; set; }
        #endregion


        #region CARI
        public DbSet<Cari> Cari { get; set; }
        #endregion

        #region DIZAYN
        public DbSet<Dizayn> Dizayn { get; set; }
        public DbSet<DizaynDetay> DizaynDetay { get; set; }
        #endregion

        #region BELGE
        public DbSet<Belge> Belge { get; set; }
        public DbSet<BelgeDetay> BelgeDetay { get; set; }
        #endregion

        #region SERVIS
        public DbSet<Servis> Servis { get; set; }
        public DbSet<ServisMalzeme> ServisMalzeme { get; set; }
        #endregion
    }
}
