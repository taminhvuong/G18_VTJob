using System.ComponentModel.DataAnnotations;

namespace BTL_VTJob.Models
{
    public enum Quyen
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "Management")]
        Management,
        [Display(Name = "User")]
        User
    }
}
