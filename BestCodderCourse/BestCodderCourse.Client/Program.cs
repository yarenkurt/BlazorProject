using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BestCodderCourse.Client;
using BestCodderCourse.Client.Service.Contracts;
using BestCodderCourse.Client.Service.Implements;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseOrderInfoService, CourseOrderInfoService>();

await builder.Build().RunAsync();