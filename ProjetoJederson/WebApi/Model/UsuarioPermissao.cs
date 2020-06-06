using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class UsuarioPermissao
    {
        public long id { get; set; }
        public long usuarioId { get; set; }
        public long permissaoId { get; set; }
        public Permissao permissao { get; set; }
        public Usuario usuario { get; set; }
    }
}
