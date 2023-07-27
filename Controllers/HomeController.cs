using DND_Character_Sheet_Webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DND_Character_Sheet_Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Setup()
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb";
            string currentDirectory = Directory.GetCurrentDirectory();
            string scriptPath = "DBSetup.sql";
            scriptPath = Path.Combine(currentDirectory, scriptPath);
            string script = System.IO.File.ReadAllText(scriptPath);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(script, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=5eDB";
            scriptPath = "Setup.sql";
            scriptPath = Path.Combine(currentDirectory, scriptPath);
            script = System.IO.File.ReadAllText(scriptPath);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(script, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}