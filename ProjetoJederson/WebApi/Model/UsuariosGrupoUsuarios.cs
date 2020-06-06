using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class UsuariosGrupoUsuarios
    {
        public long id { get; set; }
        public long usuarioId { get; set; }
        public long grupoUsuarioId { get; set; }
        public GrupoUsuario grupoUsuario { get; set; }
        public Usuario usuario { get; set; }
    }
}
