using Microsoft.AspNetCore.Mvc;
using SistemaCadastroContatos.Models;
using SistemaCadastroContatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarDados();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel cadastrar o contato, tente novamente! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
            
            
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try { 


                if (ModelState.IsValid)
                {
                _contatoRepositorio.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                return RedirectToAction("Index");
            }
                return View("Editar", contato);
                
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel alterar o contato, tente novamente! detalhe do erro:{erro.Message}";
            }
            
            return RedirectToAction("Editar", contato);
        }



        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {

            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar o contato.";
                }
                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o contato. Mais detalhes: {erro.Message}";
                return RedirectToAction("Index");
            }
           
            
            
        }
    }
}
