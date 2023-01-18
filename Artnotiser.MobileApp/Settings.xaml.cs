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
        UserId.Text = userId;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Preferences.Default.Set("UserId", UserId.Text);
    }
}