using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiChannelTodo.Core.Api
{
    public class ConfigurationOptions
    {
        public string MongoConnection { get; set; }

        public string Database { get; set; }
    }
}
