namespace KRMauiAppApuntes.Views;

public partial class KRNotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public KRNotePage()
    {
        InitializeComponent();
    }
}