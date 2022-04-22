using Data.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection"); ;

builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("admin", x => x.RequireRole("admin"));
});

// add auto mapper
builder.Services.AddAutoMapper(typeof(Mappers.AddPostMapperProfile));

builder.Services.AddAutoMapper(am =>
{
    am.AddProfile<Mappers.AddPostMapperProfile>();
    
});

builder.Services.AddConfigContext(connectionString);

builder.Services.AddTransient<Data.IUnitOfWork, Data.IUnitOfWork>(sp =>
{
    Data.Tools.Options options = new()
    {
        Provider = Data.Tools.Enums.Provider.SqlServer,
        ConnectionString = connectionString
    };

    return new Data.UnitofWork(options: options);
});

builder.Services.AddConfigIdentity();


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
