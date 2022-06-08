namespace Concecionaria.Middleware
{
    public class EjemploMiddleware
    {
        private readonly RequestDelegate _next;

        public EjemploMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}

