using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pi_Estate.Data;
using Pi_Estate.Models;
using System.Diagnostics;
using System.Data.Entity;
using System.Linq;

namespace Pi_Estate.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
       // GET: HOME
        public IActionResult Index()
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var ilan=db.Ilans.Include(m=>m.Mahalle).Include(e => e.Tip);
            return View(ilan.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Detay(int id)
        {
            var ilan = db.Ilans.Where(i => i.IlanId==id).Include(m => m.Mahalle).Include(e => e.Tip).FirstOrDefault();
            var imgs = db.Resims.Where(i => i.IlanId == id).ToList();
            ViewBag.imgs = imgs;
            return View(ilan);
        }
        public PartialViewResult Slider()
        {
            var ilan = db.Ilans.ToList().Take(3);
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            return PartialView(ilan);
        }
    }
}
