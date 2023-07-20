
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
namespace Sample
{
    class Program
    {
        const string programUsage = "usage: ExamenCandidato <update files directory> <installation directory>";
        const string invalidDirectoriesMsg = "both \"{0}\" and \"{1}\" directories must exist.";

        static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            if (args.Length != 2) {
                Log.Error(programUsage);
                return;
            }

            string updateFilesDirecotry = args[0];
            string installationDirectory = args[1];

            if (!Directory.Exists(updateFilesDirecotry) || !Directory.Exists(installationDirectory))
            {
                Log.Error(string.Format(invalidDirectoriesMsg, updateFilesDirecotry, installationDirectory));
                return;
            }

            MonitorUpdaterManagerSample.UpdateMonitor(updateFilesDirecotry, installationDirectory);
        }
    }
}
