using entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Services;
using System.Threading.Tasks;
namespace MyFirstWebApiProject.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        IRatingServices ratingServices;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingServices ratingService)
        {
            Rating rating = new Rating();
            rating.Host = httpContext.Request.Host.ToString();
            rating.Method = httpContext.Request.Method.ToString();
            rating.Path = httpContext.Request.Path.ToString();
            rating.Referer = httpContext.Request.Headers["Referer"].ToString();
            rating.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();
            rating.RecordDate = DateTime.Now;
            await ratingService.addRating(rating);

            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
