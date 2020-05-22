using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Caixa
    {
        public long id { get; set; }
        public DateTime data { get; set; }
        public int tipoMovimentacao { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }

    }
}
