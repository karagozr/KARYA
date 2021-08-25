using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HANEL.DATAACCESS.Concrete.EntityFramework.Finance
{
    public class BudgetSubDetailDal : EfRepository<BudgetSubDetail, HanelContext>, IBudgetSubDetailDal
    {
        public async Task<IEnumerable<BudgetSubDetailDto>> ListWithSubCode(Expression<Func<BudgetSubDetail, bool>> filter)
        {
            using (var context = new HanelContext())
            {
                var res = filter==null? (await context.Set<BudgetSubDetail>().Select(x => new BudgetSubDetailDto
                {
                    Id = x.Id,
                    BudgetSubCode = x.Budget.BudgetSubCode,
                    Description = x.Description,
                    BudgetId = x.BudgetId,
                    Ocak = x.Ocak,
                    Subat = x.Subat,
                    Mart = x.Mart,
                    Nisan = x.Nisan,
                    Mayis = x.Mayis,
                    Haziran = x.Haziran,
                    Temmuz = x.Temmuz,
                    Agustos = x.Agustos,
                    Eylul = x.Eylul,
                    Ekim = x.Ekim,
                    Kasim = x.Kasim,
                    Aralik = x.Aralik
                }).ToListAsync()):
                (await context.Set<BudgetSubDetail>().Where(filter).Select(x => new BudgetSubDetailDto
                {
                    Id = x.Id,
                    BudgetSubCode = x.Budget.BudgetSubCode,
                    Description = x.Description,
                    BudgetId = x.BudgetId,
                    Ocak = x.Ocak,
                    Subat = x.Subat,
                    Mart = x.Mart,
                    Nisan = x.Nisan,
                    Mayis = x.Mayis,
                    Haziran = x.Haziran,
                    Temmuz = x.Temmuz,
                    Agustos = x.Agustos,
                    Eylul = x.Eylul,
                    Ekim = x.Ekim,
                    Kasim = x.Kasim,
                    Aralik = x.Aralik
                }).ToListAsync());

                return res;
            }
        }
    }
}
