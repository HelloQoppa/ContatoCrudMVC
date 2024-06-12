using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetomvc.Context;
using projetomvc.Models;

namespace projetomvc.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _agendaContext;

        public ContatoController(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contatos = _agendaContext.Contatos.ToList();
            return View(contatos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _agendaContext.Contatos.Add(contato);
                _agendaContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var contato = _agendaContext.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {

            if (ModelState.IsValid)
            {
                var contatoByData = _agendaContext.Contatos.Find(contato.Id);

                if (contatoByData == null)
                {
                    return NotFound();
                }

                contatoByData.Nome = contato.Nome;
                contatoByData.Telefone = contato.Telefone;
                contatoByData.Ativo = contato.Ativo;

                _agendaContext.Contatos.Update(contatoByData);
                _agendaContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(contato);

        }

        public IActionResult Detalhes(int id)
        {
            var contato = _agendaContext.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            var contato = _agendaContext.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoByData = _agendaContext.Contatos.Find(contato.Id);

            _agendaContext.Contatos.Remove(contatoByData);
            _agendaContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}