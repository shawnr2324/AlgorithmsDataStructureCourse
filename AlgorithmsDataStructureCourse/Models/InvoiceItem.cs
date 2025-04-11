using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructureCourse.Models
{
    public class InvoiceItem
    {
        public Guid ItemID { get; set; }
        public string Description { get; set; } = String.Empty;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal LineTotal
        {
            get
            {
                return Quantity * Price;
            }
        }

    }
}
