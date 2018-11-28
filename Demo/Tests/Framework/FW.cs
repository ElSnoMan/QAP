using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Tests.Framework
{
    public static class FW
    {
        /*
         * Uncomment on A and B Suites
         */

        public static string TESTS_BASE_PATH =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
       
        //public static string DRIVER_PATH => TESTS_BASE_PATH + "/drivers";

        //public static string RESULTS_PATH => TESTS_BASE_PATH + "/results";

        /*
         * Uncomment on D, E, F, and G Suites
         */

        public static string DRIVER_PATH => Directory.GetCurrentDirectory() + Config["driver:path"];

        public static string RESULTS_PATH => Directory.GetCurrentDirectory() + Config["test:results"];

        public static IConfiguration Config => _configuration ?? throw new Exception("Config is null. Initialize FW.");

        static IConfiguration _configuration;

        public static void Init()
        {
            if (_configuration == null)
            {
                Directory.SetCurrentDirectory(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "../../../../");

                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json")
                    .Build();
            }
        }
    }
}
