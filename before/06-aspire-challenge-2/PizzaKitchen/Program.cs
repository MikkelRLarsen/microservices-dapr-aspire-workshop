using PizzaKitchen.Models;
using PizzaKitchen.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers().AddDapr();
builder.Services.AddSingleton<ICookService, CookService>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{

}

//app.MapPost("/cook", async (Order order, ICookService cookService) =>
//{
//    app.Logger.LogInformation("Starting cooking for order: {OrderId}", order.OrderId);
//    var result = await cookService.CookPizzaAsync(order);
//    return Results.Ok(result);
//});

//app.MapGet("/health", () =>
//    Results.Ok("Healthy")
//);


app.MapControllers();
app.Run();