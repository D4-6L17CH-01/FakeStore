namespace FakeStoreWebApp.ViewModels;

public partial class CartViewModel : BaseViewModel
{
    public CartViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [ObservableProperty]
    private Cart cart;
}
