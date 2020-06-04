using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Estoque
    {
        public long id { get; set; }
        public DateTime data { get; set; }
        public int tipoMovimentacao { get; set; }

        public long casquinhaId { get; set; }
        public decimal quantidadeCasquinha { get; set; }
        public Casquinha casquinha { get; set; }

        public long adicionalId { get; set; }
        public decimal quantidadeAdicional { get; set; }
        public Adicional adicional { get; set; }

        public long acompanhamentoId { get; set; }
        public decimal quantidadeAcompanhamento { get; set; }
        public Acompanhamentos acompanhamento { get; set; }

        public long saboresId { get; set; }
        public decimal quantidadeSabores { get; set; }
        public Sabores sabores { get; set; }
    }
}
