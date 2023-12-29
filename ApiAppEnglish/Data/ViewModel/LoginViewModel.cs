using System.ComponentModel.DataAnnotations;

namespace ApiAppEnglish.Data.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        public string userName { get; set; }
        [Required]
        [MaxLength(100)]
        public string passWord { get; set; }
    }
}
