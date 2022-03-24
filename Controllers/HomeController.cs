using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        
        private IBowlersRepository brepo { get; set; }
        private ITeamsRepository trepo { get; set; }

        public HomeController(IBowlersRepository btemp, ITeamsRepository ttemp)
        {
            brepo = btemp;
            trepo = ttemp;
        }

        [HttpGet]
        public IActionResult Index(int teamId)
        {
            var bowl = brepo.Bowlers.Where(b => b.TeamID == teamId || teamId == 0).ToList();
            if (teamId != 0)
            {
                ViewBag.Heading = trepo.Teams.SingleOrDefault(t => t.TeamID == teamId).TeamName;
            }
            else
            {
                ViewBag.Heading = "Home";
            }
            
            return View(bowl);
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Team = trepo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {
            brepo.CreateBowler(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int bowlerId)
        {
            Bowler b = brepo.Bowlers.SingleOrDefault(b => b.BowlerID == bowlerId);
            ViewBag.Team = trepo.Teams.ToList();
            return View("Form", b);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            brepo.SaveBowler(b);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int bowlerId)
        {
            Bowler b = brepo.Bowlers.FirstOrDefault(b => b.BowlerID == bowlerId);
            brepo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
