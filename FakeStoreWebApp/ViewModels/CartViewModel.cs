namespace FakeStoreWebApp.ViewModels;

//TODO: Implementar los metodos sin implementar
public partial class CartViewModel : BaseCatViewModel<Cart>
{
    //TODO: Completar la logica del constructor para inicializar los servicios
    public CartViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    //TODO: Agregar los servicios a utilizar Ej: IRepository

    [ObservableProperty]
    private Cart cart;

    public override Task InicializarAsync()
    {
        return base.InicializarAsync();
    }

    public override void SaveAsync() => throw new NotImplementedException();

    public override void UndoAsync() => base.UndoAsync();
}
