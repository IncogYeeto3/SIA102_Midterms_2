using SIA102_Midterms_2.Models;
using SIA102_Midterms_2.Models.Mapping;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registeres DbContext
builder.Services.AddDbContext<pubsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PubsDb")));

//Registererseas Mapping Auto
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AuthorProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
