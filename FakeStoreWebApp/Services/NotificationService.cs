namespace FakeStoreWebApp.Services;

public class NotificationService : INotificationService
{
    private readonly IJSRuntime jsRuntime;
    public NotificationService(IJSRuntime _jsRuntime) => jsRuntime = _jsRuntime;

    public async ValueTask StatusNotification(string titulo, string mensaje, string tipo)
        => await jsRuntime.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipo, false);

    public async ValueTask<bool> BoolNotification(string titulo, string mensaje)
        => await jsRuntime.InvokeAsync<bool>("BoolNotification", titulo, mensaje, "question");

    public async ValueTask ErrorNotification(Exception exception)
    {
        var error = exception.Message;
        if (exception.Message.Contains("401"))
            error = "No tienes permisos para realizar la consulta.";
        await StatusNotification("Oops...", error, "error");
        return;
    }
}
