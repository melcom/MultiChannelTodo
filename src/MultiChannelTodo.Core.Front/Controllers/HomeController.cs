using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using MultiChannelTodo.Core.Front.Models;

namespace MultiChannelTodo.Core.Front.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<ConfigurationOptions> options)
        {
            ConfigurationOptions = options;
        }

        public IOptions<ConfigurationOptions> ConfigurationOptions { get; set; }

        public IActionResult Index()
        {
            return
                View(new EnvModel
                {
                    DefaultPlatformServices = PlatformServices.Default,
                    FrameworkDescription = RuntimeInformation.FrameworkDescription,
                    OsArchitecture = RuntimeInformation.OSArchitecture.ToString(),
                    OsDescription = RuntimeInformation.OSDescription,
                    ProcessArchitecture = RuntimeInformation.ProcessArchitecture.ToString(),
                    Options = ConfigurationOptions.Value
                });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}