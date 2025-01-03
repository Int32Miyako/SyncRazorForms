using Microsoft.EntityFrameworkCore;
using SyncRazorForms.Controllers.Ado;
using SyncRazorForms.Controllers.EntityFramework.Api;
using SyncRazorForms.Controllers.EntityFramework.View;
using SyncRazorForms.Data.Ado;
using SyncRazorForms.Data.EF;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EfDataContext>();
builder.Services.AddScoped<AdoProductController>();
builder.Services.AddScoped<EfProductApiController>();
builder.Services.AddScoped<EfProductViewController>();
builder.Services.AddScoped<IAdoDataContext, AdoConnectedAdoDataContext>();


builder.Services.AddDbContext<EfDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("RenderDB"))
        .LogTo(Console.WriteLine);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();