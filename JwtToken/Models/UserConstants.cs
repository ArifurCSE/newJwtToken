using System.Collections.Generic;

namespace JwtToken.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { FullName = "Mrs A", EmailAddress = "A@gmial.com",username="A1025478",password="Arif_0125"},
            new UserModel() { FullName = "Mrs B", EmailAddress = "B@gmial.com",username="B1025478",password="Badol_0125"},
            new UserModel() { FullName = "Mrs C", EmailAddress = "C@gmial.com",username="C1025478",password="Choty_0125"},
        };
    }
}
