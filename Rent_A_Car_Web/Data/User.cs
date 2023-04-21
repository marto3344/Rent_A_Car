
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rent_A_Car_Web.Data
{
    [Index(nameof(NickName), IsUnique = true)]//User model ot koito EFC pravi  tablica v bazata danni
    [Index(nameof(IdentityNumber), IsUnique = true)]
    public class User: IdentityUser
    {
        public string NickName { get; set; } = "defaultUser";
        public RoleEnum Role { get; set; } = RoleEnum.Viewer;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string IdentityNumber { get; set; } = "";
        public User()
        {
       
        }
       
    }
}
