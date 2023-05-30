using ViewModel;

namespace MonkeyFinder;

public partial class MainPage : ContentPage
{
    public MainPage(MonkeysViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
