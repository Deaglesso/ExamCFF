using FinalExamSaid.Areas.Admin.ViewModels;
using FinalExamSaid.DAL;
using FinalExamSaid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExamSaid.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _db;

        public SettingController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Settings.ToListAsync());
        }

        public async Task<IActionResult> Update(int id) 
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Setting setting = await _db.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting is null)
            {
                return NotFound();
            }
            UpdateSettingVM vm = new UpdateSettingVM
            {
                Key= setting.Key,
                Value = setting.Value,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,UpdateSettingVM vm)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Setting setting = await _db.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (setting is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            setting.Value = vm.Value;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
