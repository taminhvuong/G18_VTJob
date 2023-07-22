
using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace BTL_VTJob.ViewModel
{
    public class RegisterVM
    {
        [Display(Name=("Họ và tên"))]
        [Required(ErrorMessage ="Required*")] 
        
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Required*")]

        public string Email { get; set; }
        [Display(Name = ("Số điện thoại"))]
        [Required(ErrorMessage = "Required*")]

        public string SoDT { get; set; }
        [Display(Name = ("Mật khẩu"))]
        [Required(ErrorMessage = "Required*")]

        public string MatKhau { get; set; }
        [Display(Name = ("Xác nhận Mật khẩu"))]
        [Required(ErrorMessage = "Required*")]

        public string MatKhauXacNhan { get; set; }
        [Display(Name = ("Bạn là doanh nghiệp?"))]
        public Quyen isProvider { get; set; }
        public RegisterVM()
        {
            InfoProvider = new InfoProvider();
        }

        public InfoProvider InfoProvider { get; set; }
        /* [Display(Name = ("Tên công ty"))]
         public string? TenCT { get; set; }

         [Display(Name = ("Thông tin công ty"))]
         public string? MoTa { get; set; }

         [Display(Name = ("Địa chỉ"))]
         public string? DiaChi { get; set; }*/
        public enum Quyen
        {
            User,
            Management,
           
        }
    }
}
