using Data.Settings;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection");


builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("admin", x => x.RequireRole("admin"));
});

// add auto mapper
//builder.Services.AddAutoMapper(typeof(Mappers.AddPostMapperProfile));

//builder.Services.AddAutoMapper(op =>
//{
//    op.AddProfile<Mappers.AddPostMapperProfile>(op.GetService<Data.UnitofWork>());

//});



builder.Services.AddConfigContext(connectionString);

builder.Services.AddTransient<Data.IUnitOfWork,Data.UnitofWork>(provider =>
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

builder.Services.AddTransient(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Mappers.AddPostMapperProfile(provider.GetRequiredService<Data.IUnitOfWork>()));

}).CreateMapper());

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
