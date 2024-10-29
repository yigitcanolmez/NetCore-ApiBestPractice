using Microsoft.AspNetCore.Mvc;
using Repositories.Extension;
using Services.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<FluentValidationFilter>();
    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories(builder.Configuration)
    .AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MigrateDatabase();

app.UseAuthorization();

app.MapControllers();

app.Run();