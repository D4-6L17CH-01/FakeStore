namespace FakeStoreWebApp.ViewModels;

public class BaseCatViewModel : BaseViewModel
{
    public BaseCatViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public virtual async Task SaveAsync() { }

    public virtual async Task UndoAsync() { }
}
