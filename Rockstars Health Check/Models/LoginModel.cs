namespace HealthCheck.Models
{
    public class LoginModel
    {
        public string email;
        public string password;
        public string redirect;
        public bool failedAttempt;

        public LoginModel(bool failedAttempt, string redirect)
        {
            this.failedAttempt = failedAttempt;
            this.redirect = redirect;
        }

    }
}
