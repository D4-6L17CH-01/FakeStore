namespace FakeStoreWebApp.ViewModels;

public partial class BaseListViewModel<T> : BaseViewModel
{
    public BaseListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private T? selectedItem;

    [ObservableProperty]
    private ICollection<T>? items;

    public override Task InicializarAsync() { return base.InicializarAsync(); }

    public virtual async void SelAsync(T item)
    {
        SelectedItem = item;
        StateHasChanged!();
    }

    public virtual async void GetAsync() { }

    public virtual async void InsertAsync() => navigationManager?.NavigateTo($"/{typeof(T)}/nuevo");

    public virtual async void UpdateAsync()
    {
        if (SelectedItem is not null)
        {
            PropertyInfo prop = SelectedItem.GetType().GetProperty("Id")!;
            int id = (int)prop.GetValue(SelectedItem)!;
            var route = $"{typeof(T).Name}s/{id}";
            navigationManager?.NavigateTo(route);
        }
    }

    public virtual async void DeleteAsync() { }
}
