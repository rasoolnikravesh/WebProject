using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Infrastructure;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class MyAuthorization
{
    private readonly RequestDelegate _next;

    public MyAuthorization(RequestDelegate next, IUnitOfWork unitOfWork)
    {
        _next = next;
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }

    public Task Invoke(HttpContext httpContext)
    {
        
        return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MyAuthoriztionExtensions
{
    public static IApplicationBuilder UseMyAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyAuthorization>();
    }
}
