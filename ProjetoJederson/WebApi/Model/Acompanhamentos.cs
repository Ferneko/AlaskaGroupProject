using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Acompanhamentos
    {     
        
        public string imagem { get; set; }
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public bool ativo { get; set; }
    }
}