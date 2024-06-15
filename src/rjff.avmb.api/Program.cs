using rjff.avmb.api.Extensions;
using rjff.avmb.infrastructure;
using rjff.avmb.application;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddSwaggerConfig()
    .Services
        .AddInfrastructureModule(builder.Configuration)
        .AddApplicationModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}
else
{
    app.UseCors("Production");
}


app.ConfigureCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
