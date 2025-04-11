using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Models;

namespace AlgorithmsDataStructureCourse.Interfaces
{
    public  interface IInvoiceService
    {
        Task<Invoice> GenerateNewInvoice(Guid customerID, List<InvoiceItem> items, decimal taxRate, string currency);
        Task<FinelTotalAmountDue> CalculateTotalAmountDue(Invoice invoice, DateTime paymentDate);

    }
}
