
namespace FakeStoreWebApp.ViewModels;

public partial class ProductViewModel : BaseViewModel
{
    public ProductViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [ObservableProperty]
    private Product product;
}
