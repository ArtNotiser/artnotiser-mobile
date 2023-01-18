namespace ArtNotiser.MobileApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        string userId = Preferences.Default.Get("UserId", "");
        if (userId != null && userId.Length > 0)
        {
            ArtnotiserRepository x = new ArtnotiserRepository(true);
            await x.GetNotificationsForUser(userId);
            BindingContext = x;

            UpdateLabel.Text = $"Senast uppdaterad {DateTime.Now:HH:mm}";
        }
        else
        {
            UpdateLabel.Text = $"Du måste ange ett användarid i Inställningar.";
        }
    }

    private async void Settings_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }
}

