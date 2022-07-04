using Microsoft.EntityFrameworkCore;
using Seda.MVC.UI.Interfaces;
using Seda.MVC.UI.Services;
using Seda.TaskDistrubuter.Dal.Entities;
using Seda.TaskDistrubuter.Dal.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IRepository<Assignment>, Repository<Assignment>>();
builder.Services.AddDbContext<SqliteDBContext>(x => x.UseSqlite("Seda.Distributer.DB"));




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Assignment}/{action=Index}/{id?}");

app.Run();
