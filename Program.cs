using LAB11.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ActionFilter>();
builder.Services.AddScoped<UserCounterFilter>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ActionFilter());
    options.Filters.Add(new UserCounterFilter());
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Filter}/{action=Index}/{id?}");

app.Run();