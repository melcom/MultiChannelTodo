using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.PlatformAbstractions;
using MultiChannelTodo.Front.Models;

namespace MultiChannelTodo.Front.Controllers
{
    public class HomeController : Controller
    {
        public IRuntimeEnvironment Runtime { get; set; }
        public IApplicationEnvironment Env { get; set; }
        public IOptions<ConfigurationOptions> ConfigurationOptions { get; set; }

        public HomeController(IRuntimeEnvironment runtime, IApplicationEnvironment env, IOptions<ConfigurationOptions> options)
        {
            Runtime = runtime;
            Env = env;
            ConfigurationOptions = options;
        }

        public IActionResult Index()
        {
            return View(new EnvModel { RuntimeEnvironment = Runtime, ApplicationEnvironment = Env, Options = ConfigurationOptions.Value });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
