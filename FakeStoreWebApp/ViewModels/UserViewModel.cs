
namespace FakeStoreWebApp.ViewModels;

public partial class UserViewModel : BaseViewModel
{
    public UserViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [ObservableProperty]
    private User user;
}
