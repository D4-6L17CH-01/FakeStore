

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

    public override async Task SaveAsync() 
    {
        if(await Validar<Product>(Product))
        {

        }
    }

    public override async Task UndoAsync() { }
}
