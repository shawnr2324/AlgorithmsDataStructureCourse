using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Interfaces;
using AlgorithmsDataStructureCourse.Models;
using AlgorithmsDataStructureCourse.Services;

namespace AlgorithmsDataStructureCourse.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private static readonly List<Invoice> _invoices = new List<Invoice>();
        private static readonly List<Customer> _customers = new List<Customer>();

        static InvoiceRepository()
        {
            _customers.Add(new Customer
            {
                CustomerID = Guid.NewGuid(),
                FirstName = "Shawn",
                LastName = "Roy",
                Address = "123 Main St"
            });

            _customers.Add(new Customer
            {
                CustomerID = Guid.NewGuid(),
                FirstName = "Michael",
                LastName = "Phelps",
                Address = "456 Elm St"
            });

            _invoices.Add(new Invoice
            {
                InvoiceID = Guid.NewGuid(),
                InvoiceDate = new DateTime(2025, 4, 1),
                CustomerID = _customers[0].CustomerID,
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemID = Guid.NewGuid(),
                        Description = "Barstools",
                        Quantity = 2,
                        Price = 121.00m
                    },
                    new InvoiceItem
                    {
                        ItemID = Guid.NewGuid(),
                        Description = "Barstools",
                        Quantity = 2,
                        Price = 100.00m
                    },
                    new InvoiceItem
                    {
                        ItemID = Guid.NewGuid(),
                        Description = "Console Table",
                        Quantity = 1,
                        Price = 150.00m
                    }
                },
                TaxRate = 6.0m
            });
        }
        public async Task<Invoice> GetInvoice(Guid invoiceID)
        {
            return _invoices.FirstOrDefault(i => i.InvoiceID == invoiceID);
        }

        public async Task<List<Invoice>> GetInvoicesForCustomer(Guid customerID)
        {
            return _invoices.Where(i => i.CustomerID == customerID).ToList();
        } 

        public async Task SaveInvoice(Invoice invoice)
        {
            _invoices.Add(invoice);
            await Task.CompletedTask;
        }

        public async Task<Customer> GetCustomer(Guid customerID)
        {
            return _customers.FirstOrDefault(c => c.CustomerID == customerID);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await Task.FromResult(_customers.ToList());
        }
    }
}
