namespace FakeStoreWebApp.ViewModels;

public partial class CartsViewModel : BaseListViewModel<Cart>
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

    //TODO: Realizar la sobre escritora del metodo GetAsync
    public override void GetAsync() => new NotImplementedException();

    //TODO: Realizar la sobre escritora del metodo InsertAsync
    public override void InsertAsync() => new NotImplementedException();

    //TODO: Realizar la sobre escritora del metodo UpdateAsync
    public override void UpdateAsync() => new NotImplementedException();

    //TODO: Realizar la sobre escritora del metodo DeleteAsync
    public override void DeleteAsync() => new NotImplementedException();
}
