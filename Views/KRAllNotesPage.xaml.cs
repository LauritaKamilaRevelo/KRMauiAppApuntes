namespace KRMauiAppApuntes.Views;

public partial class KRAllNotesPage : ContentPage
{
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}