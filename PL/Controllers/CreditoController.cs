using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CreditoController : Controller
    {
        // GET: Credito

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Credito credito = new ML.Credito();
            credito.Creditos = new List<object> () ;
                ;
            ML.Result result =  BL.Credito.GetAllEF();

            credito.Creditos = result.Objects;

            return View(credito);
        }
    }
}