using HANEL.BUSINESS.Abstract.Finance.Budgets;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Filter.Finance;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance.Budgets
{
    public class BudgetExchangeRateManager : IBudgetExchangeRateManager
    {
        IBudgetExchangeRateDal _budgetExchangeRateDal;

        public BudgetExchangeRateManager(IBudgetExchangeRateDal budgetExchangeRateDal)
        {
            _budgetExchangeRateDal = budgetExchangeRateDal;
        }
        public async Task<IResult> Edit(IEnumerable<BudgetExchangeRateDto> budgetExchanges)
        {
            try
            {
                await _budgetExchangeRateDal.AddUpdate(budgetExchanges.Select(x=>new MODEL.Entities.Finance.BudgetExchangeRate {
                    Id=x.Id,
                    Enable=x.Enable,
                    ExchangeRate=x.ExchangeRate,
                    CurrencyCode=x.CurrencyCode,
                    MainCurrencyCode="TL",
                    PeriodDate=x.PeriodDate
                }));

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<BudgetExchangeRateDto>>> List(BudgetExchangeRateFilterModel filter)
        {
            try
            {
                var data = await _budgetExchangeRateDal.List(x => x.PeriodDate.Year == filter.Year);
                return new SuccessDataResult<IEnumerable<BudgetExchangeRateDto>>(data.Select(x=>new BudgetExchangeRateDto { 
                    Id=x.Id,
                    CurrencyCode=x.CurrencyCode,
                    ExchangeRate=x.ExchangeRate,
                    PeriodDate=x.PeriodDate,
                    Enable=x.Enable
                }));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetExchangeRateDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<BudgetExchangeRateMonthlyDto>>> ListMonthly(BudgetExchangeRateFilterModel filter)
        {
            try
            {
                var data = await _budgetExchangeRateDal.List(x => x.PeriodDate.Year == filter.Year);


                var returnData = data.GroupBy(b => b.CurrencyCode).Select(s => new BudgetExchangeRateMonthlyDto { 
                    CurrencyCode    = s.Key,
                    RateJanuary     = s.Max(x=>x.PeriodDate.Month == 1  ? x.ExchangeRate : 0  ),
                    RateFebruary    = s.Max(x=>x.PeriodDate.Month == 2  ? x.ExchangeRate : 0  ),
                    RateMarch       = s.Max(x=>x.PeriodDate.Month == 3  ? x.ExchangeRate : 0  ),
                    RateApril       = s.Max(x=>x.PeriodDate.Month == 4  ? x.ExchangeRate : 0  ),
                    RateMay         = s.Max(x=>x.PeriodDate.Month == 5  ? x.ExchangeRate : 0  ),
                    RateJune        = s.Max(x=>x.PeriodDate.Month == 6  ? x.ExchangeRate : 0  ),
                    RateJuly        = s.Max(x=>x.PeriodDate.Month == 7  ? x.ExchangeRate : 0  ),
                    RateAugust      = s.Max(x=>x.PeriodDate.Month == 8  ? x.ExchangeRate : 0  ),
                    RateSeptember   = s.Max(x=>x.PeriodDate.Month == 9  ? x.ExchangeRate : 0  ),
                    RateOctober     = s.Max(x=>x.PeriodDate.Month == 10 ? x.ExchangeRate : 0  ),
                    RateNovember    = s.Max(x=>x.PeriodDate.Month == 11 ? x.ExchangeRate : 0  ),
                    RateDecember    = s.Max(x=>x.PeriodDate.Month == 12 ? x.ExchangeRate : 0  )
                });

                return new SuccessDataResult<IEnumerable<BudgetExchangeRateMonthlyDto>>(returnData);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetExchangeRateMonthlyDto>>(ex.Message);
            }
        }
    }
}
