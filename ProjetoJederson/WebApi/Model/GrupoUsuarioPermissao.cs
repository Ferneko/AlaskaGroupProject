using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class GrupoUsuarioPermissao
    {
        public long id { get; set; }
        public long grupoUsuarioId { get; set; }
        public long permissaoId { get; set; }
        public Permissao permissao { get; set; }
        public GrupoUsuario grupoUsuario { get; set; }
    }
}
