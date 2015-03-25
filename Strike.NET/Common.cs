#region

using System.Reflection;

#endregion

namespace StrikeNET
{
    public class Common
    {
        private static string _assemblyVersion;

        public static string GetUserAgent()
        {
            if (_assemblyVersion == null)
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                // trim version string
                while (version.EndsWith("0") || version.EndsWith("."))
                {
                    version = version.Remove(version.Length - 1, 1);
                }

                if (!version.Contains("."))
                    version = string.Format("{0}.0", version);

                _assemblyVersion = version;
            }

            return string.Format("Strike.NET {0}", _assemblyVersion);
        }
    }
}