using Microsoft.AspNetCore.Mvc;
using Prova.Models;
using System.Collections.Generic;
using System.Linq;

namespace Prova.Controllers
{
    public class PessoaController : Controller
    {
        // Armazenamento em memória
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int proximoId = 1;

        public IActionResult Index()
        {
            return View(pessoas);
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Pessoa pessoa)
        {
            pessoa.Id = proximoId++;
            pessoas.Add(pessoa);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa != null)
            {
                pessoas.Remove(pessoa);
            }
            return RedirectToAction("Index");
        }
    }
}
