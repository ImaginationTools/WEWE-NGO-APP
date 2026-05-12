using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using WEWE.Maui.Models;
using WEWE.Maui.Services;


namespace WEWE.Maui.ViewModels
{
    public partial class WidowRegistrationViewModel : ObservableObject
    {
        private readonly DatabaseService _dbService;
        [ObservableProperty] private string? fullName;
        [ObservableProperty] private string? nationalID;
        [ObservableProperty] private string? phoneNumber;
        [ObservableProperty] private DateTime dob = DateTime.Today;
        [ObservableProperty] private int dependentsCount;
        [ObservableProperty] private decimal monthlyIncome;
        [ObservableProperty] private bool hasDisability;
        [ObservableProperty] private string? housingStatus;
        [ObservableProperty] private string? lga;
        [ObservableProperty] private string? state;

        public WidowRegistrationViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        [RelayCommand]
        private void SaveWidow()
        {
            var widow = new WidowRegistration
            {
                FullName = FullName,
                NationalID = NationalID,
                PhoneNumber = PhoneNumber,
                DOB = Dob,
                DependentsCount = DependentsCount,
                MonthlyIncome = MonthlyIncome,
                HasDisability = HasDisability,
                HousingStatus = HousingStatus,
                LGA = Lga,
                State = State
            };

            _dbService.AddWidow(widow);
        }
    }
}