using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Enitites
{
    public class SalesDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public int Amount {  get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal Total { get; set; }

        
    }
}
