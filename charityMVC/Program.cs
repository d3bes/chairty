using System.Security.Principal;
using charityMVC;
using charityMVC.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<Context>(op=>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();

builder.Services.AddMvc()
    .AddViewOptions(options =>
    {
        options.HtmlHelperOptions.ClientValidationEnabled = true;
    });


builder.Services.AddAuthorization(
    options =>
{
    options.AddPolicy("AdminOrClerk", policy =>
    {
        policy.RequireRole("admin", "clerk");
    });
});
builder.Services.AddSession(options =>
    {
        options.Cookie.Name = ".YourApp.Session";
        options.IdleTimeout = TimeSpan.FromMinutes(60); // Set your desired timeout
        options.Cookie.IsEssential = true;
    });

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IClerkRepo, ClerkRepo>();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<ISupportRepo, SupportRepo>();
builder.Services.AddScoped<IReportRepo, ReportRepo>();
builder.Services.AddScoped<IsmsRepo, smsRepo>();


// builder.Services.AddDataProtection()
//     .PersistKeysToFileSystem(new DirectoryInfo("/keys"));

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
app.UseSession();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
