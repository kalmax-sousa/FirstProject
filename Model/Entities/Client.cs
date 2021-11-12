using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Client
    {
        public int ID { get; set; }
        public string Corporative_name { get; set; }
        public string Fantasy_name { get; set; }
        public int Cnpj { get; set; }
        public string Address_public { get; set; }
        public int Number_home { get; set; }
        public string Address_add { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int Cep { get; set; }

    }
}
