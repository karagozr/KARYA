using HANEL.BUSINESS.Abstract.Accounting;
using HANEL.DATAACCESS.Abstract.Accounting;
using HANEL.MODEL.DataTransferModels.Accounting;
using HANEL.MODEL.Dtos.Muhasebe;
using HANEL.MODEL.Entities.Muhasebe;
using KARYA.CORE.Concrete.EntityFramework;
using KARYA.CORE.Types.Return;
using KARYA.CORE.Types.Return.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HANEL.BUSINESS.Concrete.Accounting
{
    public class InvoiceManager : BaseManager<Fatura>, IInvoiceManager
    {

        IInvoiceDal _invoiceDal;
        IConfiguration _configuration;
        KARYA.MODEL.Entities.Netsis.Login netsisLogin;
        public InvoiceManager(IInvoiceDal invoiceDal) :base(invoiceDal) {
            _invoiceDal = invoiceDal;
        }
        public InvoiceManager(IInvoiceDal invoiceDal, IConfiguration configuration) : base(invoiceDal)
        {
            _invoiceDal = invoiceDal;
            _configuration = configuration;

            netsisLogin = new KARYA.MODEL.Entities.Netsis.Login
            {
                NetsisUser = _configuration["NetsisEnv:NetsisUser"],
                NetsisPassword = _configuration["NetsisEnv:NetsisPassword"],
                DbName = _configuration["NetsisEnv:DbName"],
                NetOpenXUrl = _configuration["NetsisEnv:NetOpenXUrl"],
                BranchCode = Convert.ToInt32(_configuration["NetsisEnv:BranchCode"]),
            };
        }

        public async Task<IDataResult<int>> CountInvoices(string vknNo)
        {
            try
            {
                var result = await _invoiceDal.Count(x => x.AlanVkn == vknNo || x.AlanTckn==vknNo);
                return new SuccessDataResult<int>(result);
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<int>(ex.Message);
            }
        }

        //public async Task<IDataResult<FaturaDto>> GetByGuidForSave(string guid)
        //{
        //    try
        //    {
        //        var result = await _invoiceDal.Get(x => x.Guid == guid);


        //        var faturaDto = new FaturaDto
        //        {
        //            Guid=result.Guid,
        //            FaturaNo = result.FaturaNo,
        //            CariVkn = result.GonderenVkn,
        //            Vkn = result.AlanVkn,
        //            FaturaTarihi = Convert.ToDateTime(result.FaturaTarihi)
        //        };

        //        using (NetsisCariService cariService = new NetsisCariService(netsisLogin))
        //        {
        //            var cari = await cariService.GetFromVkn(result.GonderenVkn==null?result.GonderenTckn: result.GonderenVkn);
        //            if (cari.Success && cari.Data != null)
        //            {
        //                faturaDto.CariKodu = cari.Data.CariKodu;
        //                faturaDto.CariUnvan = cari.Data.CariUnvan;
        //            }
        //        }

        //        using (NetsisSirketService sirketService = new NetsisSirketService(netsisLogin))
        //        {
        //            var sirketler = await sirketService.GetSube(result.AlanVkn);
        //            if (sirketler.Success == true && sirketler.Data.Count() > 0)
        //            {
        //                faturaDto.SubeKodu = sirketler.Data.First().SubeKodu;
        //                faturaDto.SubeAdi = sirketler.Data.First().Unvan;
        //            }
        //        }

        //        return new SuccessDataResult<FaturaDto>(faturaDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrorDataResult<FaturaDto>(ex.Message);
        //    }
        //}

        public async Task<IDataResult<Fatura>> GetById(string guid)
        {
            try
            {
                var result = await _invoiceDal.Get(x => x.Guid==guid);
                return new SuccessDataResult<Fatura>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Fatura>(ex.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<Fatura>>> GetList(InvoiceFilterModel invoiceFilterModel)
        {
            try
            {
                var result = await _invoiceDal.List(invoiceFilterModel);

                return new SuccessDataResult<IEnumerable<Fatura>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Fatura>>(ex.Message);
            }
        }

        public async Task<IResult> PatchUpdate(FaturaUpdateDto faturaUpdateDto)
        {
            try
            {
                await _invoiceDal.Update(faturaUpdateDto.Fatura,faturaUpdateDto.UpdateColumns);

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
