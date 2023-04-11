using Microsoft.AspNetCore.Mvc;
using Intex2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex2023.Components
{
    public class HeaddirViewComponent : ViewComponent
    {
        private Intex_Database2023Context IntexContext { get; set; }

        public HeaddirViewComponent(Intex_Database2023Context intexContext)
        {
            IntexContext = intexContext;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedHeadDirection = RouteData?.Values["headdir"];

            var types = IntexContext.Burialmains
                .Where(x => x.Headdirection == "E" || x.Headdirection == "W" || x.Headdirection == "N LL" || x.Headdirection == "I")
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
