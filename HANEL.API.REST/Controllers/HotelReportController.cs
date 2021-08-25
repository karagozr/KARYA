using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.MODEL.FilterDto.Hotel;
using KARYA.CORE.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.Controllers
{
    public class HotelReportController : BaseController
    {
        IHotelReportManager _hotelReportManager;
        public HotelReportController(IHotelReportManager hotelReportManager)
        {
            _hotelReportManager = hotelReportManager;
        }
        
        [HttpGet("GetRoomSaleReport")]
        public async Task<IActionResult> GetRoomSaleReport()
        {
            var result = await _hotelReportManager.RoomSaleRawList();
            if (result.Success) return Ok(result.Data);
            else return BadRequest();
        }

        [HttpGet("GetRoomSaleSumReport")]
        public async Task<IActionResult> GetRoomSaleSumReport()
        {
            var result = await _hotelReportManager.RoomSaleSumList();
            if (result.Success) return Ok(result.Data);
            else return BadRequest();
        }

        [HttpGet("GetRoomSaleWithAgentSumReport")]
        public async Task<IActionResult> GetRoomSaleWithAgentSumReport([FromQuery]DateRangeModel dateRangeModel=null)
        {
            var result = await _hotelReportManager.RoomSaleSumWithAgentList(dateRangeModel);
            return result.Success ? Ok(JsonConvert.SerializeObject(result.Data, _SERILAZERSETTING)) : BadRequest();
        }
    }
}
