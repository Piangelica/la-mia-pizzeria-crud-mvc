using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_01.Data;
using NetCore_01.Models;

namespace NetCore_01.Controllers.Api
{
    [Route("api/[controller]/[action]")]
[ApiController]
public class PizzasController : ControllerBase
{
[HttpGet]
public IActionResult Get(string? search)
        {
            List<Pizze> pizze = new List<Pizze>();

            using (PizzeContext db = new PizzeContext())
            {
if (search != null && search != "")

                {
                   pizze = db.Pizze.Where(pizze => pizze.Nome.Contains(search) || pizze.Descrizione.Contains(search)).ToList<Pizze>();
                }
                else
                {
                    pizze = db.Pizze.Include(pizze=>pizze.Category).ToList<Pizze>(); ;
                }
            }

            return Ok(pizze);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // http://localhost:<port>/api/posts/delete/2

        }


    }
}


/*
pizze = db.Pizze.ToList<Pizze>();
}
return Ok( pizze);
}
}*/



