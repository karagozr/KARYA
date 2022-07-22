using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.BUSINESS.Abstract.General;
using HANEL.MODEL.Entities.Muhasebe.Erp;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Accounting.v1
{
    [Route("api/v1/Account/Netsis")]
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

        [HttpPost("CariEdit")]
        public async Task<IActionResult> CariEdit(ErpCari erpCari)
        {
            var result = await _cariManager.AddUpdateCari(erpCari);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);

        }

        [HttpGet("StokList")]
        public async Task<IActionResult> StokList(string branchCode=null)
        {
            var result = await _stokManager.List(branchCode);
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

        [HttpGet("StockCode1List")]
        public async Task<IActionResult> StockCode1List()
        {
            var result = await _managmentManager.ListStokCode1List();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("StockGrup1List")]
        public async Task<IActionResult> StockGrup1List()
        {
            var result = await _managmentManager.ListStokGrupCode1List();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("StockAccDetailKodList")]
        public async Task<IActionResult> StockAccDetailKodList()
        {
            var result = await _managmentManager.ListMuhDetailCodes();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

    }
}
