using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class ItensVenda
    {
        public long id { get; set; }
        public long vendaId { get; set; }
        public Venda venda { get; set; }

        public long casquinhaId { get; set; }
        
        public decimal valorCasquinha { get; set; }

        public long saborId { get; set; }
        
        public decimal valorSabor { get; set; }

        public long acompanhamentosId { get; set; }
        
        public decimal valorAcompanhamentos { get; set; }

        public long adicionalId { get; set; }
        
        public decimal valorAdicional { get; set; }

    }
}
