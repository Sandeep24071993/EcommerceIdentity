
using Microsoft.EntityFrameworkCore;
using RazorEcommerceIdentityProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


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


/* 
   
  # -> Create by asp.net core razor pages project Mostaly same as  asp.net core mvc
  
  # Step 1 -> create new project asp.net CoreRazorPage in same solution EX. or other.
  # Step 2 -> For Run project (set as startup projecct)
  # Step 3 -> Install all package MEFC,MEFC.SqlServer,MEFC.Tools and (right click projeect Edit project file for copy one project to another)
  # Step 4 -> Add Model class and DbContext Class in project folder (create Models and Data folder)
  # Step 5 -> Create connection string in appsetting.json (Database name check) and genrate in Program.cs below (builder.services.AddRazorPages();)
  # Step 6 -> Then after that chek this project and execute add-Migration and update-database but check project 
  # Step 7 -> But in this project controller is not avalable so work with razor pages
  # Step 8 -> Add Categories folder in Pages folder for Razor view and functionalities (but folder and model class not same)
 
 */
