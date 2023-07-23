﻿using BTL_VTJob.Data;
using BTL_VTJob.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

namespace BTL_VTJob.Controllers
{
    public class BaiTuyenDungController : Controller
    {
        private readonly ILogger<BaiTuyenDungController> _logger;
        private readonly dbContext _context;

        public BaiTuyenDungController(ILogger<BaiTuyenDungController> logger ,dbContext context)
        {
            _logger = logger;
            _context=context;
        }
        // GET: BaiUngTuyenController

        public async Task<IActionResult> GetList()
        {
            /* string userID = HttpContext.Session.GetString("Email");
             var user = _context.Nguoidung.Where(u=>u.Email==userID);
             if(user != null)
             {
               */
            string email = HttpContext.Session.GetString("Email");

            var user = await _context.Nguoidung.Where(u => u.Email == email).FirstOrDefaultAsync();
            var doanhNghiep = await _context.DoanhNghiep.Where(u => u.UserID == user.UserID).FirstOrDefaultAsync();

            var list = _context.BaiTuyenDung.Where(u=>u.IdDoanhNghiep==doanhNghiep.Id).Include(p => p.DoanhNghiep).Include(p => p.LoaiCongViec);
           
                return View(await list.ToListAsync());
           /* }
            * 
            return Redirect("/home");*/
            
        }
        
        public IActionResult CreateBaiTuyenDung()
        {
           

            
            return View(new BaiTuyenDung());

        }
      
        [HttpPost]
        public async Task<IActionResult> CreateBaiTuyenDung(BaiTuyenDung baiTuyenDung)
        {
            string email = HttpContext.Session.GetString("Email");
            var user = await _context.Nguoidung.Where(u => u.Email == email).FirstOrDefaultAsync();
            var doanhNghiep = await _context.DoanhNghiep.Where(u => u.UserID == user.UserID).FirstOrDefaultAsync();

            baiTuyenDung.IdDoanhNghiep =doanhNghiep.Id ;
            /*var loaiJob= await _context.LoaiJob.Where(u => u.Id== baiTuyenDung.LoaiCongViec.Id).FirstOrDefaultAsync();*/
            baiTuyenDung.LoaiCongViec = baiTuyenDung.LoaiCongViec;
            baiTuyenDung.DoanhNghiep = doanhNghiep;
            baiTuyenDung.NgayDang = DateTime.Now;
            _context.BaiTuyenDung.Add(baiTuyenDung);
            _context.SaveChanges();
          return Redirect("GetList"); ;

        }
        public async Task<IActionResult> GetDSLoaiJob()
        {
             // Kết nối và truy vấn dữ liệu từ cơ sở dữ liệu
                var dsLoaiJob = _context.LoaiJob.ToList();
                // Trả về danh sách các mục cho dropdownlist dưới dạng JSON
                return Json(dsLoaiJob);

        }
      
        [HttpGet]
        public async Task<IActionResult> UpdateBaiTuyenDung(string id)
        {
            var baiTuyenDung= _context.BaiTuyenDung.Where(p=>p.MaBai==id).Include(p => p.DoanhNghiep).Include(p => p.LoaiCongViec).FirstOrDefault();
         


            return View(baiTuyenDung);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBaiTuyenDung(BaiTuyenDung baiTuyenDung)
        {

            var bai = await _context.BaiTuyenDung.Where(u => u.MaBai == baiTuyenDung.MaBai).FirstOrDefaultAsync();
            /* var user = await _context.Nguoidung.Where(u => u.UserID == bai.UserID).FirstOrDefaultAsync();   
             baiTuyenDung.UserID = bai.UserID;
             baiTuyenDung.NguoiDung = user;*/
            var job  = await _context.LoaiJob.Where(u => u.Id == baiTuyenDung.IdLoaiJob).FirstOrDefaultAsync();
            bai.MoTaCV = baiTuyenDung.MoTaCV;
            bai.SoLuongTuyen = baiTuyenDung.SoLuongTuyen;
            bai.MucLuong = baiTuyenDung.MucLuong;
            bai.QuyenLoi = baiTuyenDung.QuyenLoi;
            bai.YeuCau = baiTuyenDung.YeuCau;
            bai.TieuDe = baiTuyenDung.TieuDe;
            bai.HanNopCV = baiTuyenDung.HanNopCV;
            bai.LoaiCongViec = job;
            bai.IdLoaiJob = baiTuyenDung.IdLoaiJob;
            _context.BaiTuyenDung.Update(bai);
            _context.SaveChanges();
            return Redirect("GetList");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var bai = await _context.BaiTuyenDung.Where(u => u.MaBai == id).FirstOrDefaultAsync();
            _context.BaiTuyenDung.Remove(bai);
            _context.SaveChanges();
            return Redirect("GetList");

        }

        public async Task<IActionResult> DetailJob(string id)
        {
            var detaiJob=_context.BaiTuyenDung.Where(u=>u.MaBai == id).Include(p=>p.DoanhNghiep).Include(p => p.LoaiCongViec).FirstOrDefault();
            /*var user = await _context.Nguoidung.Where(u => u.UserID == detaiJob.UserID).FirstOrDefaultAsync();
            var doanhNghiep = await _context.DoanhNghiep.Where(u => u.UserID == user.UserID).FirstOrDefaultAsync();
            ViewBag.Anh = doanhNghiep.Anh;
            ViewBag.ThongTinDN = doanhNghiep.MoTa;
            ViewBag.TenDN = doanhNghiep.TenCT;
            ViewBag.DiaChi = doanhNghiep.DiaChi;*/

            return View(detaiJob);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
