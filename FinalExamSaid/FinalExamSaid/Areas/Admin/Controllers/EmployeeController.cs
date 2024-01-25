using FinalExamSaid.Areas.Admin.ViewModels;
using FinalExamSaid.DAL;
using FinalExamSaid.Models;
using FinalExamSaid.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExamSaid.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _db;

        public EmployeeController(IWebHostEnvironment env, AppDbContext db)
        {
            _env = env;
            _db = db;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            decimal total = await _db.Employees.CountAsync();
            int limit = 3;
            decimal tp = Math.Ceiling(total / limit);
            if (total != 0)
            {
                if (page > tp || page <= 0)
                {
                    return await Index(1);
                }
            }
            PaginationVM<Employee> vm = new PaginationVM<Employee>
            {
                CurrentPage = page,
                Limit = limit,
                TotalPage = tp,
                Items = await _db.Employees.Skip((page - 1) * limit).Take(limit).ToListAsync(),
            };

            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (vm.Photo.CheckFileType("Image"))
            {
                ModelState.AddModelError("Photo", "Only images allowed");
                return View();
            }
            if (!vm.Photo.CheckFileSize(2))
            {
                ModelState.AddModelError("Photo", "Cannot exceed 2Mb");
                return View();
            }
            Employee employee = new Employee
            {
                Name = vm.Name,
                Position = vm.Position,
                Image = await vm.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                FbLink = vm.FbLink,
                TwLink = vm.TwLink,
                IgLink = vm.IgLink,
                LiLink = vm.LiLink,
            };

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            UpdateEmployeeVM vm = new UpdateEmployeeVM
            {
                Name = employee.Name,
                Position = employee.Position,
                Image = employee.Image,
                FbLink = employee.FbLink,
                TwLink = employee.TwLink,
                IgLink = employee.IgLink,
                LiLink = employee.LiLink,

            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateEmployeeVM vm)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (vm.Photo is not null)
            {
                if (vm.Photo.CheckFileType("Image"))
                {
                    ModelState.AddModelError("Photo", "Only images allowed");
                    return View();
                }
                if (!vm.Photo.CheckFileSize(2))
                {
                    ModelState.AddModelError("Photo", "Cannot exceed 2Mb");
                    return View();
                }
                employee.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                employee.Image = await vm.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
            }
            employee.Name = vm.Name;
            employee.Position = vm.Position;
            employee.FbLink = vm.FbLink;
            employee.LiLink = vm.LiLink;
            employee.IgLink = vm.IgLink;
            employee.TwLink = vm.TwLink;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Image.DeleteFile(_env.WebRootPath, "assets", "img");
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
