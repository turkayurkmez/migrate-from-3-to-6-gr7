var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Configuration.AddIniFile("appsettings.ini");

builder.Logging.AddJsonConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.Logger.LogInformation($"Ortam adı:{builder.Environment.EnvironmentName}");
app.Logger.LogInformation($"Uygulama adı:{builder.Environment.ApplicationName}");
app.Logger.LogInformation($"İçerik Kök Dizini:{builder.Environment.ContentRootPath}");
app.Logger.LogInformation($"Web kök klasörünün dizini:{builder.Environment.WebRootPath}");

var value = app.Configuration.GetValue<string>("Message");

app.Logger.LogWarning($"Gelen değer: {value}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/test", () => "Burası test sayfası");


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
