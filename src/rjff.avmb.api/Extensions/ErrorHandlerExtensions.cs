namespace rjff.avmb.api.Extensions
{
    public static class ErrorHandlerExtensions
    {
        public static void ConfiguracaoExcecaoCustomizadaHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
