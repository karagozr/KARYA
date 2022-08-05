using Dapper;
using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.MODEL.Dtos.Hotel;
using HANEL.MODEL.Filter.Hotel;
using KARYA.CORE.Aspects.CacheAspects;
using KARYA.CORE.Aspects.PostSharp;
using KARYA.CORE.Concrete.Dapper;
using KARYA.CORE.CrossCuttingConcerns.Caching.Microsoft;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Hotel
{
   

    public class HotelReportManager : DapperRepository, IHotelReportManager
    {
        public HotelReportManager() : base("HOTELERPConnection")
        {
        }
        public async Task<IDataResult<IEnumerable<HotelRoomSaleRawDto>>> RoomSaleRawList()
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    var queryString =
                    $" select * from public.hnl_tf_room_sale_list   " +
                    $" where RezCoutTarihi <= NOW()                 " +
                    $" order by HaraketId, HaraketTarihi";

                    var data = await connection.QueryAsync<HotelRoomSaleRawDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleRawDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleRawDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomIncomeSumList(int year = 0)
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    year = year==0? DateTime.Now.Year:year;
                    var queryString =
                        $" select * from hnl_tf_room_income_summary('{year}.{01}.{01}','{year}.{12}.{31}',144) ";
                    var data = await connection.QueryAsync<HotelRoomSaleSumDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleSumDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleSumDto>>(ex.Message);
            }
        }

        
        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleSumWithAgentList(DateRangeModel dateRangeModel=null)
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    var queryString =
                        $" SELECT * from hnl_tf_room_sale_summary_agency_coutry_market('{DateTime.Now.Year}.{01}.{01}','{DateTime.Now.Year}.{12}.{31}',144)";

                    var data = await connection.QueryAsync<HotelRoomSaleSumDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleSumDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleSumDto>>(ex.Message);
            }
        }


        [CacheAspect(typeof(MemoryCacheManager), 20)]
        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleAgentCountryMarket(DateRangeModel dateRangeModel = null)
        {
            try
            {
                if(dateRangeModel == null)
                {
                    dateRangeModel = new DateRangeModel();
                }

                if (dateRangeModel == null || dateRangeModel.FirstDate < new DateTime(2000, 1, 1))
                    dateRangeModel.FirstDate = new DateTime(DateTime.Now.Year, 1, 1);

                if (dateRangeModel == null || dateRangeModel.LastDate < new DateTime(2000, 1, 1))
                    dateRangeModel.LastDate = new DateTime(DateTime.Now.Year, 12, 31);

                using (var connection = CreatePostgresConnection())
                {

                    var queryString = $" SELECT * from hnl_tf_room_sale_summary_agency_coutry_market(" +
                        $"'{dateRangeModel.FirstDate.Year}.{01}.{01}'," +
                        $"'{dateRangeModel.LastDate.Year}.{12}.{31}',144) ";

                    //if (dateRangeModel.FirstDate.Year > 1 || dateRangeModel.LastDate.Year > 1)
                    //    queryString += $" AND cst.hrk_tarih> '{dateRangeModel.FirstDate.Year}.{dateRangeModel.FirstDate.Month}.{dateRangeModel.FirstDate.Day}' " +
                    //        $"and cst.hrk_tarih<= '{dateRangeModel.LastDate.Year}.{dateRangeModel.LastDate.Month}.{dateRangeModel.LastDate.Day}' ";

                    //queryString += $" GROUP BY cst.hrk_tarih,cst.acenta_adi,cst.ulke_adi  " +
                    //    $" ORDER BY cst.hrk_tarih";


                    var data = await connection.QueryAsync<HotelRoomSaleSumDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleSumDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleSumDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomIncomeByAgentDaily(DateRangeModel dateRangeModel = null)
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    var queryString = $" select * from hnl_vw_room_sale_summary_agency where 1=1 ";

                    if (dateRangeModel.FirstDate.Year > 2000 || dateRangeModel.LastDate.Year > 2000)
                        queryString += $" AND \"ProcessDate\" between '{dateRangeModel.FirstDate.Year}.{dateRangeModel.FirstDate.Month}.{dateRangeModel.FirstDate.Day}' " +
                            $"and '{dateRangeModel.LastDate.Year}.{dateRangeModel.LastDate.Month}.{dateRangeModel.LastDate.Day}' ";
                    else 
                        queryString += $" AND DATE_PART('year', \"ProcessDate\") ={DateTime.Now.Year} ";
                    //queryString += $" GROUP BY cst.hrk_tarih,cst.acenta_adi,cst.ulke_adi  " +
                    //    $" ORDER BY cst.hrk_tarih";


                    var data = await connection.QueryAsync<HotelRoomSaleSumDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleSumDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleSumDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleByAgentDaily(SalesAndReservationDateRangeModel dateRangeModel=null)
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {

                    if (dateRangeModel.SaleDate1 < new DateTime(2000, 1, 1))  
                        dateRangeModel.SaleDate1 = new DateTime(DateTime.Now.Year, 1, 1);

                    if (dateRangeModel.SaleDate2 < new DateTime(2000, 1, 1)) 
                        dateRangeModel.SaleDate2 = new DateTime(DateTime.Now.Year, 12, 31);

                    if (dateRangeModel.ResDate1 < new DateTime(2000, 1, 1))  
                        dateRangeModel.ResDate1 = new DateTime(DateTime.Now.Year, 1, 1);

                    if (dateRangeModel.ResDate2 < new DateTime(2000, 1, 1))  
                        dateRangeModel.ResDate2 = new DateTime(DateTime.Now.Year, 12, 31);

                    var s1 = dateRangeModel.SaleDate1;
                    var s2 = dateRangeModel.SaleDate2;
                    var r1 = dateRangeModel.ResDate1;
                    var r2 = dateRangeModel.ResDate2;

                    var queryString = $" select * from hnl_tf_room_sale_summary_agency('{s1.Year}.{s1.Month}.{s1.Day}','{s2.Year}.{s2.Month}.{s2.Day}'," +
                        $"'{r1.Year}.{r1.Month}.{r1.Day}','{r2.Year}.{r2.Month}.{r2.Day}')  ";
                    
                    var data = await connection.QueryAsync<HotelRoomSaleSumDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleSumDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleSumDto>>(ex.Message);
            }
        }

       
    }
}



