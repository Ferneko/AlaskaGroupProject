using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Casquinha
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price  { get; set; }
         public bool Actives { get; set; }
    }
}
