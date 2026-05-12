using WEWE.Maui.ViewModels;

namespace WEWE.Maui.Views;

public partial class WidowRegistrationPage : ContentPage
{
    public WidowRegistrationPage(WidowRegistrationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}