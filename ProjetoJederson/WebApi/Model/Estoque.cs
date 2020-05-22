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

        public int casquinhaId { get; set; }
        public decimal quantidadeCasquinha { get; set; }
        public Casquinha casquinha { get; set; }

        public int adicionalId { get; set; }
        public decimal quantidadeAdicional { get; set; }
        public Adicional adicional { get; set; }

        public int acompanhamentoId { get; set; }
        public decimal quantidadeAcompanhamento { get; set; }
        public Acompanhamentos acompanhamento { get; set; }

        public int saboresId { get; set; }
        public decimal quantidadeSabores { get; set; }
        public Sabores sabores { get; set; }
    }
}
