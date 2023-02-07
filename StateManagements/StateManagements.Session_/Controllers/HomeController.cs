using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StateManagements.Session_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";
        private StateManagementsContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, StateManagementsContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult SessionTest()
        {
            DateTime dt = DateTime.UtcNow;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Keys.SESSION_KEY_NAME)))
            {
                HttpContext.Session.SetInt32(Keys.SESSION_KEY_AGE, 73);
                HttpContext.Session.SetString(Keys.SESSION_KEY_NAME, "The Doctor");
                HttpContext.Session.SetString(Keys.SESSION_KEY_DATE, dt.ToString());
            }

            var name = HttpContext.Session.GetString(Keys.SESSION_KEY_NAME);
            var age = HttpContext.Session.GetInt32(Keys.SESSION_KEY_AGE).ToString();
            var date = HttpContext.Session.GetString(Keys.SESSION_KEY_DATE);

            return Json(data: new
            {
                Name = name,
                Age = age,
                CacheDate = date,
                Date = dt
            });
        }
         
        public async Task<IActionResult> Index()
        {
            ViewBag.Prs = _context.Products.ToList();
            return View();
        }
    }
}

public static class Keys
{
    public const string SESSION_KEY_NAME = "_name";
    public const string SESSION_KEY_AGE = "_age";
    public const string SESSION_KEY_DATE = "_date";
}