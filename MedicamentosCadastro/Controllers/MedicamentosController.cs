using MedicamentosCadastro.Data;
using MedicamentosCadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicamentosCadastro.Controllers
{
    public class MedicamentosController : Controller
    {
        readonly private ApplicationDbContext _db;

        public MedicamentosController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MedicamentosModel> medicamentos = _db.Medicamentos;
            return View(medicamentos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            MedicamentosModel medicamento = _db.Medicamentos.FirstOrDefault(x => x.Id == id); 

            if(medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            MedicamentosModel medicamentos = _db.Medicamentos.FirstOrDefault(x => x.Id == id);

            if(medicamentos == null)
            {
                return NotFound();
            }

            return View(medicamentos);
        }

        [HttpPost]
        public IActionResult Cadastrar(MedicamentosModel medicamentos)
        {
            if (ModelState.IsValid)
            {
                _db.Medicamentos.Add(medicamentos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro Realizado com Sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(MedicamentosModel medicamentos)
        {
            if (ModelState.IsValid)
            {
                _db.Medicamentos.Update(medicamentos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição Realizada com Sucesso!";

                return RedirectToAction("Index");
            }

            return View(medicamentos);
        }

        [HttpPost]
        public IActionResult Excluir(MedicamentosModel medicamentos)
        {
            if(medicamentos == null)
            {
                return NotFound();
            }

            _db.Medicamentos.Remove(medicamentos);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção Realizada com Sucesso!";


            return RedirectToAction("Index");
        }
    }

}
