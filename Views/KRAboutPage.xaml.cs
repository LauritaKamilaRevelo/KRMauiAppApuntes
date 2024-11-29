namespace KRMauiAppApuntes.Views;

public partial class KRAboutPage : ContentPage
{
	public KRAboutPage()
	{
        InitializeComponent();
	}
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.KRAbout about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}