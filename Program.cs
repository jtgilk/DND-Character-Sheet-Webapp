using DND_Character_Sheet_Webapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

protected void registerBtnSubmit_Click(object sender, EventArgs e)
{
    // Retrieve user input from the text box
    string EmailInput = txtEmail.Text;

    // Call your validation method with the user input
    bool isValid = ValidateUserInput(username);

    // Process the validation result (e.g., display a message)
    if (isValid)
    {
        // User input is valid, proceed with further actions
    }
    else
    {
        // User input is not valid, show an error message or take appropriate action
    }
}
static void EmailCheck(string EmailInput)
{
    string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    string userEmailInput = EmailInput; // Replace this with the input email address

    if (Regex.IsMatch(userEmailInput, emailPattern))
    {
        string validEmail = userEmailInput;
    }
    else
    {

    }
}

