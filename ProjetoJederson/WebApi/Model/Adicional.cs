using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Adicional
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public decimal valor { get; set; }
        public bool ativo { get; set; }
    }
}
