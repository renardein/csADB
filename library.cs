namespace csADB
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Defines the <see cref="csadb" />.
    /// </summary>
    public class csadb
    {
        /// <summary>
        /// Defines the adbPath.
        /// </summary>
        public string adbPath;

        /// <summary>
        /// Defines the fbPath.
        /// </summary>
        public string fbPath;

        //cmd output
        /// <summary>
        /// Defines the LastStdout.
        /// </summary>
        public string LastStdout;

        /// <summary>
        /// Defines the LastStderr.
        /// </summary>
        public string LastStderr;

        /// <summary>
        /// Defines the <see cref="InvalidFileException" />.
        /// </summary>
        public class InvalidFileException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InvalidFileException"/> class.
            /// </summary>
            public InvalidFileException()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="InvalidFileException"/> class.
            /// </summary>
            /// <param name="message">The message<see cref="string"/>.</param>
            public InvalidFileException(string message)
                : base(message)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="InvalidFileException"/> class.
            /// </summary>
            /// <param name="message">The message<see cref="string"/>.</param>
            /// <param name="inner">The inner<see cref="Exception"/>.</param>
            public InvalidFileException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        /// <summary>
        /// The RunAdbCmd.
        /// </summary>
        /// <param name="args">The args<see cref="string"/>.</param>
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

        /// <summary>
        /// The RunFastbootCmd.
        /// </summary>
        /// <param name="args">The args<see cref="string"/>.</param>
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

        /// <summary>
        /// The GetPackage.
        /// </summary>
        public void GetPackage()
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
