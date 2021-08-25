using KARYA.CORE.Concrete.EntityFramework;
using KARYA.DATAACCESS.Abstract.Hanel;
using KARYA.DATAACCESS.Abstract.Hanel.Finance;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using KARYA.MODEL.Dtos.Hanel.Finance.Budget;
using KARYA.MODEL.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Hanel.Finance
{
    public class BudgetDetailDal : EfRepository<BudgetDetail, HanelContext>, IBudgetDetailDal
    {
        public async Task<IEnumerable<BudgetWithMonthsDto>> ListOfBudgetWithMonths(Expression<Func<BudgetDetail, bool>> filter)
        {
            using (var context = new HanelContext())
            {
                var res = filter == null ? 
                    (await context.Set<BudgetDetail>().Select(x => new BudgetWithMonthsDto
                {
                    Id = x.Budget.Id,
                    BudgetYear = x.Budget.BudgetYear,
                    BudgetMainCode = x.Budget.BudgetMainCode,
                    BudgetMainCodeDesc = "",
                    BudgetSubCode = x.Budget.BudgetSubCode,
                    BudgetSubCodeDesc = "",
                    BudgetType=x.Budget.BudgetType,
                    BranchCode=x.Budget.BranchCode,
                    SiteCode = x.Budget.SiteCode,
                    Description1 = x.Budget.Description1,
                    Description2 = x.Budget.Description2,
                    Description3 = x.Budget.Description3,
                    Ocak    = x.BudgetMonth==1 ? x.Amount:0,
                    Subat   = x.BudgetMonth==2 ? x.Amount:0,
                    Mart    = x.BudgetMonth==3 ? x.Amount:0,
                    Nisan   = x.BudgetMonth==4 ? x.Amount:0,
                    Mayis   = x.BudgetMonth==5 ? x.Amount:0,
                    Haziran = x.BudgetMonth==6 ? x.Amount:0,
                    Temmuz  = x.BudgetMonth==7 ? x.Amount:0,
                    Agustos = x.BudgetMonth==8 ? x.Amount:0,
                    Eylul   = x.BudgetMonth==9 ? x.Amount:0,
                    Ekim    = x.BudgetMonth==10 ? x.Amount:0,
                    Kasim   = x.BudgetMonth==11 ? x.Amount:0,
                    Aralik  = x.BudgetMonth==12 ? x.Amount:0,

                    OcakId      = x.BudgetMonth==1  ? x.Id:0,
                    SubatId     = x.BudgetMonth==2  ? x.Id:0,
                    MartId      = x.BudgetMonth==3  ? x.Id:0,
                    NisanId     = x.BudgetMonth==4  ? x.Id:0,
                    MayisId     = x.BudgetMonth==5  ? x.Id:0,
                    HaziranId   = x.BudgetMonth==6  ? x.Id:0,
                    TemmuzId    = x.BudgetMonth==7  ? x.Id:0,
                    AgustosId   = x.BudgetMonth==8  ? x.Id:0,
                    EylulId     = x.BudgetMonth==9  ? x.Id:0,
                    EkimId      = x.BudgetMonth==10 ? x.Id:0,
                    KasimId     = x.BudgetMonth==11 ? x.Id:0,
                    AralikId    = x.BudgetMonth==12 ? x.Id:0

                }).GroupBy(x => new
                {
                    x.Id,
                    x.BudgetYear,
                    x.BudgetType,
                    x.BudgetMainCode,
                    x.BudgetMainCodeDesc,
                    x.BudgetSubCode,
                    x.BudgetSubCodeDesc,
                    x.BranchCode,
                    x.SiteCode,
                    x.Description1,
                    x.Description2,
                    x.Description3,
                }).Select(s => new BudgetWithMonthsDto
                {
                    Id = s.Key.Id,
                    BudgetYear      = s.Key.BudgetYear,
                    BudgetType = s.Key.BudgetType,
                    BudgetMainCode  = s.Key.BudgetMainCode,
                    BudgetMainCodeDesc  = s.Key.BudgetMainCodeDesc,
                    BudgetSubCode       = s.Key.BudgetSubCode,
                    BudgetSubCodeDesc   = s.Key.BudgetSubCodeDesc,
                    BranchCode = s.Key.BranchCode,
                    SiteCode = s.Key.SiteCode,
                    Description1 = s.Key.Description1,
                    Description2 = s.Key.Description2,
                    Description3 = s.Key.Description3,

                    Ocak = s.Max(m => m.Ocak),
                    Subat = s.Max(m => m.Subat),
                    Mart = s.Max(m => m.Mart),
                    Nisan = s.Max(m => m.Nisan),
                    Mayis = s.Max(m => m.Mayis),
                    Haziran = s.Max(m => m.Haziran),
                    Temmuz = s.Max(m => m.Temmuz),
                    Agustos = s.Max(m => m.Agustos),
                    Eylul = s.Max(m => m.Eylul),
                    Ekim = s.Max(m => m.Ekim),
                    Kasim = s.Max(m => m.Kasim),
                    Aralik = s.Max(m => m.Aralik),

                    OcakId = s.Max(m => m.OcakId),
                    SubatId = s.Max(m => m.SubatId),
                    MartId = s.Max(m => m.MartId),
                    NisanId = s.Max(m => m.NisanId),
                    MayisId = s.Max(m => m.MayisId),
                    HaziranId = s.Max(m => m.HaziranId),
                    TemmuzId = s.Max(m => m.TemmuzId),
                    AgustosId = s.Max(m => m.AgustosId),
                    EylulId = s.Max(m => m.EylulId),
                    EkimId = s.Max(m => m.EkimId),
                    KasimId = s.Max(m => m.KasimId),
                    AralikId = s.Max(m => m.AralikId)

                }).ToListAsync()) 
                : (await context.Set<BudgetDetail>().Where(filter).Select(x => new BudgetWithMonthsDto
                {
                    Id = x.Budget.Id,
                    BudgetYear = x.Budget.BudgetYear,
                    BudgetType = x.Budget.BudgetType,
                    BudgetMainCode = x.Budget.BudgetMainCode,
                    BudgetMainCodeDesc = "",
                    BudgetSubCode = x.Budget.BudgetSubCode,
                    BudgetSubCodeDesc = "",
                    BranchCode = x.Budget.BranchCode,
                    SiteCode = x.Budget.SiteCode,
                    Description1 = x.Budget.Description1,
                    Description2 = x.Budget.Description2,
                    Description3 = x.Budget.Description3,
                    Ocak = x.BudgetMonth == 1 ? x.Amount : 0,
                    Subat = x.BudgetMonth == 2 ? x.Amount : 0,
                    Mart = x.BudgetMonth == 3 ? x.Amount : 0,
                    Nisan = x.BudgetMonth == 4 ? x.Amount : 0,
                    Mayis = x.BudgetMonth == 5 ? x.Amount : 0,
                    Haziran = x.BudgetMonth == 6 ? x.Amount : 0,
                    Temmuz = x.BudgetMonth == 7 ? x.Amount : 0,
                    Agustos = x.BudgetMonth == 8 ? x.Amount : 0,
                    Eylul = x.BudgetMonth == 9 ? x.Amount : 0,
                    Ekim = x.BudgetMonth == 10 ? x.Amount : 0,
                    Kasim = x.BudgetMonth == 11 ? x.Amount : 0,
                    Aralik = x.BudgetMonth == 12 ? x.Amount : 0,

                    OcakId = x.BudgetMonth == 1 ? x.Id : 0,
                    SubatId = x.BudgetMonth == 2 ? x.Id : 0,
                    MartId = x.BudgetMonth == 3 ? x.Id : 0,
                    NisanId = x.BudgetMonth == 4 ? x.Id : 0,
                    MayisId = x.BudgetMonth == 5 ? x.Id : 0,
                    HaziranId = x.BudgetMonth == 6 ? x.Id : 0,
                    TemmuzId = x.BudgetMonth == 7 ? x.Id : 0,
                    AgustosId = x.BudgetMonth == 8 ? x.Id : 0,
                    EylulId = x.BudgetMonth == 9 ? x.Id : 0,
                    EkimId = x.BudgetMonth == 10 ? x.Id : 0,
                    KasimId = x.BudgetMonth == 11 ? x.Id : 0,
                    AralikId = x.BudgetMonth == 12 ? x.Id : 0

                }).GroupBy(x => new
                {
                    x.Id,
                    x.BudgetYear,
                    x.BudgetType,
                    x.BudgetMainCode,
                    x.BudgetMainCodeDesc,
                    x.BudgetSubCode,
                    x.BudgetSubCodeDesc,
                    x.BranchCode,
                    x.SiteCode,
                    x.Description1,
                    x.Description2,
                    x.Description3,
                }).Select(s => new BudgetWithMonthsDto
                {
                    Id = s.Key.Id,
                    BudgetYear = s.Key.BudgetYear,
                    BudgetType = s.Key.BudgetType,
                    BudgetMainCode = s.Key.BudgetMainCode,
                    BudgetMainCodeDesc = s.Key.BudgetMainCodeDesc,
                    BudgetSubCode = s.Key.BudgetSubCode,
                    BudgetSubCodeDesc = s.Key.BudgetSubCodeDesc,
                    BranchCode = s.Key.BranchCode,
                    SiteCode = s.Key.SiteCode,
                    Description1 = s.Key.Description1,
                    Description2 = s.Key.Description2,
                    Description3 = s.Key.Description3,

                    Ocak = s.Max(m => m.Ocak),
                    Subat = s.Max(m => m.Subat),
                    Mart = s.Max(m => m.Mart),
                    Nisan = s.Max(m => m.Nisan),
                    Mayis = s.Max(m => m.Mayis),
                    Haziran = s.Max(m => m.Haziran),
                    Temmuz = s.Max(m => m.Temmuz),
                    Agustos = s.Max(m => m.Agustos),
                    Eylul = s.Max(m => m.Eylul),
                    Ekim = s.Max(m => m.Ekim),
                    Kasim = s.Max(m => m.Kasim),
                    Aralik = s.Max(m => m.Aralik),

                    OcakId = s.Max(m => m.OcakId),
                    SubatId = s.Max(m => m.SubatId),
                    MartId = s.Max(m => m.MartId),
                    NisanId = s.Max(m => m.NisanId),
                    MayisId = s.Max(m => m.MayisId),
                    HaziranId = s.Max(m => m.HaziranId),
                    TemmuzId = s.Max(m => m.TemmuzId),
                    AgustosId = s.Max(m => m.AgustosId),
                    EylulId = s.Max(m => m.EylulId),
                    EkimId = s.Max(m => m.EkimId),
                    KasimId = s.Max(m => m.KasimId),
                    AralikId = s.Max(m => m.AralikId)

                }).ToListAsync());
                return res;
            }
        }
    }
}
