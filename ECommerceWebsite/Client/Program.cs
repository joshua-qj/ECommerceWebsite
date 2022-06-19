using Blazored.LocalStorage;
using Blazored.Toast;
using ECommerceWebsite.Client;
using ECommerceWebsite.Client.Services.CartService;
using ECommerceWebsite.Client.Services.CategoryService;
using ECommerceWebsite.Client.Services.ProductService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService,CartService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast(); //next import.razor,next maylayoutrazor
//Add the <BlazoredToasts /> tag into your applications MainLayout.razor.
// 3. Register and Configure Toasts Component 4. Add reference to style sheet(s) wwwroot/index
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


await builder.Build().RunAsync();
