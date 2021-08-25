using Dapper;
using HANEL.BUSINESS.Abstract.PlReport;
using HANEL.MODEL.Common.PlReport;
using HANEL.MODEL.Dtos.Finance;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.PlReports
{
    public class PlReportManager :DapperBaseDal, IPlReportManager
    {
        public async Task<IDataResult<PlReport>> GetReport(PlReportFilterModel plReportFilterModel)
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

                    var data =  await connection.QueryAsync<PlReport>("Pr_PlPeportValues", new { plReportFilterModel.Moment, plReportFilterModel.PlReportType, plReportFilterModel.Month, plReportFilterModel.Year, plReportFilterModel.Currency, projectCodes }, commandType: CommandType.StoredProcedure);

                    return new SuccessDataResult<PlReport>(data.FirstOrDefault());
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<PlReport>();
            }
            
        }

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
    }
}
