using System.ComponentModel.DataAnnotations;

namespace ApiAppEnglish.Data.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        public string userName { get; set; }
        [Required]
        [MaxLength(100)]
        public string passWord { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Xin vui lòng nhập tên của bạn")]
        [Display(Name = "FullName")]
        public string fullName { get; set; }
    }
}
