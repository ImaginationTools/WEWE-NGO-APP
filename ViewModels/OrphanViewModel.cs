using System.Windows.Input;

namespace WEWE.Maui.ViewModels;

public class OrphanViewModel
{
    public class Orphan
    {
        public string OrphanID { get; set; } = string.Empty;
        public string WidowID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public int Age { get; set; }

        public string SchoolStatus { get; set; } = string.Empty;
        public string PhotoURL { get; set; } = string.Empty;
    }

    public ICommand SaveOrphanCommand { get; }

    public OrphanViewModel()
    {
        SaveOrphanCommand = new Command(SaveOrphan);
    }

    private async void SaveOrphan()
    {
        await Shell.Current.DisplayAlert("Success", "Saved successfully", "OK");
    }
}