using Play.Catalog.Api.Installers;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

const string AllowedOriginSettings = "AllowedOrigin";

builder.Services.InstallServicesFromAssemblyContaining<Program>(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(corsBuilder => {
        corsBuilder.WithOrigins(builder.Configuration[AllowedOriginSettings] ?? "AllowedOriginSettings")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




