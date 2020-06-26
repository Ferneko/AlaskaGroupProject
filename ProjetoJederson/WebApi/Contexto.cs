using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
        { }
        
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Acompanhamentos> ACOMPANHAMENTOS { get; set; }
        public DbSet<Casquinha> CASQUINHAS { get; set; }
        public DbSet<Adicional> ADICIONAIS { get; set; }
        public DbSet<Sabores> SABORES { get; set; }
        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Caixa> CAIXA { get; set; }
        public DbSet<Estoque> ESTOQUE { get; set; }
        public DbSet<Venda> VENDAS { get; set; }
        public DbSet<ItensVenda> ITENS_VENDA { get; set; }

        public DbSet<Permissao> PERMISSAO { get; set; }
        public DbSet<GrupoUsuario> GRUPO_USUARIO { get; set; }

        public DbSet<GrupoUsuarioPermissao> GRUPO_USUARIO_PERMISSAO { get; set; }
        public DbSet<UsuariosGrupoUsuarios> USUARIOS_GRUPO_USUARIOS { get; set; }
        public DbSet<UsuarioPermissao> USUARIO_PERMISSAO { get; set; }
    }
}
