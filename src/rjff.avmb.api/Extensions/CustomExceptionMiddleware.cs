using Newtonsoft.Json;

using Serilog;

using System.Net;

namespace rjff.avmb.api.Extensions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionMiddleware> logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled exception handled by CustomExceptionMiddleware");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Lógica de tratamento para outras exceções
            // Você pode adicionar lógica aqui para lidar com diferentes tipos de exceções

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            ErrorDetails details = new ErrorDetails(500, $"Erro Log {exception.Message} - {exception.InnerException}", null);

            var jsonResponse = JsonConvert.SerializeObject(details);

            await context.Response.WriteAsync(jsonResponse);

            // Gravar a exceção em um arquivo usando Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Error(exception, "Erro inesperado"); // Esta linha gravará a exceção no arquivo de log
        }
    }
}
