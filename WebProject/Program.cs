using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection"); ;

//builder.Services.AddDbContext<Data.DatabaseContext>(options => options.UseSqlServer(connectionString: connectionString));


builder.Services.AddTransient<Data.IUnitOfWork, Data.IUnitOfWork>(sp =>
{
    Data.Tools.Options options =
                    new Data.Tools.Options
                    {
                        Provider = Data.Tools.Enums.Provider.SqlServer,
                        ConnectionString = connectionString
                    };
    return new Data.UnitofWork(options: options);
});
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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
