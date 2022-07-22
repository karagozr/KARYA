
using Dapper;
using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.BUSINESS.Concrete.Hotel;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.DATAACCESS.Concrete.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANEL.API.REST.DASHBOARD.Data
{
    public class HotelERPDatasources : DapperBaseDal
    {
        IHotelReportManager hotelReportManager;
        public HotelERPDatasources()
        {
            hotelReportManager = new HotelReportManager();
        }

        public async Task<IEnumerable<dynamic>> GetHotelAccomodation()
        {
            var res = await hotelReportManager.RoomSaleAgentCountryMarket();

            if (res.Success)
                return res.Data.ToList();
            else
                return null;
        }

    }
}
