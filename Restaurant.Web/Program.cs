using Microsoft.AspNetCore.Authentication;
using Restaurant.Web;
using Restaurant.Web.Services;
using Restaurant.Web.Services.IServices;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICartService, CartService>();

ConfigConstants.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
ConfigConstants.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
               .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
               .AddOpenIdConnect("oidc", options =>
               {
                   options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];
                   options.GetClaimsFromUserInfoEndpoint = true;
                   options.ClientId = "restaurant";
                   options.ClientSecret = "secret";
                   options.ResponseType = "code";
                   options.ClaimActions.MapJsonKey("role", "role", "role");
                   options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                   options.TokenValidationParameters.NameClaimType = "name";
                   options.TokenValidationParameters.RoleClaimType = "role";
                   options.Scope.Add("restaurant");
                   options.SaveTokens = true;

               });

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
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
