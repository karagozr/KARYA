using HANEL.MODEL.Dtos.Hotel;
using HANEL.MODEL.Filter.Hotel;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Abstract.Hotel
{
    public interface IHotelReportManager
    {
        Task<IDataResult<IEnumerable<HotelRoomSaleRawDto>>> RoomSaleRawList();
        Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleSumList();
        Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleSumWithAgentList(DateRangeModel dateRangeModel = null);
        Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleAgentCountryMarket(DateRangeModel dateRangeModel = null);
        Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomIncomeByAgentDaily(DateRangeModel dateRangeModel = null);
        Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleByAgentDaily(DateRangeModel dateRangeModel = null);
    }
}
