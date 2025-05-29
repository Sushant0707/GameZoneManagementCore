using GameZoneManagement.Models;
using GameZoneManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZoneManagement.Controllers
{
    public class GameZoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IUserService _userService;

        public GameZoneController(IUserService userService)
        {
            _userService = userService;     
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(TblGameZone Register)
        
        {
            await _userService.Register(Register);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.Login(email, password);
            if (user == null)
            {
                ViewBag.Message = "Invalid credentials";
                return View();
            }

            HttpContext.Session.SetString("Role", user.UserType);

            return user.UserType == "Admin" ? RedirectToAction("AdminDashboard") : RedirectToAction("PlayerDashboard");
        }

        public IActionResult AdminDashboard() 
        {
            var types = _userService.GetGameModes()
                .Select(x => new SelectListItem
                {
                    Value = x.ModeId.ToString(),
                    Text = x.GamingMode
                }).ToList();

        var model = new TblGameMode
        {
            GetModesList = types
        };

            return View(model);
    }
    public IActionResult PlayerDashboard() => View();


        [HttpPost]
        public async Task<IActionResult> AddMode(string modeName)
        {
            if (string.IsNullOrWhiteSpace(modeName))
            {
                ModelState.AddModelError("", "Mode name is required.");
                return View("AdminDashboard"); // or return RedirectToAction if needed
            }

            bool isAdded = await _userService.AddModeAsync(modeName);
            if (isAdded)
            {
                TempData["Success"] = "Mode added successfully!";
            }
            else
            {
                TempData["Error"] = "Mode already exists or failed to add.";
            }

            return RedirectToAction("AdminDashboard");
        }

    }
}
