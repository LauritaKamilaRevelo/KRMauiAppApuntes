namespace KRMauiAppApuntes.Views;

public partial class KRAllNotesPage : ContentPage
{
    public KRAllNotesPage()
    {
        InitializeComponent();
        BindingContext = new Models.KRAllNotes();
    }
    protected override void OnAppearing()
    {
        ((Models.KRAllNotes)BindingContext).LoadNotes();
    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(KRNotePage));
    }
    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.KRNote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(KRNotePage)}?{nameof(KRNotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }

    }
}