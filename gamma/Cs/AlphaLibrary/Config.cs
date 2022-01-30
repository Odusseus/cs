using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaLibrary
{
    public class Config
    {
        readonly IConfigurationRoot config;

        public Config() 
        {
            // TODO fix
            var builder = new ConfigurationBuilder();
             
            this.config = builder.Build();
        
        }

        public string GetValue(string name)
        {
            return this.config[name];
        }

    }
}
