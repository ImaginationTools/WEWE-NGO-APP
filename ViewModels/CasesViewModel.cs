using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WEWE.Maui.ViewModels;

public partial class CaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string caseID = string.Empty;

    [ObservableProperty]
    private string caseType = string.Empty; // Widow / Orphan / Other

    [ObservableProperty]
    private string clientID = string.Empty; // WidowID or OrphanID

    [ObservableProperty]
    private string caseTitle = string.Empty;

    [ObservableProperty]
    private string caseDescription = string.Empty;

    [ObservableProperty]
    private string caseStatus = string.Empty; // Open / Pending / Closed

    [ObservableProperty]
    private DateTime dateOpened = DateTime.Today;

    [ObservableProperty]
    private DateTime? dateClosed;

    [ObservableProperty]
    private string assignedOfficerID = string.Empty;

    [ObservableProperty]
    private string lga = string.Empty;
}