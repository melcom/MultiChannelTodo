using Microsoft.Extensions.PlatformAbstractions;

namespace MultiChannelTodo.Core.Front.Models
{
    public class EnvModel
    {
        public PlatformServices DefaultPlatformServices { get; set; }

        public string FrameworkDescription { get; set; }
        public string OsArchitecture { get; set; }
        public string OsDescription { get; set; }
        public string ProcessArchitecture { get; set; }

        public ConfigurationOptions Options { get; set; }
    }
}