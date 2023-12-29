

using ApiAppEnglish.Data.EF;

namespace HutechDriverApp.Function
{
    public class UserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  User GetUserByEmail(string email)
        {
            return _dbContext.users.FirstOrDefault(u => u.Email == email);
        }

        public void SaveVerificationCode(int userId, string verificationCode)
        {
            var user = _dbContext.users.Find(userId);
            if (user != null)
            {
                user.VerificationCode = verificationCode;
                _dbContext.SaveChanges();
            }
        }

        public bool VerifyCode(int userId, string verificationCode)
        {
            var user = _dbContext.users.Find(userId);
            return user != null && user.VerificationCode == verificationCode;
        }

        public void UpdateUser(User user)
        {
            var existingUser = _dbContext.users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.userName = user.userName;
                existingUser.passWord = user.passWord;
                existingUser.Email = user.Email;
                existingUser.fullName = user.fullName;

                _dbContext.SaveChanges();
            }
        }
    }
}
