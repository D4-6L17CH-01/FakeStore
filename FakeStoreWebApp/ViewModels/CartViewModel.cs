namespace FakeStoreWebApp.ViewModels;

public partial class CartViewModel : BaseCatViewModel
{
    public CartViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [ObservableProperty]
    private Cart cart;

    public override Task InicializarAsync()
    {
        return base.InicializarAsync();
    }

    public override void SaveAsync()
    {
        base.SaveAsync();
    }

    public override void UndoAsync()
    {
        base.UndoAsync();
    }
}
