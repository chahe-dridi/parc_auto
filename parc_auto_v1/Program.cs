using Microsoft.EntityFrameworkCore;
using parc_auto_v1.Models;
using parc_auto_v1.Services;
<<<<<<< HEAD
 
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
=======
builder.Services.AddRazorPages(); // Add this line to include Razor Pages
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84

// Register the services
builder.Services.AddScoped<IVisiteTechniqueService, VisiteTechniqueService>();
builder.Services.AddScoped<IVoitureService, VoitureService>();
<<<<<<< HEAD
builder.Services.AddScoped<IVignetteService, VignetteService>(); // Register the Vignette service
=======
builder.Services.AddScoped<IVignetteService, VignetteService>();
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
builder.Services.AddScoped<IVidangeService, VidangeService>();
builder.Services.AddScoped<ISinistreService, SinistreService>();
builder.Services.AddScoped<IAssuranceService, AssuranceService>();
builder.Services.AddScoped<IDemandesService, DemandesService>();
<<<<<<< HEAD




builder.Services.AddScoped<IMarqueService, MarqueService>();
builder.Services.AddScoped<IModeleService, ModeleService>();

 


=======
builder.Services.AddScoped<IMarqueService, MarqueService>();
builder.Services.AddScoped<IModeleService, ModeleService>();

>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
// Configure the DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

<<<<<<< HEAD
=======
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

<<<<<<< HEAD
=======
app.UseAuthentication();
>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

<<<<<<< HEAD
=======
app.MapRazorPages(); // Add this line to map Razor Pages

>>>>>>> d97746bf60d8483445cdc403eb6f751c9e5b4b84
app.Run();
