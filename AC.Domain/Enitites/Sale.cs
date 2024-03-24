using AC.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Enitites
{
    public class Sale
    { 
        public int Id { get; set; }
        public User UserID { get; set; }
        public DateTime DateS {  get; set; }
        public decimal Total {  get; set; } 

    }

    public class SaleDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }

   
         public class SaleCreateDTO
            {
                public  string? NameUSer { get; set; }
                public  string? DNI { get; set; }
                public required List<ProductDTO> ProductList { get; set; }
         
            }

    public class SaleDetailEspDTO
    {
        public int IdSale { get; set; } 
        public decimal Total { get; set; }
        public required List<ProductDTO> ProductList { get; set; }
        public required List<SalesDetail> DetailsSale { get; set; }

    }


}
