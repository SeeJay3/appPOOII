using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.Operations;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                AlunoID = 1,
                Nome = "Aluno Teste",
                Email = "aluno@mail.com",
                Telefone = "(24)99999-9999",
                Endereco = "Rua X, numero 1000",
                Complemento = "AP 1001",
                Bairro = "Bairro do Aluno",
                Municipio = "Cidade do Aluno",
                Uf = "RJ",
                Cep = "27100-000"
            }
        };
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind("Nome", "Email", "Telefone", "Endereco", "Complemento", "Bairro", "Municipio", "Uf", "Cep")] Aluno aluno)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    aluno.AlunoID = alunos.Select(a => a.AlunoID).DefaultIfEmpty(0).Max() + 1;
                    alunos.Add(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return View(alunos);
        }

        public IActionResult Edit(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Aluno aluno)
        {
            alunos.Remove(alunos.Where(a => a.AlunoID == aluno.AlunoID).First());
            alunos.Add(aluno);
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int id)
        {
            var aluno = alunos.FirstOrDefault(a =>a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        public IActionResult Delete(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
                if (aluno == null)
                {
                    return NotFound();
                }
                alunos.Remove(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Não foi possível excluir o aluno: {ex.Message}");
            }
            return View(alunos);
        }

        public IActionResult Index()
        {
            return View(alunos);
        }
    }
}
