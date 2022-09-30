using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Common.Constants
{
    public class EnvironmentConstant: IEnvironmentConstant
    {
        private readonly IConfiguration _configuration;

        public EnvironmentConstant(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SA_KEYFILE
        {
            get
            {
                return Environment.GetEnvironmentVariable("SA_KEYFILE") ?? _configuration["Config:SA_KEYFILE"];
            }
        }
    }
}
