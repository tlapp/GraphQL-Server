var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence();
builder.Services.AddGraphQL();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.AddGraphQLEndpoints();

app.Run();
