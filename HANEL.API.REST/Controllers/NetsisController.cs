using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Abstract.General;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers
{
    public class NetsisController : BaseController
    {
        private ICariManager _cariManager;
        private IStokManager _stokManager;
        private IMuhasebeManager _muhasebeManager;
        private IManagmentManager _managmentManager;

        public NetsisController(ICariManager cariManager, IStokManager stokManager, 
            IMuhasebeManager muhasebeManager, IManagmentManager managmentManager)
        {
            _cariManager = cariManager;
            _stokManager = stokManager;
            _muhasebeManager = muhasebeManager;
            _managmentManager = managmentManager;
        }

        [HttpGet("CariList")]
        public async Task<IActionResult> CariList()
        {
            var result = await _cariManager.List();
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("StokList")]
        public async Task<IActionResult> StokList()
        {
            var result = await _stokManager.List();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("HesapKoduList")]
        public async Task<IActionResult> HesapKoduList()
        {
            var result = await _muhasebeManager.ListMuhHesap();
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);


        }

        [HttpGet("MuhasebeReferansList")]
        public async Task<IActionResult> MuhasebeReferansList()
        {
            var result = await _muhasebeManager.ListMuhReferans();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("SubeList")]
        public async Task<IActionResult> SubeList(string vkn=null)
        {
            var result = await _managmentManager.ListBranch(vkn);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("SirketList")]
        public async Task<IActionResult> SirketList(string vkn = null)
        {
            var result = await _managmentManager.ListCompany(vkn);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("ProjeList")]
        public async Task<IActionResult> ProjeList()
        {
            var result = await _managmentManager.ListProjects();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
    }
}
