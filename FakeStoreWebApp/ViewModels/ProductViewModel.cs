namespace FakeStoreWebApp.ViewModels;

public partial class ProductViewModel : BaseCatViewModel
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

    // Usa la propiedad generada 'Product' en lugar de 'product'
    public override async void SaveAsync()
    {
        IsBusy = true;
        if (await Validar(Product))  
        {
            await repository.Products.InsertAsync(Product);
            await notificationService.StatusNotification("Éxito", "El producto se ha guardado correctamente", "success");
            navigationManager.NavigateTo("/products");
        }
        IsBusy = false;
        ClearAsync();
    }

    public override async void UndoAsync() 
    {
        navigationManager.NavigateTo("/products");
    }

    private protected async virtual Task<bool> Validar<T>(T? obj)
     => await Validador.ValidarObjeto(obj, notificationService);

    public override void ClearAsync()
    {
        Product = new Product(); 
        StateHasChanged();
    }
}
