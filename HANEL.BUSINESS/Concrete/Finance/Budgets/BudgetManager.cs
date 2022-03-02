using HANEL.BUSINESS.Abstract.Finance.Budgets;
using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Dtos.Finance.Budget;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Authorize;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance.Budgets
{
    public class BudgetManager : IBudgetManager
    {
        IBudgetDal _budgetDal;
        IBudgetDetailDal _budgetDetailDal;
        IReportCodeUserFilterDal _reportCodeUserFilterDal;

        protected internal HttpContextValues _httpContextValues;
        public BudgetManager(IBudgetDal budgetDal, IBudgetDetailDal budgetDetailDal, IReportCodeUserFilterDal reportCodeUserFilterDal) 
        {
            _budgetDal = budgetDal;
            _budgetDetailDal = budgetDetailDal;
            _httpContextValues = new HttpContextValues();
            _reportCodeUserFilterDal = reportCodeUserFilterDal;
        }
        public async Task<IResult> AddBudget(IEnumerable<BudgetAddDto> budgets)
        {
            try
            {
                var budgetMain = new List<Budget>();

                string[] listMonth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }; 

                foreach (var item in budgets)
                {
                    //var res = item.GetType().GetProperty("BudgetJanuary").GetValue(item);

                    var detail = new List<BudgetDetail>();
                    for (short i = 0; i < 12; i++)
                    {
                        detail.Add(new BudgetDetail
                        {
                            Description = item.Description,
                            Amount = Convert.ToDecimal(item.GetType().GetProperty("Budget"+ listMonth[i]).GetValue(item)),
                            BudgetMonth = (short)(i+1),
                            BudgetYear = item.Year,
                            PeriodDate = new DateTime(item.Year, i+1, 1),
                            Quantity = 0,
                            Enable = true,
                            CurrencyCode = item.CurrencyCode
                        });
                    }
                    

                    budgetMain.Add(new Budget
                    {
                        BudgetTaxMultiplier=0,
                        Enable=true,
                        BudgetMainCode=item.BudgetCode,
                        ProjectCode =item.ProjectCode,
                        BranchCode =item.BranchCode,
                        SiteCode=item.SiteCode,
                        BudgetSubCode=item.BudgetCode,
                        BudgetType=MODEL.Enums.BudgetType.IncomeBudget,
                        BudgetYear=item.Year,
                        BudgetDetails= detail,

                    });

                }

                await _budgetDal.AddComplex(budgetMain);

                return new SuccessResult("List Adding was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> EditBudget(IEnumerable<BudgetEditDto> budgets)
        {
            try
            {
                var budgetMain = new List<Budget>();

                string[] listMonth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

                foreach (var item in budgets)
                {
                    //var res = item.GetType().GetProperty("BudgetJanuary").GetValue(item);

                    var detail = new List<BudgetDetail>();
                    for (short i = 0; i < 12; i++)
                    {
                        detail.Add(new BudgetDetail
                        {
                            Id = 0,//item.GetType().GetProperty("DetailId" + listMonth[i]).GetValue(item)==null?0: Convert.ToInt32(item.GetType().GetProperty("DetailId" + listMonth[i]).GetValue(item)),
                            BudgetId = item.BudgetId,
                            Description = item.Description,
                            Amount = Convert.ToDecimal(item.GetType().GetProperty("Budget" + listMonth[i]).GetValue(item)),
                            BudgetMonth = (short)(i + 1),
                            BudgetYear = item.Year,
                            PeriodDate = new DateTime(item.Year, i + 1, 1),
                            Quantity = 0,
                            Enable = true,
                            CurrencyCode = item.CurrencyCode
                        });
                    }


                    budgetMain.Add(new Budget
                    {
                        Id = item.BudgetId==null?0: item.BudgetId,
                        BudgetTaxMultiplier = 0,
                        Enable = true,
                        BudgetMainCode = item.BudgetCode,
                        ProjectCode = item.ProjectCode,
                        BranchCode = item.BranchCode,
                        SiteCode = item.SiteCode,
                        BudgetSubCode = item.BudgetCode,
                        BudgetType = MODEL.Enums.BudgetType.IncomeBudget,
                        BudgetYear = item.Year,
                        BudgetDetails = detail,
                    });

                }

                var budgetIds = budgets.Where(w => w.BudgetId > 0).Select(s => s.BudgetId);

                if (budgetIds.Count() > 0)
                {
                    var details = await _budgetDetailDal.List(x => budgetIds.Contains(x.BudgetId));
                    await _budgetDetailDal.Delete(details);
                }
               
                if(budgetMain.Count(x => x.Id == 0) > 0)
                    await _budgetDal.AddComplex(budgetMain.Where(x=>x.Id == 0));

                if (budgetMain.Count(x => x.Id > 0) > 0)
                    await _budgetDal.UpdateComplex(budgetMain.Where(x => x.Id > 0));

                return new SuccessResult("List Updating was succesed");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> EditBudgetDetail(IEnumerable<BudgetEditDto> budgets)
        {
            try
            {

                var usr = _httpContextValues.UserId();

                var budgetMains = new List<Budget>();
                string[] listMonth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

                var anyBudget = budgets.FirstOrDefault(y => y.ProjectCode != null);

                var filterCodes = await _reportCodeUserFilterDal.List(x => x.ProjectCode == anyBudget.ProjectCode && x.UserId == usr && (x.AccessUpdate == true || x.AccessAdd == true) );

                budgets = budgets.Where(x => filterCodes.Select(x => x.IntegrationCode1).Contains(x.BudgetCode));

                var oldBudgets = await _budgetDal.List(x => x.ProjectCode == anyBudget.ProjectCode && x.BudgetYear == anyBudget.Year && budgets.Select(s=>s.BudgetCode).Contains(x.BudgetSubCode) && filterCodes.Select(x => x.IntegrationCode1).Contains(x.BudgetSubCode));

                await _budgetDal.Delete(oldBudgets);


                var budgetGroups = budgets.Where(x=>!String.IsNullOrEmpty(x.CurrencyCode) && !String.IsNullOrEmpty(x.ProjectCode) && !String.IsNullOrEmpty(x.BudgetCode) && x.Year>2000 )
                    .GroupBy(b => new { b.BudgetId, b.BudgetCode,b.ProjectCode, b.BranchCode, b.SiteCode, b.Year },b => b).Select(s => new
                {
                    Main = new Budget
                    {
                        //Id = s.Key.BudgetId,
                        BranchCode = s.Key.BranchCode,
                        BudgetSubCode = s.Key.BudgetCode,
                        BudgetYear = s.Key.Year,
                        ProjectCode=s.Key.ProjectCode,
                        SiteCode = s.Key.SiteCode,
                        BudgetTaxMultiplier = 0,
                        Enable = true,
                        BudgetMainCode = s.Key.BudgetCode,
                        BudgetType = MODEL.Enums.BudgetType.IncomeBudget
                    },
                    Detail = s.ToList()

                });

                foreach (var budget in budgetGroups)
                {
                    var main = new Budget();
                    var detail = new List<BudgetDetail>();
                    var detailCount = 1;
                    foreach (var item in budget.Detail)
                    {

                        var desc = String.IsNullOrEmpty(item.Description) ? "Kalem : "+ (detailCount++).ToString(): item.Description;
                        var _guid = Guid.NewGuid();
                        for (short i = 0; i < 12; i++)
                        {

                            detail.Add(new BudgetDetail
                            {
                                //Id = item.GetType().GetProperty("DetailId" + listMonth[i]).GetValue(item) == null ? 0 : Convert.ToInt32(item.GetType().GetProperty("DetailId" + listMonth[i]).GetValue(item)),
                                GroupGuid = _guid.ToString(),
                                BudgetId = item.BudgetId,
                                Description = desc,
                                Amount = Convert.ToDecimal(item.GetType().GetProperty("Budget" + listMonth[i]).GetValue(item)),
                                BudgetMonth = (short)(i + 1),
                                BudgetYear = item.Year,
                                PeriodDate = new DateTime(item.Year, i + 1, 1),
                                Quantity = 0,
                                Enable = true,
                                CurrencyCode = item.CurrencyCode
                            }) ; 
                        }
                    }

                    main = budget.Main;
                    main.BudgetDetails= detail;
                    budgetMains.Add(main);
                }

                if (budgetMains.Count(x => x.Id == 0)>0)
                {
                    await _budgetDal.AddComplex(budgetMains.Where(x => x.Id == 0));
                    //return new SuccessResult("List Updating was succesed");
                }
                else if(budgetMains.Count(x => x.Id > 0) > 0)
                {
                    var oldDetais = await _budgetDetailDal.List(x => budgetMains.Select(s=>s.Id).Contains(x.BudgetId));
                    var details = budgetMains.Select(x => x.BudgetDetails).SelectMany(x=>x).ToList();
                    var deleteDetais = oldDetais.Where(x => !details.Select(s=>s.Id).Contains(x.Id));

                    await _budgetDetailDal.Delete(deleteDetais);
                    await _budgetDetailDal.Add(details.Where(x=>x.Id==0));
                    await _budgetDetailDal.Update(details.Where(x => x.Id > 0));

                    //return new SuccessResult("List Updating was succesed");

                }

                return new SuccessResult("List Updating was succesed");



            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
