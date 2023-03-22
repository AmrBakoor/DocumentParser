using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DocumentParser.BL.AbstractProducts;
using DocumentParser.BL.ConcreteProducts;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IWordsCounter,WordsCounter>();
builder.Services.AddScoped<ISorter,Sorter>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

