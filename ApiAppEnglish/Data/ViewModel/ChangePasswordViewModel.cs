namespace ApiAppEnglish.Data.ViewModel
{
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string verifyNewPassword { get; set; }
    }
}
