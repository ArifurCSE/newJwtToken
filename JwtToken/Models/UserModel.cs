namespace JwtToken.Models
{
    public class UserLoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserModel
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
  
}
