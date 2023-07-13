using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_VTJob.Models
{
    public class BaiTuyenDung
    {
        [Key]
        public string MaBai { get; set; }
        public string TieuDe { get; set; }
        public string LoaiCongViec { get; set; }
        public int SoLuongTuyen { get; set; }
        public float MucLuong { get; set; }
        public string MoTaCV { get; set; }
        public string YeuCau { get; set; }
        public string QuyenLoi { get; set; }
        public DateTime NgayDang { get; set;}
        public DateTime HanNopCV { get; set; }
        [ForeignKey(nameof(UserID))]
        public string UserID { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
