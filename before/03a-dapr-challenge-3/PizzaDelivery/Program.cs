using PizzaDelivery.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IDeliveryService, DeliveryService>();
builder.Services.AddControllers().AddDapr();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}


app.UseCloudEvents();
app.MapControllers();
app.Run();

