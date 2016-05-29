using Microsoft.Extensions.PlatformAbstractions;

namespace MultiChannelTodo.Front.Models
{
    public class EnvModel
    {
        public IRuntimeEnvironment RuntimeEnvironment { get; set; }
        public IApplicationEnvironment ApplicationEnvironment { get; set; }
        public ConfigurationOptions Options { get; set; }
    }
}