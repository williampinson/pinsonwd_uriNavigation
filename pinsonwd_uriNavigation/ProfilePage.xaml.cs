namespace pinsonwd_uriNavigation;

[QueryProperty(nameof(Username), "username")]
[QueryProperty(nameof(Email), "email")]
[QueryProperty(nameof(IsValidPassword), "isValidPassword")]
public partial class ProfilePage : ContentPage
{
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsValidPassword { get; set; }
	public ProfilePage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        //base.OnAppearing();
        LblUsername.Text = $"Username: {Username}";
        LblEmail.Text = $"Email: {Email}";
        LblConfirmation.Text = $"{(IsValidPassword ? "Signup successful!" : "Signup unsuccessful. Try again later.")}";
    }

    private async void BtnSignout_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"///{nameof(SignupPage)}");
    }
}