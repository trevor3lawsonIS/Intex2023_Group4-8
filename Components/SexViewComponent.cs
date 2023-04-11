using Intex2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intex2023.Components
{
    public class SexViewComponent : ViewComponent
    {
        private Intex_Database2023Context IntexContext { get; set; }

        public SexViewComponent(Intex_Database2023Context intexContext)
        {
            IntexContext = intexContext;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedSex = RouteData?.Values["sex"];

            var types = IntexContext.Burialmains
                .Where(x => x.Sex == "M" || x.Sex == "F")
                .Select(x => x.Sex)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
