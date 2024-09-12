namespace FakeStoreWebApp.ViewModels;

public partial class UserViewModel : BaseCatViewModel
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

    public override void SaveAsync()
    {
        base.SaveAsync();
    }

    public override void UndoAsync()
    {
        base.UndoAsync();
    }
}
