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
    public class AgentUserManager : DapperAgentBaseDal, IAgentUserManager
    {
        public async Task<IResult> AddAgentDirectories(IEnumerable<AgentBackUpDirectory> agentBackUpDirectories)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"INSERT INTO [dbo].[AgentBackUpDirectory]([AgentGuid],[MachineName],[SyncPath]) VALUES";

                    foreach (var item in agentBackUpDirectories)
                    {
                        queryString+=$"('{item.AgentGuid}','{item.MachineName}','{item.SyncPath}'),";
                    }

                    queryString=queryString.Remove(queryString.Length - 1);
                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Error : " + ex.Message);
            }
        }

        public async Task<IResult> AddAgentUser(AgentUser agentUser)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"INSERT INTO [dbo].[AgentUser]([AgentGuid],[UserName],[Email],[Password],[LisanceKey],[MachineName])" +
                        $"VALUES ('{agentUser.AgentGuid}','{agentUser.Username}','{agentUser.Email}','{agentUser.Password}','{agentUser.LisanceKey}','{agentUser.MachineName}')";

                    var resultData = await connection.QueryAsync(queryString);

                    return new SuccessResult();
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult("Error : " + ex.Message);
            }
        }

        public async Task<IResult> CheckEmail(string email)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select *  from [dbo].[AgentUser] where Email ='{email}'";

                    var resultData = await connection.QueryFirstAsync<AgentUser>(queryString);

                    return new SuccessDataResult<AgentUser>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AgentUser>(null, "Error : " + ex.Message);
            }
        }

        public async Task<IResult> CheckLisanceKey(string lisanceKey)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select *  from [dbo].[AgentUser] where LisanceKey ='{lisanceKey}'";

                    var resultData = await connection.QueryFirstAsync<AgentUser>(queryString);

                    return new SuccessDataResult<AgentUser>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AgentUser>(null, "Error : " + ex.Message);
            }
        }

        public async Task<IResult> CheckService(string agentGuid)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select *  from [dbo].[AgentUser] where AgentGuid ='{agentGuid}'";

                    var resultData = await connection.QueryFirstAsync<AgentUser>(queryString);

                    return new SuccessDataResult<AgentUser>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AgentUser>(null, "Error : " + ex.Message);
            }
        }

        public async Task<IResult> CheckUsername(string username)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var queryString = $"select * from [dbo].[AgentUser] where Username ='{username}'";

                    var resultData = await connection.QueryFirstAsync<AgentUser>(queryString);

                    return new SuccessDataResult<AgentUser>(resultData);
                }

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AgentUser>(null, "Error : " + ex.Message);
            }
        }
    }
}
