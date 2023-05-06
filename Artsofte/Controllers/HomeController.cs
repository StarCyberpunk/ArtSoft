using Artsofte.Models;
using Artsofte.Models.ViewModels;
using Artsofte.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Artsofte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _Es;
        private readonly IDepartmentService _De;
        private readonly IProgramming_languageService _Pr;

        public HomeController(ILogger<HomeController> logger, IEmployeeService es,IProgramming_languageService pr,IDepartmentService de)
        {
            _logger = logger;
            _Es = es;
            _De = de;
            _Pr = pr;
        }
        // GET: /
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var res = await _Es.spGetAllEmployees();
            return View(res);
        }

        // GET: /add
        [Route("/add")]
        public async Task<ActionResult> Add()
        {
            EditViewModel r = new EditViewModel();
            r.employee = new EmployeeViewModel();
            r.PrList = await _Pr.spGetAllProgramming_language();
            r.deList = await _De.spGetAllDepartment();
            return View(r);
        }

        // POST: /add
        [Route("/add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Add(EditViewModel collection)
        {
            try
            {
                bool flag = await _Es.spAddEmployee(collection.employee);
                if (flag) { return RedirectToAction(nameof(Index)); }
                return RedirectToAction(nameof(Add));
            }
            catch
            {
                return View();
            }
        }
        // GET: /Edit/id
        [Route("/edit/{id}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            EditViewModel r = new EditViewModel();
            r.employee= await _Es.spGetEmployee(id);
            r.PrList = await _Pr.spGetAllProgramming_language();
            r.deList = await _De.spGetAllDepartment();
            return View(r);
        }

        // POST: /Edit
        [Route("/edit/{id}")]
        [HttpPost]
        public async Task<ActionResult> Edit( EditViewModel collection)
        {
            try
            {
               bool flag= await _Es.spUpdateEmployee(collection.employee);
                if (flag) { return RedirectToAction(nameof(Index)); }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View();
            }
        }



        // POST: /delete
        [Route("/delete/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                bool flag = await _Es.spDeleteEmployee(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                 return RedirectToAction(nameof(Index));
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}