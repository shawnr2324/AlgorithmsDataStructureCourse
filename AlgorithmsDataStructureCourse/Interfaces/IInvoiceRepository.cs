using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Models;

namespace AlgorithmsDataStructureCourse.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetInvoice(Guid invoiceID);
        Task<List<Invoice>> GetInvoicesForCustomer(Guid customerID);
        Task SaveInvoice(Invoice invoice);
        Task<Customer> GetCustomer(Guid customerID);
        Task<List<Customer>> GetAllCustomers();
    }
}
