using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Controllers
{
    public class ZombieController : Controller
    {
        private ZombiePartyDbContext _baseDonnees { get; set; }

        public ZombieController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<Zombie> zombiesList = _baseDonnees.zombies.ToList();
            return View(zombiesList);
        }

        public IActionResult Create()
        {
            ViewBag.ZombieTypes = new SelectList(_baseDonnees.zombieTypes.ToList(), "Id", "TypeName", null);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Zombie zombie)
        {
            //Si le modèle est valide le zombie est ajouté et nous sommes redirigé vers index.
            if (ModelState.IsValid)
            {
                _baseDonnees.zombies.Add(zombie);
                TempData["Success"] = $"Zombie {zombie.Name} added";
                return this.RedirectToAction("Index");
            }
            //Il faut repopuler le zombieType dans le ViewBag
            //Aller chercher le ZombieType sélectionné, rappel 2W5 Linq
            ZombieType selectedZombieType = _baseDonnees.zombieTypes.Where(zt => zt.Id == zombie.ZombieTypeId).SingleOrDefault();
            zombie.ZombieType = selectedZombieType;

            ViewBag.ZombieTypes = new SelectList(_baseDonnees.zombieTypes.ToList(), "Id", "TypeName", selectedZombieType);

            return View(zombie);
        }

    }
}
