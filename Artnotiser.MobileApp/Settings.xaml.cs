namespace ArtNotiser.MobileApp;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        string userId = Preferences.Default.Get("UserId", "");
        if(userId== null || userId.Length == 0)
        {
            userId = "208fdd4d-35a4-4d7d-b2de-17eef6631c23";
        }
        UserId.Text = userId;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Preferences.Default.Set("UserId", UserId.Text);
    }
}