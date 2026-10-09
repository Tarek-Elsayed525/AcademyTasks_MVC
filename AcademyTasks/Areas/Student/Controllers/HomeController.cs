using AcademyTasks.Data;
using AcademyTasks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcademyTasks.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        readonly private ApplicationDBContext _context = new ApplicationDBContext();
        public IActionResult Index(string searchQuery, int page = 1)
        {
            int pageSize = 6;
            var tasks = _context.TaskItems.OrderBy(t => t.DeadLine).AsQueryable();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                tasks = tasks.Where(t => t.Title.Contains(searchQuery));
            }

            int TotalTasks = tasks.Count();
            int TotalPages = (int)Math.Ceiling(TotalTasks / (double)pageSize);

            tasks = tasks.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = TotalPages;
            ViewBag.SearchQuery = searchQuery;

            return View(tasks.AsEnumerable());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
