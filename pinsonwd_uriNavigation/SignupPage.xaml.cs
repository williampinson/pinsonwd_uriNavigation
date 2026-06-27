using System.Text.RegularExpressions;

namespace pinsonwd_uriNavigation;

public partial class SignupPage : ContentPage
{
    public SignupPage()
    {
        InitializeComponent();
    }

    private async void BtnSignup_Clicked(object sender, EventArgs e)
    {
        if (IsValidEntries())
        {
            Dictionary<string, object> userData = new Dictionary<string, object>
            {
                {"username",$"{Username.Text}"},
                {"email",$"{Email.Text}"},
                {"isValidPassword",$"{true}"}
            };

            await Shell.Current.GoToAsync(nameof(ProfilePage),userData);
        }
    }

    private bool IsValidEntries()
    {
        LblValidationError.Text = "";

        if (string.IsNullOrWhiteSpace(Username.Text))
        {
            LblValidationError.Text += "\n* A valid username is required.";
        }

        if (string.IsNullOrWhiteSpace(Email.Text) || !IsEmailValid(Email.Text))
        {
            LblValidationError.Text += "\n* A valid email is required.";
        }
        if (string.IsNullOrEmpty(Password.Text))
        {
            LblValidationError.Text += "\n* A password is required.";
        }
        else if (string.IsNullOrEmpty(PasswordConfirm.Text)) 
        {
            LblValidationError.Text += "\n* Please enter a password confirmation.";
        }
        else if (!IsMatchPassword(Password.Text, PasswordConfirm.Text))
        {
            LblValidationError.Text += "\n* The password and confirmation must match.";
        }

        return LblValidationError.Text == "";
    }

    private bool IsEmailValid(string email)
    {
        Regex emailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
        return emailRegex.IsMatch(email);
    }
    private bool IsMatchPassword(string password, string passwordConfirm)
    {
        return string.Equals(password, passwordConfirm);
    }
}