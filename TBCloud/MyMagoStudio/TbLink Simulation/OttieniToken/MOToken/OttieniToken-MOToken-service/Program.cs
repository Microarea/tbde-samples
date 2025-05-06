using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microarea.Tbf.Model.MyMagoStudioBase;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;

var builder =  MyMagoStudioNetcoreExtensions.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddControllers();
#if DEBUG
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("OttieniTokenMOTokenDocOttieniToken", new OpenApiInfo { Description = "OttieniTokenMOTokenDocOttieniToken", Title = "OttieniTokenMOTokenDocOttieniToken Business Logic API V1", Version = "v1" });
    c.SwaggerDoc("Test", new OpenApiInfo { Description = "Test", Title = "Test Business Logic API V1", Version = "v1" });
    //add one or more documents to be created by Swagger generator
});
#endif
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();
#if DEBUG
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/OttieniTokenMOTokenDocOttieniToken/swagger.json", "OttieniTokenMOTokenDocOttieniToken Business Logic  API V1");
        c.SwaggerEndpoint("/swagger/Test/swagger.json", "Test Business Logic  API V1");
        //add one or more Swagger Json endpoints
    });
}
#endif
app.Run();
public partial class Program { };