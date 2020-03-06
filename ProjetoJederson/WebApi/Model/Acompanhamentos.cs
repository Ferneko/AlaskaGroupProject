using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Acompanhamentos
    {
        internal bool ativo;

        public long id { get; set; }

       public string nome { get; set; }

       public string descricao { get; set; }

       public decimal valor { get; set; }
        public object Name { get; internal set; }
    }
}