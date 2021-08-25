using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.AgentApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KARYA.BUSINESS.Abstract.AgentServiceApp
{
    public interface IAgentUserManager
    {
        Task<IResult> AddAgentUser(AgentUser agentUser);
        Task<IResult> AddAgentDirectories(IEnumerable<AgentBackUpDirectory> agentBackUpDirectories);
        Task<IResult> CheckService(string agentGuid);
        Task<IResult> CheckLisanceKey(string lisanceKey);
        Task<IResult> CheckUsername(string username);
        Task<IResult> CheckEmail(string email);
    }
}
