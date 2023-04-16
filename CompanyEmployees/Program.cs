using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddControllers();

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.Use(async (context, next) => { 
    await context.Response.WriteAsync("(First) Hello from the middleware component. \t"); 
    await next.Invoke(); 
    Console.WriteLine($"Logic after executing the next delegate in the Use method");
    await next.Invoke();
    Test.Text("Stephen Nnamani", 32);
}); 
//app.Run(async context => { 
//    Console.WriteLine($"Writing the response to the client in the Run method"); 
//    //context.Response.StatusCode = 200; 
//    await context.Response.WriteAsync("Hello from the middleware component."); });
app.Map("/roboticSence", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Map.Use");
        await next.Invoke();
        Console.WriteLine("Map.Use after next delegate");
    });
    builder.Run(async context =>
    {
        Console.WriteLine($"Map branch response to the client in the Run method");
        await context.Response.WriteAsync("This is from the Robotic sence\t");
        await context.Response.WriteAsync("Hello from the builder.Run map branch.\t");
    });
});

app.Run(async context => { Console.WriteLine($"Writing the response to the client in the Run method"); 
    await context.Response.WriteAsync("(last)Hello from the App.Run component. "); 
});

app.MapControllers();

app.Run();
