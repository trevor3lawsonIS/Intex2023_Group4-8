using Intex2023.Models;
using Intex2023.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intex2023.Controllers
{
    public class HomeController : Controller
    {
        private Intex_Database2023Context IntexContext { get; set; }

        public HomeController(Intex_Database2023Context intexContext)
        {
            IntexContext = intexContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Burials(string adult, string sex, string headdir, int pageNum=1)
        {
            int pageSize = 20;

            int totalNumBurials;

            if (headdir == null && sex == null && adult == null)
            {
                totalNumBurials = IntexContext.Burialmains.Count();
            }
            else if (headdir == null && adult == null && sex != null)
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Sex == sex).Count();
            }
            else if (headdir != null && sex == null && adult == null)
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Headdirection == headdir).Count();
            }
            else if (headdir == null && sex == null && adult != null)
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Adultsubadult == adult).Count();
            }
            else if (headdir != null && sex != null && adult == null)
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Headdirection == headdir)
                    .Where(x => x.Sex == sex)
                    .Count();
            }
            else if (headdir != null && sex == null && adult != null)
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Headdirection == headdir)
                    .Where(x => x.Adultsubadult == adult)
                    .Count();
            }
            else if (headdir == null && sex != null && adult != null)
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Adultsubadult == adult)
                    .Where(x => x.Sex == sex)
                    .Count();
            }
            else
            {
                totalNumBurials = IntexContext.Burialmains
                    .Where(x => x.Adultsubadult == adult)
                    .Where(x => x.Sex == sex)
                    .Where(x=>x.Headdirection == headdir)
                    .Count();
            }

            var x = new BurialViewModel
            {
                Burialmains = IntexContext.Burialmains
                .Where(p => p.Headdirection == headdir || headdir == null)
                .Where(p=>p.Sex == sex || sex == null)
                .Where(p=>p.Adultsubadult == adult || adult == null)
                .OrderBy(x => x.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials = totalNumBurials,
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        public IActionResult Supervised()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
            return View();
        }

        public IActionResult CRUD()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}