using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_VTJob.Models
{
    public class DoanhNghiep
    {
        public int Id { get; set; }
        [Display(Name = ("Tên công ty"))]
        public string TenCT { get; set; }
        [Display(Name = ("Thông tin công ty"))]
        public string MoTa { get; set; }

        [Display(Name = ("Địa chỉ"))]
        public string DiaChi { get; set; }
        [Display(Name = ("Ảnh"))]
        public string Anh { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual NguoiDung NguoiDung { get; set; }

    } }
