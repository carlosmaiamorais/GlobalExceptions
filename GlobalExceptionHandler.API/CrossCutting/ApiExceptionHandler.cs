using System.Net;
using GlobalExceptionHandler.API.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHandler.API.CrossCutting;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        //inserir um log
        //disparar um evento no CQRS pra fazer algo // gravar o erro em uma fila de email

        if (exception is DomainException)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; //400
            await httpContext.Response.WriteAsJsonAsync(new {success = false , data =exception.Message });
        }
        else if (exception is NotFoundException)
        {   
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound; //404
            await httpContext.Response.WriteAsJsonAsync(new {success = false , data =exception.Message });
        }
        else
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500
            await httpContext.Response.WriteAsJsonAsync(new {success = false , data = "Ops, ocorreu um erro."}); 
        }

        

        return true;
    }
}