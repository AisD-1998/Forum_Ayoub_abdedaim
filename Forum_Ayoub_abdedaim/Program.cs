using DAO;
using Microsoft.EntityFrameworkCore;
using Services.AuthService;
using Services.postsService;
using Services.PostsService;
using Services.UserService;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<ForumDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Dependency Injection for services
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IPost, postsService>();

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
// Set default route to AuthController's SignIn method
app.MapGet("/", (context) =>
{
    context.Response.Redirect("/api/Auth/signin");
    return Task.CompletedTask;
});
app.Run();
