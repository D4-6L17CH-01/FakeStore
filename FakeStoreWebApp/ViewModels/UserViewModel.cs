namespace FakeStoreWebApp.ViewModels;

//TODO: Implementar los metodos sin implementar
public partial class UserViewModel : BaseCatViewModel<User>
{
    public UserViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private User user;

    public override void SaveAsync() => base.SaveAsync();

    public override void UndoAsync() => throw new NotImplementedException();
}
