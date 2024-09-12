namespace FakeStoreWebApp.ViewModels;

public class BaseCatViewModel : BaseViewModel
{
    public BaseCatViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public virtual async void SaveAsync() { }

    public virtual async void UndoAsync() { }
}
