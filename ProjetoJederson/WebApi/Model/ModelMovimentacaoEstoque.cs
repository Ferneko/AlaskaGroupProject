using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class ModelMovimentacaoEstoque
    {
        public List<Casquinha> todasCasquinhas { get; set; }
        public List<Adicional> todosAdicionais { get; set; }
        public List<Acompanhamentos> todosAcompanhamentos { get; set; }
        public List<Sabores> todosSabores { get; set; }
    }
}
