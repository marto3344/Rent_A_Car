
using Microsoft.AspNetCore.Identity;
namespace Rent_A_Car_Web.Data
{
    public class User: IdentityUser
    {
        public string NickName { get; set; } = "defaultUser";
        public RoleEnum Role { get; set; } = RoleEnum.Viewer;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string IdentityNumber { get; set; } = "";
        public virtual HashSet<Car> RentedCars { get; set; }
        public User()
        {
                RentedCars = new HashSet<Car>();
        }
       
    }
}
