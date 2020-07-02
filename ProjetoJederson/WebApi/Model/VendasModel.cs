using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class VendasModel
    {
        public VendasModel()
        {
            listaCasquinhas = new List<Casquinha>();
            listaSabores = new List<Sabores>();
            listaAdicionais = new List<Adicional>();
            listaAcompanhamentos = new List<Acompanhamentos>();
            adicionaisSelecionados = new List<Adicional>();
            acompanhamentosSelecionados = new List<Acompanhamentos>();
        }
        public List<Casquinha> listaCasquinhas { get; set; }
        public List<Sabores> listaSabores { get; set; }
        public List<Adicional> listaAdicionais { get; set; }
        public List<Acompanhamentos> listaAcompanhamentos { get; set; }

        public Sabores saborSelecionado { get; set; }
        public Casquinha casquinhaSelecionada { get; set; }
        public List<Adicional> adicionaisSelecionados { get; set; }
        public List<Acompanhamentos> acompanhamentosSelecionados { get; set; }
    }
}
