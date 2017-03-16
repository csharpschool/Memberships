using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Memberships.Controllers
{
    [Authorize]
    public class ProductContentController : Controller
    {
        public async Task<ActionResult> Index(int id)
        {
            return View();
        }
    }
}