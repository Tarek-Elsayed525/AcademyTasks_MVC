using AcademyTasks.Data;
using AcademyTasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademyTasks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TasksController : Controller
    {
        readonly private ApplicationDBContext _context = new ApplicationDBContext();

        public IActionResult Index(DateTime? searchDate, int page = 1)
        {
            var tasks = _context.TaskItems.OrderBy(t => t.DeadLine).AsQueryable();
            if (searchDate.HasValue)
            {
                tasks = _context.TaskItems.Where(t => t.DeadLine.Date == searchDate.Value.Date);
            }
            int pagesize = 5;
            int totalTasks = tasks.Count();
            int totalPages = (int)Math.Ceiling((double)totalTasks / pagesize);
            tasks = tasks.Skip((page - 1) * pagesize).Take(pagesize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(tasks.AsEnumerable());
        }

        //--------------Create-------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskItem task, IFormFile formFile)
        {

            if (formFile != null && formFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + "-" + formFile.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Admin\\File", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
                task.Logo = fileName;
            }

            _context.TaskItems.Add(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        //--------------Update--------------------------------------------------------------

        [HttpGet]
        public IActionResult Update(int id)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.Id == id);

            return View(task);
        }
        [HttpPost]
        public IActionResult Update(TaskItem task, IFormFile formFile)
        {
            var taskInDb = _context.TaskItems.AsNoTracking().FirstOrDefault(t => t.Id == task.Id);

            if (formFile != null && formFile.Length > 0)
            {
                var FileName = Guid.NewGuid().ToString() + "-" + formFile.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Admin\\File", FileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
                task.Logo = FileName;
                var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Admin\\File", taskInDb.Logo);
                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }
            }
            else
            {
                task.Logo = taskInDb.Logo;
            }

            _context.TaskItems.Update(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        //---------------Delete-------------------------------------------------------------
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _context.TaskItems.FirstOrDefault(t => t.Id == id);

            _context.TaskItems.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }








        // public IActionResult Update(Brand brand, IFormFile ImageFile)

        //{
        //    var brandInDb = _context.Brands.AsNoTracking().FirstOrDefault(c => c.Id == brand.Id);
        //    if (ImageFile != null && ImageFile.Length > 0)
        //    {
        //        var fileName = Guid.NewGuid().ToString() + "-" + ImageFile.FileName;
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Admin\\img", fileName);
        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            ImageFile.CopyTo(stream);
        //        }
        //        brand.Logo = fileName;

        //        var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Admin\\img", brandInDb.Logo);

        //        if (System.IO.File.Exists(oldfilePath))
        //        {
        //            System.IO.File.Delete(oldfilePath);
        //        }
        //    }
        //    else
        //    {
        //        brand.Logo = brandInDb.Logo;
        //    }













        //[HttpGet]
        //public IActionResult Create()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Brand brand, IFormFile ImageFile)

        //{
        //    if (ImageFile != null && ImageFile.Length > 0)
        //    {
        //        var fileName = Guid.NewGuid().ToString() + "-" + ImageFile.FileName;
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Admin\\img", fileName);
        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            ImageFile.CopyTo(stream);
        //        }
        //        brand.Logo = fileName;
        //    }
        //    _context.Brands.Add(brand);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
