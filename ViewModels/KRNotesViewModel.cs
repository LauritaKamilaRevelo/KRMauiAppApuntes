using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KRMauiAppApuntes.ViewModels
{
    internal class KRNotesViewModel : IQueryAttributable
    {
        public ObservableCollection<ViewModels.KRNoteViewModel> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }
        public KRNotesViewModel()
        {
            AllNotes = new ObservableCollection<ViewModels.KRNoteViewModel>(Models.KRNote.LoadAll().Select(n => new KRNoteViewModel(n)));
            NewCommand = new AsyncRelayCommand(NewKRNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<ViewModels.KRNoteViewModel>(SelectKRNoteAsync);
        }
        private async Task NewKRNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.KRNotePage));
        }

        private async Task SelectKRNoteAsync(ViewModels.KRNoteViewModel note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.KRNotePage)}?load={note.Identifier}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                KRNoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                KRNoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                {
                    matchedNote.Reload();
                    AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
                }
                // If note isn't found, it's new; add it.
                else
                    AllNotes.Insert(0, new KRNoteViewModel(Models.KRNote.Load(noteId)));
            }
        }
    }
}
