namespace Web.Middleware;

public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(
            ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }


    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Hola, yendo para rutear");
        await next(context);
        Console.WriteLine("Hola, volviendo para responder");
    }
    }
