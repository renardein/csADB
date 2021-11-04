using System;
using System.Diagnostics;

namespace csADB
{

    public class Class1
    {
        public string adbPath;
        public string fbPath;
        //cmd output
        public string LastStdout;
        public string LastStderr;
        public class InvalidFileException : Exception
        {
            public InvalidFileException()
            {
            }

            public InvalidFileException(string message)
                : base(message)
            {
            }

            public InvalidFileException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
        public void RunAdbCmd(string args)
        {
            if (adbPath == "")
            {
                throw new InvalidFileException("ADB path is invalid.");
            }
            else
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = adbPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                var process = Process.Start(processStartInfo);
                LastStdout = process.StandardOutput.ReadToEnd();
                LastStderr = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }

        public void RunFastbootCmd(string args)
        {
            if (fbPath == "")
            {
                throw new InvalidFileException("Fastboot path is invalid.");
            }
            else
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = fbPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                var process = Process.Start(processStartInfo);
                LastStdout = process.StandardOutput.ReadToEnd();
                LastStderr = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }


        public void Install(string apkPath, string pid)
        {
            RunAdbCmd("uninstall " + pid);
            RunAdbCmd("install \"" + apkPath + "\"");
        }


        public void DownloadFile(string localPath, string destPath)
        {
            RunAdbCmd("pull " + localPath + " " + destPath);
        }

        public void DownloadADB()
        {
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile("https://dl.google.com/android/repository/platform-tools-latest-windows.zip", "plat.zip");
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read("plat.zip"))
                {
                    zip.ExtractAll(System.IO.Path.GetTempPath() + "\\unzipPlat",
                    Ionic.Zip.ExtractExistingFileAction.DoNotOverwrite);
                }
            }
        }
    }
}
