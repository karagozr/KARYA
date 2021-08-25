using HANEL.BUSINESS.Abstract.Finance;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance;
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
    public class BudgetExchangeRateManager : BaseManager<BudgetExchangeRate>, IBudgetExchangeRateManager
    {
        IBudgetExchangeRateDal _budgetExchangeRateDal;

        public BudgetExchangeRateManager(IBudgetExchangeRateDal budgetExchangeRateDal) : base(budgetExchangeRateDal)
        {
            _budgetExchangeRateDal = budgetExchangeRateDal;
        }

        public async Task<IDataResult<IEnumerable<BudgetExchangeRateWithMonthNameDto>>> GetExchangeForecastForYear(short year)
        {
            try
            {
                // {month: 'ocak',    USD: 8 ,EUR:9}
                var entities = await _budgetExchangeRateDal.List(x=>x.PeriodDate.Year==year);
                var resultList = new List<BudgetExchangeRateWithMonthNameDto>();
                for (int i = 0; i < 12; i++)
                {
                    var usd = entities.Where(x => x.PeriodDate.Month == i+1 && x.MainCurrencyCode == "TL" && x.CurrencyCode == "USD").FirstOrDefault().ExchangeRate;
                    var eur = entities.Where(x => x.PeriodDate.Month == i+1 && x.MainCurrencyCode == "TL" && x.CurrencyCode == "EUR").FirstOrDefault().ExchangeRate;
                    var month = "";

                    if (i == 0)  month = "ocak";
                    if (i == 1)  month = "subat";
                    if (i == 2)  month = "mart";
                    if (i == 3)  month = "nisan";
                    if (i == 4)  month = "mayis";
                    if (i == 5)  month = "haziran";
                    if (i == 6)  month = "temmuz";
                    if (i == 7)  month = "agustos";
                    if (i == 8)  month = "eylul";
                    if (i == 9)  month = "ekim";
                    if (i == 10) month = "kasim";
                    if (i == 11) month = "aralik";




                    resultList.Add(new BudgetExchangeRateWithMonthNameDto
                    {
                        Month = month,
                        USD = usd,
                        EUR = eur
                    });
                }
                
               
                return new SuccessDataResult<IEnumerable<BudgetExchangeRateWithMonthNameDto>>(resultList);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<BudgetExchangeRateWithMonthNameDto>>(ex.Message);
            }
        }

    }

}
