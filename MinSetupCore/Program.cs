using MinSetupCore.Data;
using Omu.AwesomeMvc;

var builder = WebApplication.CreateBuilder(args);

var provider = new AweMetaProvider();

// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews(o => o.ModelMetadataDetailsProviders.Add(provider));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

new DbSeeder().Seed();

app.Run();