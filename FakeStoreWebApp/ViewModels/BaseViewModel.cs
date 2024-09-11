using Common.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FakeStoreWebApp.ViewModels;

public partial class BaseViewModel: ObservableObject
{
    private readonly IRepository repository;
    public BaseViewModel(IServiceProvider serviceProvider)
    {
        repository = serviceProvider.GetService<IRepository>()!;
    }

    [ObservableProperty]
    private int numeroRegistros;

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private Action? stateHasChanged;

    public async virtual Task InicializarAsync()
    {

    }
}
