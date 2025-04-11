using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Interfaces;
using AlgorithmsDataStructureCourse.Models;

namespace AlgorithmsDataStructureCourse.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> GenerateNewInvoice(Guid customerID, List<InvoiceItem> items, decimal taxRate, string currency)
        {
            Customer customer = await _invoiceRepository.GetCustomer(customerID);

            if (customer == null)
            {
                throw new ArgumentException("Invalid customer ID");
            }

            Invoice newInvoice = new Invoice();
            newInvoice.InvoiceID = Guid.NewGuid();
            newInvoice.InvoiceDate = DateTime.Now;
            newInvoice.CustomerID = customerID;
            newInvoice.Items = items;
            newInvoice.TaxRate = taxRate;
            newInvoice.Currency = currency;

            await _invoiceRepository.SaveInvoice(newInvoice);

            return newInvoice;
        }

        public Task<FinelTotalAmountDue> CalculateTotalAmountDue(Invoice invoice, DateTime paymentDate)
        {
            if (invoice == null)
            {
                throw new ArgumentException("Invalid invoice");

            }

            decimal totalAmount = invoice.Total;
            decimal lateFee = 0;

            if (paymentDate > invoice.InvoiceDate.AddDays(30))
            {
                //Charge 10% late fee
                lateFee = ThirtyDayLateFee(invoice.Subtotal);
                totalAmount = invoice.Total + lateFee;

            }

            if (paymentDate > invoice.InvoiceDate.AddDays(60))
            {
                
                lateFee = SixtyDayLateFee(invoice.Subtotal, invoice, paymentDate) + ThirtyDayLateFee(invoice.Subtotal);
                totalAmount = invoice.Total + lateFee;
            }

            FinelTotalAmountDue finalTotalAmountDue = new FinelTotalAmountDue
            {
                TotalAmount = totalAmount,
                LateFee = lateFee
            };

            return Task.FromResult(finalTotalAmountDue);
        }

        private decimal ThirtyDayLateFee(decimal subtotal)
        {
            return (subtotal * 0.10m);
        }

        private decimal SixtyDayLateFee(decimal subtotal, Invoice invoice, DateTime paymentDate)
        {
            //Charge 1% per day late additional to 30 day late fee
            int daysLate = (paymentDate - invoice.InvoiceDate.AddDays(60)).Days;
            decimal finePerDay = subtotal * .01m;
            return finePerDay * daysLate;

        }

    }
}
