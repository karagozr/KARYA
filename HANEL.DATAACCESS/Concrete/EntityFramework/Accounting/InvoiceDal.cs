using HANEL.DATAACCESS.Abstract.Finance;
using HANEL.MODEL.Entities.Finance;
using KARYA.CORE.Concrete.EntityFramework;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;
using HANEL.MODEL.Entities.Muhasebe;
using HANEL.DATAACCESS.Abstract.Accounting;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using HANEL.MODEL.DataTransferModels.Accounting;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HANEL.DATAACCESS.Concrete.EntityFramework.Accounting
{
    public class InvoiceDal : EfRepository<Fatura, HanelContext>, IInvoiceDal
    {
        public async Task<Fatura> GetWithDetail(InvoiceFilterModel invoiceFilterModel)
        {
            using (var context = new HanelContext())
            {
                var result = await context.Fatura.Include(x=>x.FaturaKalems).Include(x=>x.FaturaVergiKalems).FirstOrDefaultAsync(f=>f.Guid==invoiceFilterModel.Ett);
                return result;
            }
        }

        public async Task<IEnumerable<Fatura>> List(InvoiceFilterModel invoiceFilterModel)
        {
            using (var context = new HanelContext())
            {
                var query = context.Fatura.AsQueryable();
                if (invoiceFilterModel.FirstDate != DateTime.MinValue)       query = query.Where(x => x.BelgeTarihi >= invoiceFilterModel.FirstDate);
                if (invoiceFilterModel.LastDate != DateTime.MinValue)        query = query.Where(x => x.BelgeTarihi < invoiceFilterModel.LastDate);
                if (!string.IsNullOrEmpty(invoiceFilterModel.SenderVkn))     query = query.Where(x => x.GonderenVkn == invoiceFilterModel.SenderVkn || x.GonderenTckn == invoiceFilterModel.SenderVkn);
                if (!string.IsNullOrEmpty(invoiceFilterModel.CompanyVkn))    query = query.Where(x => x.AlanVkn == invoiceFilterModel.CompanyVkn);
                if (!string.IsNullOrEmpty(invoiceFilterModel.SenderName))    query = query.Where(x => x.GonderenUnvan.Contains(invoiceFilterModel.SenderName) || x.GonderenAdi.Contains(invoiceFilterModel.SenderName));
                var result = await query.ToListAsync();
                return result;
            }
        }
    }
}
