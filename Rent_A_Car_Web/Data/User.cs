namespace Rent_A_Car_Web.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = "defaultUser";
        public string Password { get; set; } = "123456";
        public RoleEnum Role { get; set; } = RoleEnum.Viewer;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string IdentityNumber { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
       
    }
}
