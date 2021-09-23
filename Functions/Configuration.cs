using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Functions
{
    public class Configuration
    {
        private static IConfiguration _configuration;

        public Configuration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static byte[] GetAuthentication() => Encoding.ASCII.GetBytes(_configuration["Authentication:Token"]);
    }
}