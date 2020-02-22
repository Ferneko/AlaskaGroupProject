using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Usuario
    {
        public long id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
    }
}
