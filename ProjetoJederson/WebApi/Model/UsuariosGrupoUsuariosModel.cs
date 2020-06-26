using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class UsuariosGrupoUsuariosModel
    {
        public long idGrupoUsuario { get; set; }
        public long idUsuario { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
    }
}
