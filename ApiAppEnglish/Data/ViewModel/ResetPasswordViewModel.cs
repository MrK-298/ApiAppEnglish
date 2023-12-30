using System.ComponentModel.DataAnnotations;

namespace ApiAppEnglish.Data.ViewModel
{
    public class ResetPasswordViewModel
    {

        [EmailAddress]
        public string email { get; set; }
        public string newPassword { get; set; }

        public string verificationCode { get; set; }
    }
}
