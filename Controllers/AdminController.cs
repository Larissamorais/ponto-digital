using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ponto_Digital.Controllers
{
    public class AdminController: Controller
    {
          private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";
        public IActionResult DashBoard(){
            ViewData["Usuario"] = HttpContext.Session.GetString(SESSION_CLIENTE);
            
            return View();
        }
    }
}