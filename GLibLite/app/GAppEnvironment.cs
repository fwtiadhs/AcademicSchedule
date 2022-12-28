using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;


namespace GLib.app
{

    public class GAppEnvironment
    {
        public static string ISODateFormat = "yyyy-MM-dd HH:mm:ss";
        public static Assembly MainExecutable;

        //------------------------------------------------------------------------------
        public static FileVersionInfo AppVersion
        {
            get
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(MainExecutable.Location);
                return fvi;
            }
        }

        //------------------------------------------------------------------------------
        public static string GetExe()
        {
            // Get the application path needed to obtain
            // the application configuration file.
            string sApplicationName = Environment.GetCommandLineArgs()[0];
            return System.IO.Path.Combine(GAppEnvironment.GetExePath(), sApplicationName);
        }
        //------------------------------------------------------------------------------
        public static string GetImagesPath()
        {
            return Path.Combine(GetExePath(), "images");
        }
        //------------------------------------------------------------------------------
        public static string GetConfig()
        {
            // Get the application path needed to obtain
            // the application configuration file.
            string sConfigName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]) + ".cfg";
            return System.IO.Path.Combine(GAppEnvironment.GetExePath(), sConfigName);
        }
        //------------------------------------------------------------------------------

        public static string GetExePathParent()
        {
            return Directory.GetParent(GetExePath()).FullName;
        }
        //------------------------------------------------------------------------------
        public static string GetExePath()
        {
            return Environment.CurrentDirectory;
        }
        //------------------------------------------------------------------------------
        public static string GetDataPath()
        {
            return Path.Combine(GAppEnvironment.GetExePathParent(), "Datastore");
        }
        //------------------------------------------------------------------------------
        //Returns a title that displays the version. 
        //   p_sTemplate should have two placeholders {0} and {1}
        public static string GetApplicationTitle(string p_sTemplate)
        {
            string sResult = String.Format(p_sTemplate, AppVersion.FileMajorPart, AppVersion.FileMinorPart);

            if (GAppEnvironment.AppVersion.FilePrivatePart == 99)
                sResult += " **BETA**";
            else if (GAppEnvironment.AppVersion.FileMajorPart < 1)
            {
                if (GAppEnvironment.AppVersion.FileMinorPart < 9)
                    sResult += " **ALPHA**";
            }

            return sResult;
        }
        //------------------------------------------------------------------------------
    }
}
