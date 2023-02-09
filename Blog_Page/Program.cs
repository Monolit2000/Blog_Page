using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Blog_Page.Models;
var builder = WebApplication.CreateBuilder(args);
const string cookieString = "Cookies";
// Add services to the container.
builder.Services.AddControllersWithViews();


//string DbconnectionBlogPage = builder.Configuration.GetConnectionString("DefoltConnection");

builder.Services.AddDbContext<BlogPageContext>(options => 
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthentication(cookieString)
   .AddCookie(cookieString, options =>
   {
       options.LoginPath = "/";
       options.AccessDeniedPath = "/";
       //options.ExpireTimeSpan = TimeSpan.FromSeconds(5);
   })
   .AddCookie("", options =>
   {
       options.LoginPath = "/";
       options.AccessDeniedPath = "/";
       options.Cookie.Name = "Anonim";
   });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser()
       .AddAuthenticationSchemes()
       .RequireClaim("role", "User");
    });
    opts.AddPolicy("Anonimus", policy =>
    {
        policy.RequireAuthenticatedUser()
       .AddAuthenticationSchemes()
       .RequireClaim("Anonimrole", "AnonimUser");
    });
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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
