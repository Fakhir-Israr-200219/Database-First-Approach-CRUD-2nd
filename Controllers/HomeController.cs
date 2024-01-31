using Database_First_Approach_CRUD_2nd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Database_First_Approach_CRUD_2nd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CodeFirstAppContext DBC;
        public HomeController(ILogger<HomeController> logger, CodeFirstAppContext dBC)
        {
            _logger = logger;
            DBC = dBC;
        }

        public async Task<IActionResult> Index()
        {
            var data = await DBC.Students.ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var data = await DBC.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = await DBC.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var data = await DBC.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student Stu)
        {
            if (ModelState.IsValid)
            {
                DBC.Students.Add(Stu);
                TempData["s"] = "Data Insert Successfully";
                await DBC.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Stu);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student Stu,int? id)
        {
            if (id != Stu.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                DBC.Students.Update(Stu);
                TempData["s"] = "Data Update Successfully";
                await DBC.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Stu);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteData(Student Stu, int? id)
        {
            if (id != Stu.Id)
            {
                return NotFound();
            }
            DBC.Students.Remove(Stu);
            TempData["s"] = "Data Delete Successfully";
            await DBC.SaveChangesAsync();
            return RedirectToAction("Index");
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
