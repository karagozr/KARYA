using Dapper;
using HANEL.BUSINESS.Abstract.Finance.PL;
using HANEL.BUSINESS.Abstract.PlReport;
using HANEL.MODEL.Common.PlReport;
using HANEL.MODEL.Dtos.Finance;
using HANEL.MODEL.Dtos.Finance.PL;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Finance.PL
{
    public class PLReportManager : DapperBaseDal, IPLReportManager
    {
       

        public async Task<IDataResult<IEnumerable<ProjectsForPlReportFilter>>> GetProjectsForReportFilter()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"SELECT ProjectCode, ProjectName FROM [Vw_ProjectsOfCompany]";

                    var resultData = await connection.QueryAsync<ProjectsForPlReportFilter>(queryString);

                    return new SuccessDataResult<IEnumerable<ProjectsForPlReportFilter>>(resultData.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ProjectsForPlReportFilter>>(null,ex.Message);
            }

        }


        public async Task<IDataResult<IEnumerable<PlReportWithDetail>>> GetReportWithDetails(PlReportFilterModel plReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    DataTable projectCodes = new DataTable();
                    projectCodes.Columns.Add("TextValue");

                    DataRow workRow;


                    foreach (var item in plReportFilterModel.ProjectCode)
                    {
                        workRow = projectCodes.NewRow();
                        workRow[0] = item;
                        projectCodes.Rows.Add(workRow);
                    }

                    var data = await connection.QueryAsync<PlReportWithDetail>("Pr_PlPeportValuesWithDetails", new { plReportFilterModel.Moment, plReportFilterModel.PlReportType, plReportFilterModel.Month,plReportFilterModel.Year, plReportFilterModel.Currency, projectCodes }, commandType: CommandType.StoredProcedure);

                    return new SuccessDataResult<IEnumerable<PlReportWithDetail>>(data.ToList());
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<IEnumerable<PlReportWithDetail>>();
            }

        }

     
        public async Task<IDataResult<IEnumerable<PlReportDetailForBudgetOrCost>>> GetReportValuesDetails(PlReportFilterModel plReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    DataTable projectCodes = new DataTable();
                    projectCodes.Columns.Add("TextValue");

                    DataRow workRow;


                    foreach (var item in plReportFilterModel.ProjectCode)
                    {
                        workRow = projectCodes.NewRow();
                        workRow[0] = item;
                        projectCodes.Rows.Add(workRow);
                    }

                    var data = await connection.QueryAsync<PlReportDetailForBudgetOrCost>("Pr_PlPeportValuesDetails", 
                        new { plReportFilterModel.Moment,plReportFilterModel.SubCode ,plReportFilterModel.BudgetOrCostType, 
                              plReportFilterModel.Month,
                              plReportFilterModel.Year,
                              plReportFilterModel.Currency,projectCodes,plReportFilterModel.BranchCode }, 
                        commandType: CommandType.StoredProcedure);
                    int i = 1;

                    foreach (var item in data)
                    {
                        item.Id = i++;
                    }

                    return new SuccessDataResult<IEnumerable<PlReportDetailForBudgetOrCost>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<PlReportDetailForBudgetOrCost>>(ex.Message);
            }

        }

        public async Task<IDataResult<IEnumerable<ActualRawData>>> GetRawData(PlReportFilterModel plReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    //DataTable projectCodes = new DataTable();
                    //projectCodes.Columns.Add("TextValue");

                    //DataRow workRow;


                    //foreach (var item in plReportFilterModel.ProjectCode)
                    //{
                    //    workRow = projectCodes.NewRow();
                    //    workRow[0] = item;
                    //    projectCodes.Rows.Add(workRow);
                    //}

                    var data = await connection.QueryAsync<ActualRawData>("Pr_ActualRawData", commandType: CommandType.StoredProcedure);
                    

                    //foreach (var item in data)
                    //{
                    //    item.Id = i++;
                    //}

                    return new SuccessDataResult<IEnumerable<ActualRawData>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<ActualRawData>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<PlReportDto>>> GetPL(PlReportFilterModel plReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    DataTable projectCodes = new DataTable();
                    projectCodes.Columns.Add("TextValue");

                    DataRow workRow;


                    foreach (var item in plReportFilterModel.ProjectCode)
                    {
                        workRow = projectCodes.NewRow();
                        workRow[0] = item;
                        projectCodes.Rows.Add(workRow);
                    }
                    
                    var data = await connection.QueryAsync<PlReportDto>("HNL_PR_PL_REPORT", new { plReportFilterModel.Currency, plReportFilterModel.Year, plReportFilterModel.Month, projectCodes }, commandType: CommandType.StoredProcedure);

                    return new SuccessDataResult<IEnumerable<PlReportDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<PlReportDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<PlReportDetailDto>>> GetPLDetail(PlReportFilterModel plReportFilterModel)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    DataTable projectCodes = new DataTable();
                    projectCodes.Columns.Add("TextValue");

                    DataRow workRow;

                    if(plReportFilterModel.ProjectCode!=null)
                    foreach (var item in plReportFilterModel.ProjectCode)
                    {
                        workRow = projectCodes.NewRow();
                        workRow[0] = item;
                        projectCodes.Rows.Add(workRow);
                    }

                    var data = await connection.QueryAsync<PlReportDetailDto>("HNL_PR_PL_REPORT_DETAIL", new { 
                        plReportFilterModel.Currency, 
                        plReportFilterModel.Year, 
                        plReportFilterModel.Month, 
                        plReportFilterModel.IntegrationCode,
                        plReportFilterModel.ActualOrBudget,
                        plReportFilterModel.BranchCode,
                        plReportFilterModel.Moment,
                        plReportFilterModel.ReportCodeId,
                        projectCodes }, commandType: CommandType.StoredProcedure);


                    return new SuccessDataResult<IEnumerable<PlReportDetailDto>>(data);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<PlReportDetailDto>>(ex.Message);
            }
        }
    }
}
