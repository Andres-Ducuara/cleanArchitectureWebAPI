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
        public required string Name { get; set; }
        public required string DNI { get; set; }
    }
}
