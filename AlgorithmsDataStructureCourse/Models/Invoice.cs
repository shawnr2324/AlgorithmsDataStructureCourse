using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Models;

namespace AlgorithmsDataStructureCourse.Models
{
    public class Invoice
    {
        public Guid InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; } = new DateTime();
        public DateTime PaymentDate { get; set; } = new DateTime();
        public Guid CustomerID { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public decimal TaxRate { get; set; }
        public string Currency { get; set; } = "USD";

        //public decimal LateFee
        //{
        //    get
        //    {
        //        if (PaymentDate > InvoiceDate.AddDays(30))
        //        {
        //            return Subtotal * 0.10m;
        //        }
        //        if (PaymentDate > InvoiceDate.AddDays(90))
        //        {
        //            //Charge 10% per day late
        //            int daysLate = (PaymentDate - InvoiceDate.AddDays(60)).Days;
        //            decimal finePerDay = Subtotal * 0.10m;
        //            return finePerDay * daysLate;
        //        }
        //        return 0;
        //    }
        //}
        public decimal Subtotal
        {
            get
            {
                return Items.Sum(i => i.LineTotal);
            }
        }

        public decimal Tax
        {
            get
            {
                return Subtotal * (TaxRate / 100);
            }
        }

        public decimal Total
        {
            get
            {
                return Subtotal + Tax;
            }
        }

    }
}
