using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VoorbeeldCRUD.Models;
using VoorbeeldCRUD.Persistence;


namespace VoorbeeldCRUD.Controllers
{
    public class HomeController : Controller
    {
        PersistenceCode persistenceCode = new PersistenceCode();

        [HttpGet]
        public IActionResult Index()
        {
            KlantRepository klantRepository = new KlantRepository();
            klantRepository.Klanten = persistenceCode.loadKlanten();
            return View(klantRepository);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(klant Klant)
        {
            if (ModelState.IsValid)
            {
                persistenceCode.insertKlant(Klant);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int KlantID)
        {
            persistenceCode.deleteKlant(KlantID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int KlantID)
        {
            klant Klant = new klant();
            Klant = persistenceCode.loadKlant(KlantID);

            return View(Klant);
        }
        public IActionResult Update(klant Klant)
        {
            if (ModelState.IsValid)
            {
                persistenceCode.UpdateKlant(Klant);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}