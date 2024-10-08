using FakeStoreWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddBlazorBootstrap();

#region Servicios
builder.Services.AddScoped<ProductsViewModel>();
builder.Services.AddScoped<ProductViewModel>();
builder.Services.AddScoped<CartsViewModel>();
builder.Services.AddScoped<CartViewModel>();
builder.Services.AddScoped<UsersViewModel>();
builder.Services.AddScoped<UserViewModel>();

builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddSingleton<IRepository, RestRepository>(x => new RestRepository(Herramientas.GetUrl()));
#endregion

builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();