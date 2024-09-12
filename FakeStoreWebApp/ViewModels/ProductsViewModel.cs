namespace FakeStoreWebApp.ViewModels;

public partial class ProductsViewModel : BaseViewModel
{
    public ProductsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private ICollection<Product>? products;

    public async void GetProductsAsync()
    {
        Products = await repository!.Products.GetAllAsync();
        StateHasChanged!();
    }
    public async void InsertProductAsync()
    {
        navigationManager.NavigateTo("/products/nuevo");
    }

    public async void UpdateProductAsync()
    {
        navigationManager.NavigateTo("/products/1");
    }

    public async void DeleteProductAsync() { }
}
