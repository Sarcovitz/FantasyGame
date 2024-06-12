using FantasyGame.Exceptions;
using System.Net;

namespace FantasyGame.Models.Middlewares;

/// <summary>
///     Middleware responsible for handling uncatched exceptions and wrapping them to valid HTTP response.
/// </summary>
public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try 
        { 
            await next(context); 
        }
        catch (BadRequestStatusException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (ConflictStatusException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (DbCreateException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (InternalServerErrorStatusException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(ex.Message);
        }
        // GENERAL EXCEPTION
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(ex.Message);
        }
    }
}