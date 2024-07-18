using AspireDay.Domain.Hubs;
using AspireDay.ServiceDefaults;
using AspireDay.WebApi.Features.Store.CreateBuyOrder;
using AspireDay.WebApi.Features.Store.GetBuyOrders;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddSignalR()
    .AddNamedAzureSignalR("aspiredaysignalr");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAspire",
        policy  =>
        {
            policy.WithOrigins("http://localhost:5109");
            policy.AllowCredentials();
            policy.AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddCreateBuyOrderEndpoint();
app.AddGetBuyOrdersEndpoint();
app.MapHub<StoreHub>("/Store");
app.UseCors("AllowAspire");
app.Run();