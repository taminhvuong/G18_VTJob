using System.ComponentModel.DataAnnotations;

namespace BTL_VTJob.Models
{
    public class NguoiDung
    {
        [Key]
        public int UserID { get; set; }
        public string Hoten { get; set; }

        public string Email { get; set; }
        public string SoDT { get; set; }
        public string MatKhau { get; set; }
       
        /* public NguoiDung.Quyen quyen { get; set; }*/
        public string quyen { get; set; }
      
       
       /* public enum Quyen
        {
            User,
            Management,
            Admin,
        }*/
    }
}
