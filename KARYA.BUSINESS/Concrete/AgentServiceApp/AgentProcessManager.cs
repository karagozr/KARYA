using Dapper;
using KARYA.BUSINESS.Abstract.AgentServiceApp;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using KARYA.MODEL.Entities.AgentApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Concrete.AgentServiceApp
{
    public class AgentProcessManager : DapperAgentBaseDal, IAgentProcessManager
    {
        public async Task<IResult> DeleteLogs(string agentGuid)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"DELETE FROM [dbo].[ProcessLog] where AgentGuid='{agentGuid}'";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Error : " + ex.Message);
            }
        }

        public async Task<IResult> AddLog(ProcessLog processLog)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"INSERT INTO [dbo].[ProcessLog]([AgentGuid],[Pid],[ProcessType],[Name],[Path],[Description],[ProductName],[Size],[Language])" +
                        $"VALUES ('{processLog.AgentGuid}',{processLog.Pid},'{processLog.ProcessType}','{processLog.Name}','{processLog.Path}','{processLog.Description}'" +
                        $",'{processLog.ProductName}',{processLog.Size},'{processLog.Language}')";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Error : " + ex.Message);
            }
        }

        public async Task<IResult> AddLogs(IEnumerable<ProcessLog> processLogs)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"INSERT INTO [dbo].[ProcessLog]([AgentGuid],[Pid],[ProcessType],[Name],[Path],[Description],[ProductName],[Size],[Language]) VALUES";

                    foreach (var item in processLogs)
                    {
                        queryString += $"('{item.AgentGuid}',{item.Pid},'{item.ProcessType}','{item.Name}','{item.Path}','{item.Description}'" +
                                       $",'{item.ProductName}',{item.Size},'{item.Language}'),";
                    }
                    queryString = queryString.Remove(queryString.Length - 1);

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Error : " + ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<int>>> GetRiskedLogs(string agentGuid)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select Pid from RiskedProcess as R left join ProcessLog as P on R.[Name]=P.[Name] where P.AgentGuid='{agentGuid}' and P.IsKilled=0";

                    var resultData = await connection.QueryAsync<int>(queryString);

                    return new SuccessDataResult<IEnumerable<int>>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<int>>(null, "Error : " + ex.Message);
            }
        }

        public async Task<IResult> UpdateLogForKilled(string agentGuid, string processName)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"UPDATE [dbo].[ProcessLog] SET [IsKilled] = 1 WHERE AgentGuid='{agentGuid}' and [Name]='{processName}'";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Error : " + ex.Message);
            }
        }

    }
}
