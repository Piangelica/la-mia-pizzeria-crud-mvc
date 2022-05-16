﻿using LaMiaPizzeria.Models;
using LaMiaPizzeria.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Controllers
{
    public class PizzeController : Controller
    {
        public IActionResult Index(string nome, string descrizione, double prezzo, string immagine)
        {
            List<Pizze> pizze = PizzeData.GetPizze();
            return View("HomePage", pizze);
        }

    

        [HttpGet]

        public IActionResult Details(int id)
        {
            Pizze pizzaTrovata = GetPizzaById(id);

            if (pizzaTrovata != null)
            {
                return View("Details", pizzaTrovata);
            }
            else
            {
                return NotFound("La pizza con l'id " + id + "non è stato trovato");
            }

        }

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

            Pizze pizzaConId = new Pizze(PizzeData.GetPizze().Count, nuovaPizza.Immagine, nuovaPizza.Nome, nuovaPizza.Descrizione, nuovaPizza.Prezzo);

            PizzeData.GetPizze().Add(pizzaConId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Pizze pizzaDaModificare = GetPizzaById(id);

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

        }

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
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
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

        }
    }



}