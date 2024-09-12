

namespace FakeStoreWebApp.ViewModels;

public partial class ProductViewModel : BaseViewModel
{
    public ProductViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }
    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;
    
    [ObservableProperty]
    private Product product = new();

    public async Task SaveAsync() 
    {
        if(await Validar<Product>(Product))
        {

        }
    }

    public async void UndoAsync() { }
    private protected async virtual Task<bool> Validar<T>(T? obj)
     => await Validador.ValidarObjeto(obj, notificationService);
}
