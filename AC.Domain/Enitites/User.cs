using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Domain.Enitites
{
    public class User
    {
        public int Id { get; set; }
        public  string? Name { get; set; }
        public  string? DNI { get; set; }
 
    }

    public class UserDTO
    {
        public int Id { get; set; } 

    }


}
