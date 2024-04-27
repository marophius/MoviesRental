using MoviesRental.Consumer.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConsumerConfig(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();
