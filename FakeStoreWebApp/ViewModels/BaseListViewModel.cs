namespace FakeStoreWebApp.ViewModels;

public partial class BaseListViewModel<T> : BaseViewModel
{
    public BaseListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

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

    public virtual async void InsertAsync() { }

    public virtual async void UpdateAsync() { }

    public virtual async void DeleteAsync() { }
}
