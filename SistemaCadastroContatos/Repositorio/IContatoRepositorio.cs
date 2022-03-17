using SistemaCadastroContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroContatos.Repositorio
{
    public interface IContatoRepositorio
    {

        List<ContatoModel> BuscarDados();

        ContatoModel Adicionar(ContatoModel contato);
    }
}
