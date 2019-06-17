using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ponto_Digital.Repositorios;

namespace Ponto_Digital.Controllers {
    public class LoginController : Controller
     {

         private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";

        [HttpGet]
        public IActionResult Logar () {

            return View ();
        }
        [HttpPost]
        public IActionResult Logar(IFormCollection formulario){
        var email = formulario["email"];
        var senha = formulario["senha"];
            
            ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
            var clienteRetornado =  clienteRepositorio.BuscarPorEmailESenha(email,senha);
            
                if(clienteRetornado != null){
                    if (clienteRetornado.Tipo == "admin"){
                        
                         HttpContext.Session.SetString(SESSION_EMAIL, clienteRetornado.Email);
                         HttpContext.Session.SetString(SESSION_CLIENTE, clienteRetornado.Nome);

                        return RedirectToAction("DashBoard","Admin", clienteRetornado);
                    }else{
                         HttpContext.Session.SetString(SESSION_EMAIL, clienteRetornado.Email);
                         HttpContext.Session.SetString(SESSION_CLIENTE, clienteRetornado.Nome);
                        return RedirectToAction("Depoimentos","Cadastro");

                    }
                    
                }else{
                    //mensagem cliente não encontrado
                }
    
            return View();
        }
    }
}