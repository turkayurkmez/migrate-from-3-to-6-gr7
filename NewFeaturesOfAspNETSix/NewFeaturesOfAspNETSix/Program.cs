using Autofac;
using Autofac.Extensions.DependencyInjection;
using NewFeaturesOfAspNETSix.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Configuration.AddIniFile("appsettings.ini");
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(3);
});


//IHostBuilder konfigürasyonu:
builder.Host.ConfigureHostOptions(option => option.ShutdownTimeout = TimeSpan.FromSeconds(45));

//WebHostBuilder üzerinde değişiklik yapmak:
//builder.WebHost.UseHttpSys();

//özel dependency injection sağayıcısı kullanmak:
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Logging.AddJsonConsole();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.Logger.LogInformation($"Ortam adı:{builder.Environment.EnvironmentName}");
app.Logger.LogInformation($"Uygulama adı:{builder.Environment.ApplicationName}");
app.Logger.LogInformation($"İçerik Kök Dizini:{builder.Environment.ContentRootPath}");
app.Logger.LogInformation($"Web kök klasörünün dizini:{builder.Environment.WebRootPath}");

var value = app.Configuration.GetValue<string>("Message");

app.Logger.LogWarning($"Gelen değer: {value}");

IProductService productService = app.Services.GetRequiredService<IProductService>();

app.Lifetime.ApplicationStarted.Register(() =>
{
    app.Logger.LogInformation($"{app.Environment.ApplicationName} uygulaması, {productService} enjekte etti");
});

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.MapGet("/test", () => "Burası test sayfası");


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
