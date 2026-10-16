using Microsoft.AspNetCore.Mvc;
using SRMSS.Data;
using System.Linq;

namespace SRMSS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Open Login Page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Login Button
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);

            // WRONG USERNAME OR PASSWORD
            if (user == null)
            {
                ViewBag.LoginError = true;

                ViewBag.ErrorMessage =
                    "Sorry, incorrect username or password. Please try again.";

                ViewBag.UsernameError = true;
                ViewBag.PasswordError = true;

                return View("Index");
            }

            // SAVE LOGIN INFORMATION
            HttpContext.Session.SetString(
                "UserID",
                user.UserID.ToString());

            HttpContext.Session.SetString(
                "Username",
                user.Username);

            HttpContext.Session.SetString(
                "FullName",
                user.FullName ?? user.Username);

            HttpContext.Session.SetString(
                "Role",
                user.Role);

            // SUCCESS POPUP
            ViewBag.LoginSuccess = true;

            ViewBag.SuccessMessage =
                "Welcome, " + (user.FullName ?? user.Username) + "!";

            return View("Index");
        }

        // Called after clicking OK on successful login
        [HttpGet]
        public IActionResult ContinueToDashboard()
        {
            var userID = HttpContext.Session.GetString("UserID");

            if (string.IsNullOrEmpty(userID))
            {
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}