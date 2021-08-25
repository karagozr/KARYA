using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance
{
    public class BudgetDetailManager : BaseManager<BudgetDetail>, IBudgetDetailManager
    {
        IBudgetDetailDal _budgetDetailDal;
        IActualCostManager _actualCostManager;

        public BudgetDetailManager(IBudgetDetailDal budgetDetailDal, IActualCostManager actualCostManager) : base(budgetDetailDal)
        {
            _budgetDetailDal = budgetDetailDal;
            _actualCostManager = actualCostManager;
        }

        public async Task<IDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>> ListOfBudgetAndActualWithMonths(string projectCode, short budgetYear, short actualYear, string currencyCode)
        {

            try
            {
                var actualDataResult = await _actualCostManager.GetActualCostWithMonths(projectCode,actualYear,currencyCode);
                var actualData = actualDataResult.Data;

                var budgetData = await _budgetDetailDal.ListOfBudgetWithMonths(x => x.Budget.ProjectCode == projectCode && x.Budget.BudgetYear == budgetYear);

                //   return left.GroupJoin(right, leftKey, rightKey, (l, r) => new { l, r })
                //.SelectMany(
                //    o => o.r.DefaultIfEmpty(),
                //    (l, r) => new { lft = l.l, rght = r })
                //.Select(o => result.Invoke(o.lft, o.rght));

                //Employee.GetAllEmployees()
                //              .GroupJoin(
                //                    Address.GetAddress(),
                //                    emp => emp.AddressId,
                //                    add => add.ID,
                //                    (emp, add) => new { emp, add }
                //              )
                //              .SelectMany(
                //                    x => x.add.DefaultIfEmpty(),
                //                    (employee, address) => new
                //                    {
                //                        EmployeeName = employee.emp.Name,
                //                        AddressLine = address == null ? "NA" : address.AddressLine
                //                    }
                //               );

                var data = actualData.Join(budgetData,
                    x => x.ForeingId, y => y.ForeingId,
                (x, y) => new BudgetAndActualWithMonthsDto
                {
                    Id                  = y.Id,
                    BudgetYear          = y.BudgetYear,
                    BudgetMainCode      = y.BudgetMainCode,
                    BudgetMainCodeDesc  = x.BudgetMainCodeDesc,
                    BudgetSubCode       = y.BudgetSubCode,
                    BudgetSubCodeDesc   = x.BudgetSubCodeDesc,
                    BranchCode          = y.BranchCode,
                    BranchName          = x.BranchName,
                    SiteCode            = x.SiteCode,
                    ActualCurrencyCode  = x.CurrencyCode,
                    Description1        = y.Description1,
                    Description2        = y.Description2,
                    Description3        = y.Description3,
                    BudgetOcak          = y.Ocak,
                    BudgetSubat         = y.Subat,
                    BudgetMart          = y.Mart,
                    BudgetNisan         = y.Nisan,
                    BudgetMayis         = y.Mayis,
                    BudgetHaziran       = y.Haziran,
                    BudgetTemmuz        = y.Temmuz,
                    BudgetAgustos       = y.Agustos,
                    BudgetEylul         = y.Eylul,
                    BudgetEkim          = y.Ekim,
                    BudgetKasim         = y.Kasim,
                    BudgetAralik        = y.Aralik,

                    ActualOcak          = x.Ocak,
                    ActualSubat         = x.Subat,
                    ActualMart          = x.Mart,
                    ActualNisan         = x.Nisan,
                    ActualMayis         = x.Mayis,
                    ActualHaziran       = x.Haziran,
                    ActualTemmuz        = x.Temmuz,
                    ActualAgustos       = x.Agustos,
                    ActualEylul         = x.Eylul,
                    ActualEkim          = x.Ekim,
                    ActualKasim         = x.Kasim,
                    ActualAralik        = x.Aralik,

                    BudgetOcakId        = y.OcakId,
                    BudgetSubatId       = y.SubatId,
                    BudgetMartId        = y.MartId,
                    BudgetNisanId       = y.NisanId,
                    BudgetMayisId       = y.MayisId,
                    BudgetHaziranId     = y.HaziranId,
                    BudgetTemmuzId      = y.TemmuzId,
                    BudgetAgustosId     = y.AgustosId,
                    BudgetEylulId       = y.EylulId,
                    BudgetEkimId        = y.EkimId,
                    BudgetKasimId       = y.KasimId,
                    BudgetAralikId      = y.AralikId

                });

                return new SuccessDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>(data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetAndActualWithMonthsDto>>(null,ex.Message);
            }

        }

    }

}
