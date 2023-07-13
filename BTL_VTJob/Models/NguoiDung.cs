using System.ComponentModel.DataAnnotations;

namespace BTL_VTJob.Models
{
    public class NguoiDung
    {
        [Key]
        public string UserId { get; set; }
        public string Hoten { get; set; }

        public string Email { get; set; }

        public string MatKhau { get; set; }
        public string DienThoai { get; set; }
        public Quyen Quyen { get; set; }
        public string TenCT { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
    }
}
