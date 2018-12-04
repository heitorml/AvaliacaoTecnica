using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace avaliacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
        public BadRequestObjectResult BadRequest(string mensagemErro)
        {
            return base.BadRequest(new { Erro = mensagemErro });
        }

        public ObjectResult Conflict(string mensagemErro)
        {
            return StatusCode((int)HttpStatusCode.Conflict, new { Erro = mensagemErro });
        }
      
    }
}
