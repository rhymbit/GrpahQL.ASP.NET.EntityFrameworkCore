using EntityGraphQL.AspNet.Extensions;
using EntityGraphQL.Schema;
using EntityGraphQL.ServiceCollectionExtensions;
using GraphQLDatabase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var schema = SchemaBuilder.FromObject<DemoContext>();

// Add services to the container.

builder.Services.AddDbContext<DemoContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnectionString"]);
});

builder.Services.AddGraphQLSchema<DemoContext>();

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL<DemoContext>();

app.Run();
