namespace AdventureWorksLibrary.Models
{
    public interface ILoginModel
    {
        string LoginID { get; set; }
        string Password { get; set; }
        string Role { get; set; }
    }
}