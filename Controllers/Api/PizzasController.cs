using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                    pizze = db.Pizze.ToList<Pizze>();
                }
            }

            return Ok(pizze);
        }
    }
}
            




                /*
                pizze = db.Pizze.ToList<Pizze>();
            }
            return Ok( pizze);
        }
    }*/
    


