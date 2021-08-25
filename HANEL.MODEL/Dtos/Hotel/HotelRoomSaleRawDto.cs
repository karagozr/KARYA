using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.MODEL.Dtos.Hotel
{
    public class HotelRoomSaleRawDto
    {
        public int HaraketId { get; set; }
        public DateTime HaraketTarihi {get; set;}          
        public int RezervasyonId {get; set;}          
        public string RezervasyonNo {get; set;}          
        public DateTime SatisTarihi {get; set;}            
        public int GecelemeId {get; set;}             
        public int AcentaId {get; set;}               
        public string AcentaKodu {get; set;}             
        public string AcentaAdi {get; set;}              
        public int UlkeId {get; set;}                 
        public string UlkeKodu {get; set;}               
        public string UlkeAdi {get; set;}                
        public DateTime RezCinTarihi {get; set;}           
        public DateTime RezCoutTarihi {get; set;}          
        public int GecelemePax {get; set;}            
        public int GecelemeChi {get; set;}            
        public int GecelemeFre {get; set;}            
        public int GecelemeBeb {get; set;}            
        public int GecelemeOda {get; set;}            
        public int DovizId {get; set;}                
        public string DovizKodu {get; set;}              
        public string DovizAdi {get; set;}               
        public double RezKur {get; set;}                 
        public double EURCinKur {get; set;}              
        public int DepkodId {get; set;}               
        public string DepkodKodu {get; set;}             
        public string DepkodAdi {get; set;}              
        public string DepartmanTipi {get; set;}          
        public int KdvId {get; set;}                  
        public string KdvKodu {get; set;}                
        public double HaraketTutar {get; set;}           
        public double HaraketTutarKdv {get; set;}        
        public double HaraketTutarMatrah {get; set;}     
        public double HaraketTutarDoviz {get; set;}      
        public double HaraketTutarDovizKdv {get; set;}   
        public double HaraketTutarDovizMatrah {get; set;}
        public string Aciklama { get; set; }
    }
}
