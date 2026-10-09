using AcademyTasks.Data;
using Microsoft.AspNetCore.Mvc;

namespace AcademyTasks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        readonly private ApplicationDBContext _context = new ApplicationDBContext();

        public IActionResult Index()
        {
            var tasks = _context.TaskItems.OrderBy(t => t.DeadLine).AsQueryable();
            return View(tasks.AsEnumerable());
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
