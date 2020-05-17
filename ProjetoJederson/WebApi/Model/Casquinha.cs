using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Casquinha
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
