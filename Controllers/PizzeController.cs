using Microsoft.AspNetCore.Mvc;
using NetCore_01.Data;
using NetCore_01.Models;


namespace NetCore_01.Controllers
{
    public class PizzeController : Controller
    {
       [HttpGet]
       public IActionResult Index(string SearchString)
    {
            List<Pizze> pizze = new List<Pizze>();

        using(PizzeContext db = new PizzeContext())

        {
                if (SearchString != null)
                {
                    pizze = db.Pizze.Where(pizze => pizze.Nome.Contains(SearchString) || pizze.Descrizione.Contains(SearchString)).ToList<Pizze>();
                }
                else
                {
                    pizze = db.Pizze.ToList<Pizze>();
                }
        }

            return View("Homepage", pizze);
            }

        [HttpGet]

        public IActionResult Details(int id)
        {
           
            using (PizzeContext db = new PizzeContext())

            {
                try
                {

                    Pizze pizzaTrovata = db.Pizze
                     .Where(Pizze => Pizze.Id == id)
                     .First();

                    return View("Details", pizzaTrovata);
                } catch (InvalidOperationException ex)
                {
                    return NotFound("La pizza con l'id " + id + "non è stato trovata");
                } catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
            /*if (pizzaTrovata != null)
                {
                   
                }
                else
                



                /*Pizze pizzaTrovata = GetPizzaById(id);

                if (pizzaTrovata != null)
                {
                    return View("Details", pizzaTrovata);
                }
                else
                {
                    return NotFound("La pizza con l'id " + id + "non è stato trovato");
                }

            }*/

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPizze");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizze nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPizze", nuovaPizza);
            }

             using(PizzeContext db =new PizzeContext())

                    {
                        Pizze pizzeDaCreare = new Pizze(nuovaPizza.Nome, nuovaPizza.Descrizione, nuovaPizza.Immagine);
                        db.Pizze.Add(pizzeDaCreare);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                // Pizze pizzaConId = new Pizze(PizzeData.GetPizze().Count, nuovaPizza.Immagine, nuovaPizza.Nome, nuovaPizza.Descrizione, nuovaPizza.Prezzo);

                // PizzeData.GetPizze().Add(pizzaConId);
                // return RedirectToAction("Index");
            

        [HttpGet]
        public IActionResult Update(int id)
        {
                Pizze? pizzaDaModificare = null;
                using (PizzeContext db = new PizzeContext())
                {
                    pizzaDaModificare = db.Pizze
                         .Where(Pizze => Pizze.Id == id)
                         .FirstOrDefault();
                }
                if (pizzaDaModificare == null)
                {
                    return NotFound();
                }
                else
                {
                    return View("Update", pizzaDaModificare);
                }
            }

        [HttpPost]
        public IActionResult Update(int id, Pizze model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            Post pizzeToEdit = null;

            using (PizzeContext db = new PizzeContext())
            {
                pizzeToEdit = db.Pizze
                     .Where(pizze => pizze.Id == id)
                     .FirstOrDefault();


                if (pizzeToEdit != null)
                {
                    pizzeToEdit.Title = model.Nome;
                    pizzeToEdit.Description = model.Descrizione;
                    pizzeToEdit.Image = model.Immagine;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        /* Pizze pizzaDaModificare = GetPizzaById(id);

         if (pizzaDaModificare == null)
         {
             return NotFound();
         }
         else
         {
             return View("Update", pizzaDaModificare);
         }
        */


        /*[HttpPost]

         public IActionResult Update(int id, Pizze model)
         {
             if (!ModelState.IsValid)
             {
                 return View("Update", model);
             }
                 Pizze? pizzaDaModificare = null;
                 using (BlogContext db = new BlogContext())
                 {
                 pizzaDaModificare = db.Pizze
                         .Where(Pizze => Pizze.Id == id)
                         .FirstOrDefault();


             if (pizzaDaModificare != null)
             {
                 pizzaDaModificare.Nome = model.Nome;
                 pizzaDaModificare.Descrizione = model.Descrizione;
                 pizzaDaModificare.Immagine = model.Immagine;
                 pizzaDaModificare.Prezzo = model.Prezzo;

                     db.SaveChanges();

                 return RedirectToAction("Index");
             }
             else
             {
                 return NotFound();
             }
             }

             /*
             Pizze pizza = GetPizzaById(id);
             if (pizza != null)
             {
                 pizza.Nome = model.Nome;
                 pizza.Descrizione = model.Descrizione;
                 pizza.Immagine = model.Immagine;
                 pizza.Prezzo = model.Prezzo;

                 return RedirectToAction("Index");
             }
             else
             {
                 return NotFound();
             }
 */
    }
        /*
        private Pizze GetPizzaById(int id)
        {
            Pizze pizzaTrovata = null;

            foreach (Pizze pizza in PizzeData.GetPizze())
            {
                if (pizza.Id == id)
                {
                    pizzaTrovata = pizza;
                    break;
                }
            }
            return pizzaTrovata;
        }*/

 [HttpPost]
    public IActionResult Delete(int id)
{
    using PizzeContext db = new PizzeContext();
    Pizze? pizzaDaRimuovere = db.Pizze
.Where(Pizze => Pizze.Id == id)
.First();
    if (pizzaDaRimuovere != null)
    {
        db.Pizze.Remove(pizzaDaRimuovere);
        db.SaveChanges();

        return RedirectToAction("Index", "Pizze");
    }
    else
    {
        return NotFound();
    }
}
}

    }
}
    /*IActionResult NotFound()
    {
        throw new NotImplementedException();
    }

    IActionResult RedirectToAction(string v)
{
    throw new NotImplementedException();
}

/*
int IndexPizzaDaRimuovere = -1;
List<Pizze> listaPizze = PizzeData.GetPizze();

for (int i = 0; i < PizzeData.GetPizze().Count; i++)
{
if (listaPizze[i].Id == id)
{
    IndexPizzaDaRimuovere = i;
}
}
if (IndexPizzaDaRimuovere != -1)
{
PizzeData.GetPizze().RemoveAt(IndexPizzaDaRimuovere);
return RedirectToAction("Index");

}
else
{
return NotFound();
}
*/
