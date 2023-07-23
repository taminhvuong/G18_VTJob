﻿using BTL_VTJob.Data;
using BTL_VTJob.Models;
using BTL_VTJob.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace BTL_VTJob.Controllers
{
    public class DangKyController : Controller
    {
        private readonly ILogger<DangKyController> _logger;
        private readonly dbContext _context;
        public DangKyController(ILogger<DangKyController> logger, dbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new RegisterVM());
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormFile file,RegisterVM register)
        {
            if (ModelState.IsValid)
            {

                var checkedUser = _context.Nguoidung.Where(u => u.Email.Equals(register.Email)).FirstOrDefault();
                if (checkedUser != null)
                {
                    ModelState.AddModelError("Email", "Email is exsist");
                    return View(register);
                }
                using (var trans = _context.Database.BeginTransaction())
                {
                    var user = new NguoiDung();
                    user.Email = register.Email;
                    user.Hoten = register.Hoten;
                    user.SoDT = register.SoDT;
                    user.MatKhau = register.MatKhau;
                    user.quyen = register.isProvider == RegisterVM.Quyen.Management ? "Management" : "User";
                    _context.Nguoidung.Add(user);
                    _context.SaveChanges();
                    if (register.isProvider == RegisterVM.Quyen.Management)
                    {
                        var doanhnghiep = new DoanhNghiep();
                        doanhnghiep.UserID = user.UserID;
                        doanhnghiep.TenCT = register.InfoProvider.TenCT;
                        doanhnghiep.MoTa = register.InfoProvider.MoTa;
                        doanhnghiep.DiaChi = register.InfoProvider.DiaChi;
                        if (file != null && file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);

                            register.InfoProvider.Anh = "~/Upload/logo/" + fileName;
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "~/Img/logo", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                        doanhnghiep.Anh = register.InfoProvider.Anh;
                        _context.DoanhNghiep.Add(doanhnghiep);
                        _context.SaveChanges();

                    }
                    trans.Commit();
                    return View("~/Views/Home/Index.cshtml");
                }


            }
            return View(register);
        }
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }



        [HttpPost]
        public IActionResult Register(IFormFile file, RegisterVM register)
        {
            
                var checkedUser = _context.Nguoidung.Where(u => u.Email.Equals(register.Email)).FirstOrDefault();
                if (checkedUser != null)
                {
                    ModelState.AddModelError("Email", "Email is exsist");
                    return View(register);
                }
                using (var trans = _context.Database.BeginTransaction())
                {
                    var user = new NguoiDung();
                    user.Email = register.Email;
                    user.Hoten = register.Hoten;
                    user.SoDT = register.SoDT;
                    user.MatKhau = register.MatKhau;
                    user.quyen = register.isProvider == RegisterVM.Quyen.Management ? "Management" : "User";
                    _context.Nguoidung.Add(user);
                    _context.SaveChanges();
                    if (register.isProvider == RegisterVM.Quyen.Management)
                    {
                        var doanhnghiep = new DoanhNghiep();
                        doanhnghiep.UserID = user.UserID;
                        doanhnghiep.TenCT = register.InfoProvider.TenCT;
                        doanhnghiep.MoTa = register.InfoProvider.MoTa;
                        doanhnghiep.DiaChi = register.InfoProvider.DiaChi;
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        doanhnghiep.Anh = fileName;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                    /*                        doanhnghiep.Anh = register.InfoProvider.Anh;
                    */
                    _context.DoanhNghiep.Add(doanhnghiep);
                        _context.SaveChanges();

                    }
                    trans.Commit();
                    return View("~/Views/Dangky/Login.cshtml");
                }


           
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string  matkhau)
        {
            var user = _context.Nguoidung.SingleOrDefault(u => u.Email == email);
                       if (user != null)
            {
            if (user.Email == email && user.MatKhau == matkhau)
            {
                HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetString("Quyen", user.quyen);
                    HttpContext.Session.SetString("HoTen", user.Hoten);

                    HttpContext.Session.SetInt32("UserID", user.UserID);
                    ViewBag.Email = email;
                return RedirectToAction("Index", "Home");
            }
            else if ( email==null || matkhau == null)
            {
                
                ViewBag.checkMatKhau = "Nhập đủ thông tin";
                return View(); ;
            }
            else if (user.MatKhau != matkhau )
            {

                ViewBag.checkMatKhau = "Sai mật khẩu";
                return View(); ;
            }

            }
            else {
                ViewBag.checkMatKhau = "User không tồn tại";
                return View();
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","DangKy");
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