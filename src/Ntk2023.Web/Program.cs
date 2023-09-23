using Api;
using System.Net;

ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IApiClient>(services => new ApiClient(builder.Configuration["ApiUrl"], new HttpClient()));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
