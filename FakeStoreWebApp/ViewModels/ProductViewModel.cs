﻿namespace FakeStoreWebApp.ViewModels;

public partial class ProductViewModel : BaseCatViewModel<Product>
{
    public ProductViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private Product product;

    public override async Task InicializarAsync()
    {
        await base.InicializarAsync();
        if (EsNuevo)
            ClearAsync();
        else
            FindAsync();
    }

    public async void FindAsync()
    {
        var a = await repository!.Products.GetAsync(EntidadId);

        //TODO: Corregir error al momento de asignar producto al objeto bindeado
        Product = a;
    }

    public override async void SaveAsync()
    {
        IsBusy = true;
        if (await Validar(Entidad))
        {
            await repository!.Products.InsertAsync(Entidad);
            await notificationService.StatusNotification("Éxito", "El producto se ha guardado correctamente", "success");
            navigationManager?.NavigateTo("/products");
        }
        IsBusy = false;
        ClearAsync();
    }

    private protected async virtual Task<bool> Validar<T>(T? obj) => await Validador.ValidarObjeto(obj, notificationService);

    public override void ClearAsync()
    {
        Entidad = new();
        StateHasChanged?.Invoke();
    }
}
