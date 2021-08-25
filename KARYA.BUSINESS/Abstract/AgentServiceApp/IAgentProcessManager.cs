using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.AgentApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.AgentServiceApp
{
    public interface IAgentProcessManager
    {
        Task<IResult> AddLog(ProcessLog processLog);
        Task<IResult> AddLogs(IEnumerable<ProcessLog> processLogs);
        Task<IResult> DeleteLogs(string agentGuid);
        Task<IResult> UpdateLogForKilled(string agentGuid, string processName);
        Task<IDataResult<IEnumerable<int>>> GetRiskedLogs(string agentGuid);

        
    }
}
