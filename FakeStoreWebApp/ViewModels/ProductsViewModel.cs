﻿namespace FakeStoreWebApp.ViewModels;

public partial class ProductsViewModel : BaseViewModel
{
    public ProductsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        repository = serviceProvider?.GetService<IRepository>();
        notificationService = serviceProvider?.GetService<INotificationService>()!;
        navigationManager = serviceProvider?.GetService<NavigationManager>();
    }

    private readonly IRepository? repository;
    private readonly INotificationService notificationService;
    private readonly NavigationManager? navigationManager;

    [ObservableProperty]
    private ICollection<Product>? products;

    public async Task GetProductsAsync()
        => Products = await repository!.Products.GetAllAsync();

    public async Task InsertProduct()
    {

    }

    public async Task UpdateProduct() { }

    public async Task DeleteProduct() { }
}
