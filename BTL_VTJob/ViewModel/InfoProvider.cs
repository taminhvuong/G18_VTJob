using System.ComponentModel.DataAnnotations;

namespace BTL_VTJob.ViewModel
{
    public class InfoProvider
    {
        [Display(Name = ("Tên công ty"))]
        public string? TenCT { get; set; }
        [Display(Name = ("Thông tin công ty"))]
        public string? MoTa { get; set; }

        [Display(Name = ("Địa chỉ"))]
        public string? DiaChi { get; set; }
        [Display(Name = ("Ảnh"))]
        public string? Anh { get; set; }
    }
}
