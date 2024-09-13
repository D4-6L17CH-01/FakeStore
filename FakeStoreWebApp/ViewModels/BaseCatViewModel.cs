namespace FakeStoreWebApp.ViewModels;

public partial class BaseCatViewModel<T> : BaseViewModel
{
    public BaseCatViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private T entidad;

    [ObservableProperty]
    private int entidadId;

    [ObservableProperty]
    private bool esNuevo;

    public override async Task InicializarAsync()
    {
        EsNuevo = EntidadId == 0;
        await base.InicializarAsync();
    }

    public virtual async void SaveAsync() { }
    public virtual async void UndoAsync() => navigationManager?.NavigateTo($"/{typeof(T).Name}s");
    public virtual async void ClearAsync() { }
}
