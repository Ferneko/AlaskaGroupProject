using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Permissao
    {
        public long id { get; set; }
        public string role { get; set; }
        public string descricao { get; set; }
        public string nome { get; set; }
    }
}
