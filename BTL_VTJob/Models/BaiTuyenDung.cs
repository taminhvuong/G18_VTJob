using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_VTJob.Models
{
    public class BaiTuyenDung
    {
        [Key]
        [Required]
        [Display(Name = ("Mã bài viết"))]
        public string? MaBai { get; set; }

        [Display(Name = ("Tiêu đề"))]
        [Required]
        public string? TieuDe { get; set; }

        [Display(Name = ("Số lượng tuyển dụng"))]
        [Required]
        public Int32 SoLuongTuyen { get; set; }

        [Display(Name = ("Mức lương"))]
        [Required]
        public string MucLuong { get; set; }
        [Display(Name = ("Mô tả công việc"))]
        public string? MoTaCV { get; set; }

        [Display(Name = ("Yêu cầu công việc"))]
        [Required]
        public string? YeuCau { get; set; }

        [Display(Name = ("Quyên lợi"))]
        [Required]
        public string? QuyenLoi { get; set; }

        [Display(Name = ("Ngày đăng"))]
        public DateTime NgayDang { get; set;}

        [Display(Name = ("Hạn nộp CV"))]
        [Required]
        public DateTime HanNopCV { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual NguoiDung NguoiDung { get; set; }

        [Display(Name = ("Loại Job"))]
        [Required]
        public int IdLoaiJob { get; set; }
        
        [ForeignKey(nameof(IdLoaiJob))]
        public virtual LoaiJob LoaiCongViec { get; set; }

    }
}
