using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructureCourse.Models;

namespace AlgorithmsDataStructureCourse.Interfaces
{
    public interface IInvoiceOutputService
    {
        Task PrintInvoice(Invoice invoice);
    }
}
