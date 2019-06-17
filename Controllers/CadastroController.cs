using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ponto_Digital.Models;
using Ponto_Digital.Repositorios;

namespace Ponto_Digital.Controllers
{
    public class CadastroController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar(){

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection formulario){
            ClienteModel cliente = new ClienteModel();
            cliente.Nome = formulario["nome"];
            cliente.Senha = formulario["senha"];
            cliente.Email = formulario["email"];
            
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            clienteRepositorio.RegistrarClienteNoCSV(cliente);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Depoimentos(){
            
            return View();
        }

    }
}