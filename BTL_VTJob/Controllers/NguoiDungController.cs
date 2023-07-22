using BTL_VTJob.Data;
using BTL_VTJob.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTL_VTJob.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly ILogger<NguoiDungController> _logger;
         private readonly dbContext _context;

        public NguoiDungController(ILogger<NguoiDungController> logger ,dbContext context)
        {
            _logger = logger;
            _context=context;
        }
        public async Task<IActionResult> GetDoanhNghiep()
        {
            var list = _context.DoanhNghiep.Include(p => p.NguoiDung);
            return View(await list.ToListAsync());

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
