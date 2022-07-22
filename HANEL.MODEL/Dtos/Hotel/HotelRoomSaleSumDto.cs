using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Hotel
{
    public class HotelRoomSaleSumDto
    {
        public DateTime ProcessDate { get; set; }
        public DateTime SaleDate { get; set; }
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgencyName { get; set; }
        public string CountryName { get; set; }
        public string MarketName { get; set; }
        public int Pax { get; set; }
        public int RoomSum { get; set; }
        public double Occupancy { get; set; }
        public double IncomeSumEUR { get; set; }
    }
}

