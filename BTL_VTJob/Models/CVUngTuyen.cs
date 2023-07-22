using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_VTJob.Models
{
    public class CVUngTuyen
    {
        [Key]
        public string MaCV { get; set; }
        public string CV { get; set; }
        [ForeignKey(nameof(UserID))]
        public int UserID { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        [ForeignKey(nameof(MaBai))]
        public string MaBai { get; set; }
        public virtual BaiTuyenDung BaiTuyenDung { get; set; }
      

    }
}
