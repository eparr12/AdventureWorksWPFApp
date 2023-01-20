namespace AdventureWorksWPFClassLibrary.Models
{
    public class LoginModel : ILoginModel
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
