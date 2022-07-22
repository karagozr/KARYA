using HANEL.MODEL.Entities;
using HANEL.MODEL.Entities.Finance;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.CORE.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Linq;

namespace HANEL.DATAACCESS.Concrete.EntityFramework.Context
{
    public class HanelContext : DbContext
    {
        public string _connectionString;
        public HanelContext()
        {
            _connectionString = DbConnectionHelper.GetConnectionString("HANELConnection");
        }
       
        public HanelContext(DbContextOptions<HanelContext> options) : base(options)
        {
            if (((SqlServerOptionsExtension)options.Extensions.Last()).MigrationsAssembly != "-")
            {
                _connectionString = ((SqlServerOptionsExtension)options.Extensions.Last()).ConnectionString;
            }
            else
            {
                _connectionString = DbConnectionHelper.GetConnectionString("HANELConnection");
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<ReportCode> ReportCode { get; set; }
        public DbSet<ReportCodeUserFilter> ReportCodeUserFilter { get; set; }
        public DbSet<Budget> Budget { get; set; }

        public DbSet<BudgetDetail> BudgetDetail { get; set; }

        public DbSet<BudgetSubDetail> BudgetSubDetail { get; set; }


        public DbSet<BudgetExchangeRate> BudgetExchangeRate { get; set; }

        public DbSet<PivotReportTemplate> PivotReportTemplate { get; set; }

        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<FaturaKalem> FaturaKalem { get; set; }
        public DbSet<FaturaKalemVergi> FaturaKalemVergi { get; set; }
        public DbSet<FaturaVergiKalem> FaturaVergiKalem { get; set; }
        public DbSet<OtoFatura> OtoFatura { get; set; }
        public DbSet<OtoFaturaDetay> OtoFaturaDetay { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
