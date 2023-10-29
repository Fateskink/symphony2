using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace symphony2.Middleware;

public class UnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public UnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (
            context.User != null
            && context.User.Identity != null
            && context.User.Identity.IsAuthenticated
        )
        {
            await _next(context);
        }
        else
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(
                "Unauthorized: You must be logged in to access this resource."
            );
        }
    }
}
