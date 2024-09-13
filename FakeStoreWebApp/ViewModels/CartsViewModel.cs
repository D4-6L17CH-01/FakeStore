namespace FakeStoreWebApp.ViewModels;

public partial class CartsViewModel : BaseViewModel
{
    public CartsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private ICollection<Cart>? carts;
}
