using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.MODEL.Filter.Hotel;
using HANEL.MODEL.Module;
using KARYA.BUSINESS.Abstract.Karya;
using KARYA.COMMON.Attributes;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers.Hotel.v1
{
    [Route("api/v1/Hotel/report")]
    public class HotelReportController : BaseController
    {
        IHotelReportManager _hotelReportManager;
        IAppParameterManager _appParameterManager;
        public HotelReportController(IHotelReportManager hotelReportManager, IAppParameterManager appParameterManager)
        {
            _hotelReportManager = hotelReportManager;
            _appParameterManager = appParameterManager;
        }
        
        [HttpGet("GetRoomSaleReport")]
        
        public async Task<IActionResult> GetRoomSaleReport()
        {
            var result = await _hotelReportManager.RoomSaleRawList();
            if (result.Success) return Ok(result.Data);
            else return BadRequest();
        }

        [HttpGet("GetRoomSaleSumReport")]
        [KaryaAuthorize(Role = HanelRole.HotelRoomIprLineDash)]
        public async Task<IActionResult> GetRoomSaleSumReport()
        {
            var result = await _hotelReportManager.RoomSaleSumList();
            if (result.Success) return Ok(result.Data);
            else return BadRequest();
        }

        [HttpGet("GetRoomSaleWithAgentSumReport")]
        [KaryaAuthorize(Role = HanelRole.HotelRoomIprCaTreeDash)]
        public async Task<IActionResult> GetRoomSaleWithAgentSumReport([FromQuery]DateRangeModel dateRangeModel=null)
        {
            var result = await _hotelReportManager.RoomSaleSumWithAgentList(dateRangeModel);
            return result.Success ? Ok(JsonConvert.SerializeObject(result.Data, _SERILAZERSETTING)) : BadRequest();
        }

        [HttpGet("GetRoomSaleACMReport")]
        [KaryaAuthorize(Role = HanelRole.HotelHomeCamDash)]
        public async Task<IActionResult> GetRoomSaleACMReport([FromQuery] DateRangeModel dateRangeModel = null)
        {
            var result = await _hotelReportManager.RoomSaleAgentCountryMarket(dateRangeModel);
            return result.Success ? Ok(JsonConvert.SerializeObject(result.Data, _SERILAZERSETTING)) : BadRequest();
        }

        [HttpGet("GetRoomSaleAgentDaily")]
        [KaryaAuthorize(Role = HanelRole.HotelRoomSaleForAgentRpt)]
        public async Task<IActionResult> GetRoomSaleAgentDaily([FromQuery] DateRangeModel dateRangeModel = null)
        {
            var result = await _hotelReportManager.RoomSaleByAgentDaily(dateRangeModel);
            return result.Success ? Ok(JsonConvert.SerializeObject(result.Data, _SERILAZERSETTING)) : BadRequest();
        }

        [HttpGet("GetRoomIncomeAgentDaily")]
        [KaryaAuthorize(Role = HanelRole.HotelRoomIncomeForAgentRpt)]
        public async Task<IActionResult> GetRoomIncomeAgentDaily([FromQuery] DateRangeModel dateRangeModel = null)
        {
            var result = await _hotelReportManager.RoomIncomeByAgentDaily(dateRangeModel);
            return result.Success ? Ok(JsonConvert.SerializeObject(result.Data, _SERILAZERSETTING)) : BadRequest();
        }

        [HttpGet("GetHotelCapacity")]
        public async Task<IActionResult> GetHotelCapacity(string hotelName)
        {
            if(string.IsNullOrEmpty(hotelName)) return NoContent();

            var result = await _appParameterManager.GetSingleParamValue(hotelName);

            if (result.Success && !string.IsNullOrEmpty(result.Data))
                return Ok(JsonConvert.SerializeObject(new { HotelName = hotelName, Capacity = result.Data }, _SERILAZERSETTING)) ;
            else if (result.Success && string.IsNullOrEmpty(result.Data))
                return NoContent();
            else 
                return BadRequest();
        }
    }
}
