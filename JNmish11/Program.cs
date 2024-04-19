using JNmish11.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"]);
});

builder.Services.AddScoped<IBookRepository, EFBookRepository>();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagenumandtype", "{bookCat}/{pageNum}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("bookCat", "{bookCat}", new { Controller = "Home", action = "Index", pageNum = 1 });
app.MapControllerRoute("pagination", "{pageNum}", new {Controller = "Home", action = "Index", pageNum = 1});
app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
