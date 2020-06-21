using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Venda
    {
        public long  id { get; set; }
        public DateTime dataVenda { get; set; }
        public long clienteId { get; set; }
        public Cliente cliente { get; set; }
        public decimal valorTotal { get; set; }
        
    }
}
