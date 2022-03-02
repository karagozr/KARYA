using Dapper;
using HANEL.BUSINESS.Abstract.Hotel;
using HANEL.MODEL.Dtos.Hotel;
using HANEL.MODEL.Filter.Hotel;
using KARYA.CORE.Concrete.Dapper;
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
                    $" SELECT hrk.id                                                                                                                                            AS \"HaraketId\",                "+             
                    $" hrk.tarih                                                                                                                                                AS \"HaraketTarihi\",            "+
                    $" rez.id                                                                                                                                                   AS \"RezervasyonId\",            "+
                    $" rez.no                                                                                                                                                   AS \"RezervasyonNo\",            "+
                    $" rez.satistarih                                                                                                                                           AS \"SatisTarihi\",              "+
                    $" gece.id                                                                                                                                                  AS \"GecelemeId\",               "+
                    $" acen.id                                                                                                                                                  AS \"AcentaId\",                 "+
                    $" acen.kodu                                                                                                                                                AS \"AcentaKodu\",               "+
                    $" acen.adi                                                                                                                                                 AS \"AcentaAdi\",                "+
                    $" rezulke.id                                                                                                                                               AS \"UlkeId\",                   "+
                    $" rezulke.kodu                                                                                                                                             AS \"UlkeKodu\",                 "+
                    $" rezulke.adi                                                                                                                                              AS \"UlkeAdi\",                  "+
                    $" rez.cintarih                                                                                                                                             AS \"RezCinTarihi\",             "+
                    $" rez.couttarih                                                                                                                                            AS \"RezCoutTarihi\",            "+
                    $" gece.pax                                                                                                                                                 AS \"GecelemePax\",              "+
                    $" gece.chi                                                                                                                                                 AS \"GecelemeChi\",              "+
                    $" gece.fre                                                                                                                                                 AS \"GecelemeFre\",              "+
                    $" gece.beb                                                                                                                                                 AS \"GecelemeBeb\",              "+
                    $" gece.odasayisi                                                                                                                                           AS \"GecelemeOda\",              "+
                    $" dov.id                                                                                                                                                   AS \"DovizId\",                  "+
                    $" dov.kodu                                                                                                                                                 AS \"DovizKodu\",                "+
                    $" dov.adi                                                                                                                                                  AS \"DovizAdi\",                 "+
                    $" rezdetay.cinkuru                                                                                                                                         AS \"RezKur\",                   "+
                    $" kur.kurtutar                                                                                                                                             AS \"EURCinKur\",                "+
                    $" dep.id                                                                                                                                                   AS \"DepkodId\",                 "+
                    $" dep.kodu                                                                                                                                                 AS \"DepkodKodu\",               "+
                    $" dep.adi                                                                                                                                                  AS \"DepkodAdi\",                "+
                    $" dep.departmantipi                                                                                                                                        AS \"DepartmanTipi\",            "+
                    $" kdv.id                                                                                                                                                   AS \"KdvId\",                    "+
                    $" kdv.kodu                                                                                                                                                 AS \"KdvKodu\",                  "+
                    $" hrk.tutar                                                                                                                                                AS \"HaraketTutar\",             "+
                    $" round((hrk.tutar - hrk.tutar / ((kdv.kodu::numeric(9, 2) + 100::numeric)::numeric(9, 2) / 100::numeric)::double precision)::numeric(9, 2), 2)            AS \"HaraketTutarKdv\",          "+
                    $" round((hrk.tutar / ((kdv.kodu::numeric(9, 2) + 100::numeric)::numeric(9, 2) / 100::numeric)::double precision)::numeric(9, 2), 2)                        AS \"HaraketTutarMatrah\",       "+
                    $" hrk.tutardv                                                                                                                                              AS \"HaraketTutarDoviz\",        "+
                    $" round((hrk.tutardv - hrk.tutardv / ((kdv.kodu::numeric(9, 2) + 100::numeric)::numeric(9, 2) / 100::numeric)::double precision)::numeric(9, 2), 2)        AS \"HaraketTutarDovizKdv\",     "+
                    $" round((hrk.tutardv / ((kdv.kodu::numeric(9, 2) + 100::numeric)::numeric(9, 2) / 100::numeric)::double precision)::numeric(9, 2), 2)                      AS \"HaraketTutarDovizMatrah\",  "+
                    $" hrk.aciklama                                                                                                                                             AS \"Aciklama\"                  "+
                    $" FROM hrk hrk                                                                                                                                                                              "+
                    $" LEFT JOIN depkod dep ON hrk.depkodid = dep.id                                                                                                                                             "+
                    $" LEFT JOIN kdv kdv ON hrk.kdvid = kdv.id                                                                                                                                                   "+
                    $" LEFT JOIN doviz dov ON hrk.dovizid = dov.id                                                                                                                                               "+
                    $" LEFT JOIN folio fol ON hrk.folioid = fol.id AND hrk.sirketid = fol.sirketid                                                                                                               "+
                    $" LEFT JOIN rez rez ON fol.rezid = rez.id AND rez.sirketid = fol.sirketid                                                                                                                   "+
                    $" LEFT JOIN rezdetayek rezdetay ON rez.id = rezdetay.id                                                                                                                                     "+
                    $" LEFT JOIN ulke rezulke ON rezdetay.ulkeid = rezulke.id AND rez.sirketid = rezulke.sirketid                                                                                                "+
                    $" LEFT JOIN geceleme gece ON rez.id = gece.rezid AND rez.sirketid = gece.sirketid AND gece.gun = '1900-01-01 00:00:00'::timestamp without time zone AND gece.silinmis = false               "+
                    $" LEFT JOIN acenta acen ON gece.acentaid = acen.id AND gece.sirketid = acen.sirketid                                                                                                        "+
                    $" LEFT JOIN kur as kur ON to_char(kur.tarih, 'YYYYMMDD')= to_char(rez.cintarih, 'YYYYMMDD') AND kur.dovizid = 265                                                                           "+
                    $" WHERE hrk.sirketid = 1  AND rez.silinmis = false and dep.departmantipi = 1 AND rez.couttarih <= NOW()                                                                                     "+
                    $" order by rez.id, hrk.tarih";

                    var data = await connection.QueryAsync<HotelRoomSaleRawDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleRawDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleRawDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleSumList()
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    var queryString =
                        $" SELECT cst.hrk_tarih AS \"ProcessDate\",                                 " +
                        $" SUM(cst.geceleme_pax) AS \"Pax\",                                        " +
                        $" SUM(cst.geceleme_odasayisi) AS \"RoomSum\",                              " +
                        $" ROUND(SUM(cst.geceleme_odasayisi) / 144, 2) AS \"Occupancy\",            " +
                        $" SUM(cvr.cevrimtutar) AS \"IncomeSumEUR\"                                 " +
                        $" FROM viewcastcevrim AS cvr                                               " +
                        $" LEFT JOIN viewcastlist AS cst ON cst.geceleme_id = cvr.geceleme_id       " +
                        $" WHERE cst.hrk_yil = CAST(DATE_PART('year', NOW()) AS VARCHAR)            " +
                        $" GROUP BY cst.hrk_tarih                                                   " +
                        $" ORDER BY cst.hrk_tarih";


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
                        $" SELECT cst.hrk_tarih AS \"ProcessDate\",                             " +
                        $" cst.acenta_adi AS \"AgentName\",                                     " +
                        $" cst.ulke_adi AS \"CountryName\",                                     " +
                        $" SUM(cst.geceleme_pax) AS \"Pax\",                                    " +
                        $" SUM(cst.geceleme_odasayisi) AS \"RoomSum\",                          " +
                        $" ROUND(SUM(cst.geceleme_odasayisi) / 144, 2) AS \"Occupancy\",        " +
                        $" SUM(cvr.cevrimtutar) AS \"IncomeSumEUR\"                             " +
                        $" FROM viewcastcevrim AS cvr                                           " +
                        $" LEFT JOIN viewcastlist AS cst ON cst.geceleme_id = cvr.geceleme_id   " +
                        $" WHERE cst.hrk_yil = CAST(DATE_PART('year', NOW()) AS VARCHAR)        ";

                    if (dateRangeModel.FirstDate.Year>1 || dateRangeModel.LastDate.Year > 1)
                        queryString += $" AND cst.hrk_tarih> '{dateRangeModel.FirstDate.Year}.{dateRangeModel.FirstDate.Month}.{dateRangeModel.FirstDate.Day}' " +
                            $"and cst.hrk_tarih<= '{dateRangeModel.LastDate.Year}.{dateRangeModel.LastDate.Month}.{dateRangeModel.LastDate.Day}' ";

                    queryString += $" GROUP BY cst.hrk_tarih,cst.acenta_adi,cst.ulke_adi  " +
                        $" ORDER BY cst.hrk_tarih";


                    var data = await connection.QueryAsync<HotelRoomSaleSumDto>(queryString);

                    return new SuccessDataResult<IEnumerable<HotelRoomSaleSumDto>>(data.ToList());
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<HotelRoomSaleSumDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleAgentCountryMarket(DateRangeModel dateRangeModel = null)
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    var queryString = $" SELECT cst.hrk_tarih AS \"ProcessDate\",                           " +
                         $" cst.acenta_id AS \"AgentId\",                                                   " +
                         $" cst.acenta_adi AS \"AgentName\",                                                " +
                         $" cst.ulke_adi AS \"CountryName\",                                                " +
                         $" cst.pazar_adi AS \"MarketName\",                                                " +
                         $" SUM(cst.geceleme_pax) AS \"Pax\",                                               " +
                         $" SUM(cst.geceleme_odasayisi) AS \"RoomSum\",                                     " +
                         $" ROUND(SUM(cst.geceleme_odasayisi) / 144, 2) AS \"Occupancy\",                   " +
                         $" SUM(cvr.cevrimtutar) AS \"IncomeSumEUR\"                                        " +
                         $" FROM viewcastcevrim AS cvr                                                      " +
                         $" LEFT JOIN viewcastlist AS cst ON cst.geceleme_id = cvr.geceleme_id              " +
                         $" WHERE cst.hrk_yil = CAST(DATE_PART('year', NOW()) AS VARCHAR)                   " +
                         $" GROUP BY cst.hrk_tarih,cst.acenta_id,cst.acenta_adi,cst.ulke_adi, cst.pazar_adi " +
                         $" ORDER BY cst.hrk_tarih ";

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
                    var queryString = $" SELECT cst.hrk_tarih AS \"ProcessDate\",                           " +
                         $" cst.acenta_id AS \"AgentId\",                                                   " +
                         $" cst.acenta_adi AS \"AgentName\",                                                " +
                         $" SUM(cst.geceleme_pax) AS \"Pax\",                                               " +
                         $" SUM(cst.geceleme_odasayisi) AS \"RoomSum\",                                     " +
                         $" SUM(cvr.cevrimtutar) AS \"IncomeSumEUR\"                                        " +
                         $" FROM viewcastcevrim AS cvr                                                      " +
                         $" LEFT JOIN viewcastlist AS cst ON cst.geceleme_id = cvr.geceleme_id              " +
                         $" WHERE cst.hrk_yil = CAST(DATE_PART('year', NOW()) AS VARCHAR)                   " +
                         $" GROUP BY cst.hrk_tarih,cst.acenta_id,cst.acenta_adi                             " +
                         $" ORDER BY cst.hrk_tarih ";

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

        public async Task<IDataResult<IEnumerable<HotelRoomSaleSumDto>>> RoomSaleByAgentDaily(DateRangeModel dateRangeModel = null)
        {
            try
            {
                using (var connection = CreatePostgresConnection())
                {
                    var queryString = $" SELECT cst.rez_satistarih AS \"SaleDate\",                 " +
                        $" cst.acenta_id AS \"AgentId\",                                            " +
                        $" cst.acenta_adi AS \"AgentName\",                                         " +
                        $" SUM(cst.geceleme_pax) AS \"Pax\",                                        " +
                        $" SUM(cst.geceleme_odasayisi) AS \"RoomSum\",                              " +
                        $" SUM(cvr.cevrimtutar) AS \"IncomeSumEUR\"                                 " +
                        $" FROM viewcastcevrim AS cvr                                               " +
                        $" LEFT JOIN viewcastlist AS cst ON cst.geceleme_id = cvr.geceleme_id       " +
                        $" WHERE DATE_PART('year', cst.rez_satistarih )  = DATE_PART('year', NOW()) " +
                        $" GROUP BY cst.rez_satistarih, cst.acenta_id, cst.acenta_adi               " +
                        $" ORDER BY cst.rez_satistarih ";
                        


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



