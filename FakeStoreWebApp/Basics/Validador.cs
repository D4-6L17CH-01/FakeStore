using Common.Tools;
using System.ComponentModel.DataAnnotations;

namespace FakeStoreWebApp.Basics
{
    public static class Validador
    {
        public static async Task<bool> ValidarObjeto<T>(T? obj, INotificationService INotification)
        {
            if (obj != null)
            {

                if (!DataAnnotations.Validate(obj, out List<ValidationResult> results))
                {
                    await INotification.ValidarResultados(results);
                    return false;
                }
            }
            else
                return true;
            return true;
        }
    }
}
