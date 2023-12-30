using System.ComponentModel.DataAnnotations;

namespace ApiAppEnglish.Data.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        public string email { get; set; }
    }
}
