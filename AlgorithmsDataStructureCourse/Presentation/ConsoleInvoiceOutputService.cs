using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Interfaces;
using AlgorithmsDataStructureCourse.Models;

namespace AlgorithmsDataStructureCourse.Presentation
{
    public class ConsoleInvoiceOutputService : IInvoiceOutputService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public ConsoleInvoiceOutputService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task PrintInvoice(Invoice invoice)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            switch (invoice.Currency)
            {
                case "USD":
                    culture = new CultureInfo("en-US");
                    break;

                case "EUR":
                    culture = new CultureInfo("fr-FR");
                    break;

                case "GBP":
                    culture = new CultureInfo("en-GB");
                    break;

                default:
                    culture = new CultureInfo("en-US");
                    break;
            }

            Customer customer = await _invoiceRepository.GetCustomer(invoice.CustomerID);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"               INVOICE");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Invoice Number: {invoice.InvoiceID}");
            Console.WriteLine($"Invoice Date: {invoice.InvoiceDate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Description         Qty   Unit Price   Total");
            Console.WriteLine("---------------------------------------------");

            foreach (var item in invoice.Items)
            {
                Console.WriteLine($"{item.Description} {item.Quantity} {item.Price.ToString("C2", culture)} {item.LineTotal.ToString("C2", culture)}");

                await Task.CompletedTask;
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Subtotal:            {invoice.Subtotal.ToString("C2", culture),10}");
            Console.WriteLine($"Tax ({invoice.TaxRate}%):       {invoice.Tax.ToString("C2", culture),10}");
            Console.WriteLine($"Total:               {invoice.Total.ToString("C2", culture),10}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
