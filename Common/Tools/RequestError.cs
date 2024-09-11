using System.ComponentModel.Design;
using System.Drawing;
using Microsoft.AspNetCore.Connections;

namespace Common.Tools;

public class RequestError
{
    public DateTime Fechahora { get; set; }
    public int StatusCode { get; set; }
    public string Codigo { get; set; }
    public Exception Error { get; set; }
    public string TipoError { get; set; }
    public string Message { get; set; }  // message -> debe llamarse siempre message compatible con la clase exception y otros

    public RequestError() => Fechahora = DateTime.UtcNow;
    public RequestError(Exception ex) { Fechahora = DateTime.UtcNow; this.seterror(ex); }

    private void seterror(Exception ex)
    {
        this.Error = ex;

        if (ex is ApplicationException)
        {
            StatusCode = 400;
            TipoError = "Application";
        }
        else if (ex is UnauthorizedAccessException)
        {
            StatusCode = 401;
            TipoError = "UnauthorizedAccess";
        }
        else if (ex is ConnectionResetException)
        {
            StatusCode = 499;
            TipoError = "ConnectionReset";
        }
        else if (ex is ArgumentNullException)
        {
            StatusCode = 400;
            TipoError = "ArgumentNull";
        }
        else if (ex is ArgumentException)
        {
            StatusCode = 400;
            TipoError = "Argument";
        }
        else if (ex is InvalidOperationException)
        {
            StatusCode = 400;
            TipoError = "InvalidOperation";
        }
        else
        {
            StatusCode = 500;
            TipoError = "InternalError";
        }

        if (ex.Message.Contains('|'))
        {
            var cod = ex.Message.Split('|');
            this.Codigo = cod[0];
            this.Message = $"{this.Codigo}:{getmsgerror(this.Codigo)} ({cod[1]})";
        }
        else
            this.Message = $"{TipoError} {ex.Message}";

    }

    public override string ToString() => this.Message;

    private string getmsgerror(string code)
    {
        var rpta = "Codigo de error no encontrado.";
        if (errores.ContainsKey(code))
            rpta = errores[code];
        return rpta;
    }

    private static readonly Dictionary<string, string> errores = new()
    {
        {"LOGIN-LICENCIA-BADREQUEST" ,"Clavelic no suministrada." },
        {"LOGIN-LICENCIA-NOTFOUND"   ,"Codigo/serial licencia no encontrado."},
        {"LOGIN-EMPRESA-BADREQUEST"  ,"Credenciales no suministradas."},
        {"LOGIN-EMPRESA-NOTFOUND"    ,"Usuario no registrado."},
        {"LOGIN-EMPRESA-BADPWD"      ,"Password incorrecto."},
        {"LOGIN-SOPORTE-BADREQUEST"  ,"Credenciales no suministradas."},
        {"LOGIN-SOPORTE-NOTFOUND"    ,"Usuario no registrado."},
        {"LOGIN-SOPORTE-BADPWD"      ,"Password incorrecto."},
        {"LOGIN-INVITADO-NOTFOUND"   ,"Usuario no registrado."},
        {"LOGIN-APP-BADPWD"          ,"Password de aplicación incorrecta"},
        {"LOGIN-AUTH-BADREQUEST"     ,"Error en los datos enviados"},
        {"LOGIN-AUTH-NOTFOUND"       ,"Credenciales no suministradas"},

        {"LICENCIA-GET-NOTFOUND"     ,"Licencia/Serial no encontrado." },

        {"CLIENTE-INSERT-00"         ,"Codigo de Cliente Ya Existe" },
        {"CLIENTE-GET-00"            ,"Cliente no encontrado"},
        {"CLIENTE-UPDATE-00"         ,"Cliente No Encontrado"},
        {"CLIENTE-UPDATE-01"         ,"Error Al Actualizar"},
        {"CLIENTE-DELETE-00"         ,"Cliente No Encontrado"},
        {"CLIENTE-DELETE-01"         ,"Error Al Guardar Los Cambios"},

        {"AREA-INSERT-00"           ,"Codigo De Area Ya Existe"},
        {"AREA-GET-00"              ,"Area No Encontrada"},
        {"AREA-UPDATE-00"           ,"Area No Existe"},
        {"AREA-UPDATE-01"           ,"Error al guardar los cambios"},
        {"AREA-DELETE-00"           ,"Area No Encontrada"},
        {"AREA-DELETE-01"           ,"Error Al Guardar Los Cambios"},

        {"ARRIENDO-INSERT-00"       ,"Id de arriendo ya existe"},
        {"ARRIENDO-GET-00"          ,"Transaccion no encontrada"},
        {"ARRIENDO-UPDATE-00"       ,"Arriendo No Existe"},
        {"ARRIENDO-UPDATE-01"       ,"Error al actualizar"},
        {"ARRIENDO-DELETE-00"       ,"Arriendo No Encontrado"},
        {"ARRIENDO-DELETE-01"       ,"Error Al Guardar Los Cambios"},

        {"LICENCIAMIENTO-INSERT-00" ,"Id de licencia ya existe"},
        {"LICENCIAMIENTO-GET-00"    ,"Transaccion no encontrada"},
        {"LICENCIAMIENTO-UPDATE-00" ,"Licencia No Existe"},
        {"LICENCIAMIENTO-UPDATE-01" ,"Error al actualizar"},
        {"LICENCIAMIENTO-DELETE-00" ,"Licencia No Encontrada"},
        {"LICENCIAMIENTO-DELETE-01" ,"Error Al Guardar Los Cambios"},

        {"CONTRATO-INSERT-00"       ,"Id de contrato ya existe"},
        {"CONTRATO-GET-00"          ,"Transaccion no encontrada"},
        {"CONTRATO-UPDATE-00"       ,"Contrato No Existe"},
        {"CONTRATO-UPDATE-01"       ,"Error al actualizar"},
        {"CONTRATO-DELETE-00"       ,"Contrato No Encontrado"},
        {"CONTRATO-DELETE-01"       ,"Error Al Guardar Los Cambios"},



        {"CANALREF-INSERT-00"       ,"Codigo De canal referido Ya Existe"},
        {"CANALREF-GET-00"          ,"Canal Referido No Encontrada"},
        {"CANALREF-UPDATE-00"       ,"Canal Referido No Existe"},
        {"CANALREF-UPDATE-01"       ,"Error al guardar los cambios"},
        {"CANALREF-DELETE-00"       ,"Canal Referido No Encontrada"},
        {"CANALREF-DELETE-01"       ,"Error Al Guardar Los Cambios"},




        {"CLASE-INSERT-00"           ,"Codigo De clase Ya Existe"},
        {"CLASE-GET-00"              ,"Clase No Encontrada"},
        {"CLASE-UPDATE-00"           ,"Clase No Existe"},
        {"CLASE-UPDATE-01"           ,"Error al guardar los cambios"},
        {"CLASE-DELETE-00"           ,"Clase No Encontrada"},
        {"CLASE-DELETE-01"           ,"Error Al Guardar Los Cambios"},

        {"CIUDAD-INSERT-00"          ,"Codigo De ciudad Ya Existe"},
        {"CIUDAD-GET-00"             ,"Ciudad No Encontrada"},
        {"CIUDAD-UPDATE-00"          ,"Ciudad No Existe"},
        {"CIUDAD-UPDATE-01"          ,"Error al guardar los cambios"},
        {"CIUDAD-DELETE-00"          ,"Ciudad No Encontrada"},
        {"CIUDAD-DELETE-01"          ,"Error Al Guardar Los Cambios"},

        {"FUNCIONARIO-INSERT-00"    ,"Funcionario Ya Existe"},
        {"FUNCIONARIO-GET-00"       ,"Funcionario No Encontrado"},
        {"FUNCIONARIO-UPDATE-01"    ,"Error al guardar cambios"},
        {"FUNCIONARIO-DELETE-00"    ,"Funcionario No Encontrado"},
        {"FUNCIONARIO-DELETE-01"    ,"No Es Posible Eliminar El Registro"},

        {"ECR-GETAUTH-INVALID"      ,"Nit de la empresa invalido."},
        {"ECR-GETAUTH-DENIED"       ,"El comercio se encuentra inactivo o bloqueado."},
        {"ECR-GETAUTH-FAIL"         ,"Se presentó excepcion en ecollect el procesar la solicitud."},

        {"ECR-UPDOCS-00"            ,"No se encontro el identificador de la pasarela."},
        {"ECR-GETRECS-00"           ,"El EntityCode no esta relacionado a una empresa."},
        {"ECR-GETRECS-01"           ,"No se logro conectar correctamente con la base de datos."},
        {"ECR-GETRECS-02"           ,"EntityCode inconsistente."},
        {"ECR-GETRECS-03"           ,"Referencia 1 inconsistente."},
        {"ECR-GETRECS-04"           ,"Referencia 2 inconsistente."},
        {"ECR-GETRECS-05"           ,"No existen documentos pendientes de pago."},
        {"ECR-GETRECS-06"           ,"No se pudo hacer la busqueda de forma correcta."},
        {"ECR-GETRECS-07"           ,"Inconsistencia en la cantidad de referencias."},
        {"ECR-GETRECS-08"           ,"La cantidad de fechas limites de pago y tarifas de pago no coinciden."},
        {"ECR-GETRECS-09"           ,"No existen documentos pendientes de pago."},

        {"ECR-NOTIPAY-00"           ,"El EntityCode no esta relacionado a una empresa."},
        {"ECR-NOTIPAY-01"           ,"No se logro conectar correctamente con la base de datos."},
        {"ECR-NOTIPAY-02"           ,"No se encontraron los documentos requeridos o ya se encuentran pagados."},
        {"ECR-NOTIPAY-03"           ,"No se logro registrar la transacción correctamente."},
        {"ECR-NOTIPAY-04"           ,"No se modificaron correctamente los documentos."},
        {"ECR-NOTIPAY-05"           ,"No se ingresaron correctamente los documentos pagados."},

        {"CTRACLAV-NIT-NOTFOUND"    ,"Nit no existe"},
        {"CTRACLAV-EMAIL-EMPTY"     ,"Licencia sin email definido"},

        {"CERTDIG-GET-BADREQUEST"   ,"Nit/Serial incorrectos"},

        {"ESTADOOBJ-INSERT-00"      ,"Estado objetivo no insertado"},
        {"ESTADOOBJ-GET-00"         ,"Estado objetivo no encontrado"},
        {"ESTADOOBJ-UPDATE-00"      ,"Estado objetivo no actualizado"},
        {"ESTADOOBJ-DELETE-00"      ,"Estado objetivo no encontrado"},
        {"ESTADOOBJ-DELETE-01"      ,"Estado objetivo no eliminado"},

        {"INTERESADOS-GET-00"       , "Interesado no encontrado"},
        {"INTERESADOS-INSERT-00"    , "Interesado no insertado" },
        {"INTERESADOS-UPDATE-01"    , "Interesado no actualizado" },
        {"INTERESADOS-DELETE-00"    , "Interesado no eliminado" },
         {"INTERESADOS-DELETE-01"   , "Interesado no eliminado" },

        {"OBJETIVO-INSERT-00"       ,"Objetivo no insertado"},
        {"OBJETIVO-GET-00"          ,"Objetivo no encontrado"},
        {"OBJETIVO-UPDATE-00"       ,"Objetivo no actualizado"},
        {"OBJETIVO-DELETE-00"       ,"Objetivo no encontrado"},
        {"OBJETIVO-DELETE-01"       ,"Objetivo no eliminado"},

        {"VISTAOBJETIVOS-GET-00"    ,"Objetivos no encontrados"},

        {"SEGUIMIENTOOBJ-INSERT-00" ,"Seguimiento no insertado"},
        {"SEGUIMIENTOOBJ-GET-00"    ,"Seguimiento no encontrado"},
        {"SEGUIMIENTOOBJ-UPDATE-00" ,"Seguimiento no actualizado"},
        {"SEGUIMIENTOOBJ-DELETE-00" ,"Seguimiento no encontrado"},
        {"SEGUIMIENTOOBJ-DELETE-01" ,"Seguimiento no eliminado"},
        {"VISTASEGOBJ-GET-00"       ,"Seguimientos no encontrados"},

        {"TIPOOBJ-INSERT-00"        ,"Tipo objetivo no insertado"},
        {"TIPOOBJ-GET-00"           ,"Tipo objetivo no encontrado"},
        {"TIPOOBJ-UPDATE-00"        ,"Tipo objetivo no actualizado"},
        {"TIPOOBJ-DELETE-00"        ,"Tipo objetivo no encontrado"},
        {"TIPOOBJ-DELETE-01"        ,"Tipo objetivo no eliminado"},

        {"TIPCLI-INSERT-00"         ,"Tipo Cliente no insertado"},
        {"TIPCLI-GET-00"            ,"Tipo Cliente no encontrado"},
        {"TIPCLI-UPDATE-00"         ,"Tipo Cliente no actualizado"},
        {"TIPCLI-DELETE-00"         ,"Tipo Cliente no encontrado"},
        {"TIPCLI-DELETE-01"         ,"Tipo Cliente no eliminado"},
            
        // WHATSAPP
        {"WS-CREARLOG-00"           ,"No se pudo crear el log del mensaje enviado."},

        //AZFILE
        {"AZFILE-GETBYKEY-NOTFOUND" ,"Archivo no encontrado en la ruta especificada" },

        {"FEDOC-GET-NOTFOUND"      ,"No se encontro el registro del archivo en las bases de datos."},
        {"FEDOC-PUT-BADREQUEST"    ,"Informacion a almacenar No valida."},

        {"FEDOC-PUT-BLOBSERVICECONECTION","Error al validar la conexión hacia: ServiceBlob de FEDOC"},
        {"HUB-PUT-BLOBSERVICECONECTION"  ,"Error al validar la conexión hacia: ServiceBlob de TBONLINE"},
        {"HUB-DOWNLOAD-NOTFOUND"         ,"Archivo no encontrado en la ruta especificada" }
    };

}
