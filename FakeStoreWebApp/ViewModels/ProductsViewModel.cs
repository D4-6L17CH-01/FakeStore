namespace FakeStoreWebApp.ViewModels;

public partial class ProductsViewModel : BaseListViewModel<Product>
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

    public override async void GetAsync()
    {
        Items = await repository!.Products.GetAllAsync();
        StateHasChanged!();
    }
    public override async void InsertAsync()
        => navigationManager?.NavigateTo("/products/nuevo");

    public override async void UpdateAsync()
    {
        if (SelectedItem is null)
        {
            await notificationService.StatusNotification("Validación", "Se debe seleccionar un registro", "error");
            return;
        }
            
        navigationManager?.NavigateTo($"/products/{SelectedItem?.Id}");
    }
        

    public override async void DeleteAsync()
    {
        await repository!.Products.DeleteAsync(SelectedItem!.Id);
        StateHasChanged!();
    }
}
