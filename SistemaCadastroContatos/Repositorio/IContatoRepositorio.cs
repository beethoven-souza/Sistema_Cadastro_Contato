using SistemaCadastroContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Atualizar(ContatoModel contato);
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarDados();

        ContatoModel Adicionar(ContatoModel contato);

        bool Apagar(int id);
    }
}
