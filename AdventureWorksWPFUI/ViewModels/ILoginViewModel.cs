namespace AdventureWorksWPFUI.ViewModels
{
    public interface ILoginViewModel
    {
        string LoginID { get; set; }
        string Password { get; set; }

        void Login();
    }
}