using HANEL.MODEL.Dtos.Muhasebe;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using KARYA.MODEL.Entities.Netsis;
using NetOpenX.Rest.Client.BLL;
using NetOpenX.Rest.Client.Model.Enums;
using NetOpenX.Rest.Client.Model.NetOpenX;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting.Netsis.NetOpenX
{
    public class NetsisInvoiceService:NetsisBaseService
    {
        ItemSlipsManager _manager;
        public NetsisInvoiceService(Login login) : base(login)
        {
            _manager = new ItemSlipsManager(AUTH);
        }
        public async Task<IDataResult<string>> SaveInvoice(FaturaDto invoice)
        {
            try
            {

                string erpFaturaNo = invoice.FaturaNo;

                if (erpFaturaNo.Length > 15)
                {
                    StringBuilder sb = new StringBuilder(erpFaturaNo);
                   
                    for (int i = 7; i < erpFaturaNo.Length; i++)
                    {
                        if (erpFaturaNo[i] == '0')
                        {
                            sb.Remove(i, 1);
                            break;
                        }else if(erpFaturaNo[i] != '0' && erpFaturaNo.Length - 1 == i)
                        {
                            sb.Remove(7, 1);
                        }
                    }
                    erpFaturaNo = sb.ToString();
                }

                ItemSlips fatura = new ItemSlips();
                ItemSlipsHeader FatUst = new ItemSlipsHeader();
                //KOSULTARIHI
                //FIYATTARIHI
                //fatura.SeriliHesapla = false;
                
                FatUst.Sube_Kodu = invoice.SubeKodu;
                FatUst.Tip = JTFaturaTip.ftAFat;
                FatUst.EXGUMTARIH = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.SIPARIS_TEST = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.FIYATTARIHI = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.EXFIILITARIH = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.ODEMETARIHI = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.ENTEGRE_TRH = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.GIB_FATIRS_NO = invoice.FaturaNo;
                FatUst.Tarih = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.FiiliTarih = Convert.ToDateTime(invoice.FaturaTarihi);
                FatUst.EKACK1 = invoice.Aciklama;
                FatUst.EKACK2 = invoice.Aciklama2;
                FatUst.EKACK15 = invoice.KayitTarihi==null?"": invoice.KayitTarihi.ToString();
                //FatUst.KDV_DAHILMI = false;
                FatUst.Aciklama = invoice.Aciklama;
                FatUst.Proje_Kodu = invoice.ProjeKodu;
                FatUst.CariKod = invoice.CariKodu;
                FatUst.TIPI = JTFaturaTipi.ft_Acik;
                FatUst.FATIRS_NO = erpFaturaNo;
                FatUst.EKACK16 = invoice.Guid;

                //FatUst.GE = 5;
                //FatUst.FAT_ALTM1 = 0.8;
                fatura.KayitliNumaraOtomatikGuncellensin = true;
                fatura.FatUst = FatUst;
                fatura.Kalems = new List<ItemSlipLines>();
                
                foreach (var item in invoice.FaturaDetays)
                {
                    fatura.Kalems.Add(new ItemSlipLines
                    {
                        STra_GCMIK = Convert.ToDouble(item.Miktar),
                        StokKodu = item.StokKodu,
                        STra_DOVTIP = 0,
                        MuhasebeKodu = item.MuhasebeKodu,
                        ReferansKodu = item.ReferansKodu,
                        STra_KDV = Convert.ToDouble(item.Kdv),
                        AlisKDVOran = Convert.ToDouble(item.Kdv),
                        STra_BF = Convert.ToDouble(item.Fiyat),
                        STra_NF = Convert.ToDouble(item.Fiyat),
                        ProjeKodu = item.ProjeKodu,
                        Ekalan = item.KalemAciklama,
                        D_YEDEK10 = Convert.ToDateTime(invoice.FaturaTarihi),
                        Stra_FiiliTar = Convert.ToDateTime(invoice.FaturaTarihi),
                        STra_TAR = Convert.ToDateTime(invoice.FaturaTarihi),
                        STra_testar = Convert.ToDateTime(invoice.FaturaTarihi)


                    });
                }

                var result =  await _manager.PostInternalAsync(fatura);

                if (!result.IsSuccessful)
                {
                    return new ErrorDataResult<string>("NetopenX hata : " + result.ErrorDesc);
                }

                return new SuccessDataResult<string>(result.Data.FatUst.FATIRS_NO,"");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>(ex.Message);
            }
            


        }
        public async Task<IResult> DeleteInvoice(string faturaNo, string cariKodu)
        {
            try
            {
                var result = await _manager.DeleteInternalByIdAsync($"{JTFaturaTip.ftAFat};{faturaNo};{cariKodu}");  

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
       
    }
}


