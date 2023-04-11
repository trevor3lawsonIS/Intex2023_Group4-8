using Intex2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2023.Components
{
    public class AdultViewComponent : ViewComponent
    {
        private Intex_Database2023Context IntexContext { get; set; }

        public AdultViewComponent(Intex_Database2023Context intexContext)
        {
            IntexContext = intexContext;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedSex = RouteData?.Values["sex"];
            ViewBag.SelectedHeadDirection = RouteData?.Values["headdir"];
            ViewBag.SelectedAdult = RouteData?.Values["adult"];

            var types = IntexContext.Burialmains
                .Where(x => x.Adultsubadult == "A" || x.Adultsubadult == "C" || x.Adultsubadult == "N LL")
                .Select(x => x.Adultsubadult)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
