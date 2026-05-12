using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WEWE.Maui.ViewModels;

public partial class BenefitViewModel : ObservableObject
{
    [ObservableProperty]
    private string benefitID = string.Empty;

    [ObservableProperty]
    private string recipientType = string.Empty;

    [ObservableProperty]
    private string recipientID = string.Empty;

    [ObservableProperty]
    private string benefitCategory = string.Empty;

    [ObservableProperty]
    private decimal amountValue = 0m;

    [ObservableProperty]
    private DateTime dateDelivered = DateTime.Today;

    [ObservableProperty]
    private string fieldOfficerID = string.Empty;

    [ObservableProperty]
    private string lgaOfDistribution = string.Empty;
}