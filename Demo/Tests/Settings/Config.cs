using System.IO;

namespace Tests.Settings
{
    public static class Config
    {
        public static string DRIVERPATH =
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())
                         .Parent.Parent.FullName, "drivers");
    }
}
