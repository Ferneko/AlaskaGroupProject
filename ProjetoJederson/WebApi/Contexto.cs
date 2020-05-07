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
        public DbSet<Sabores> SABORES { get; internal set; }
        public DbSet<Cliente> CLIENTES { get; internal set; }
    }
}
