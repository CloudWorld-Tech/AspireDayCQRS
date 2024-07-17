using AspireDay.ServiceDefaults;
using AspireDay.WebApi.Features.Store.CreateBuyOrder;
using AspireDay.WebApi.Features.Store.GetBuyOrders;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();