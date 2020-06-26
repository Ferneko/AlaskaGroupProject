using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class GrupoUsuarioPermissaoModel
    {
       
        public long idPermissao { get; set; }
        public long idGrupoUsuario { get; set; }
        public string descricao { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
    }
}
