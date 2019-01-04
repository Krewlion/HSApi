using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsuarioController:Controller
    {
        [HttpPost]
        public IActionResult Entrar()
        {
            return null;
        }
    }
}
