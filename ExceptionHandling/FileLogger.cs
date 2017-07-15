using System;
using System.IO;

namespace ExceptionHandling
{
    public class FileLogger : ILogger
    {
        public string LogDirectoryPath { get; set; }
        public bool StackTrace { get; set; }

        protected string LogFilePath { get; set; }

        public FileLogger(string logDirectoryPath)
        {
            LogDirectoryPath = logDirectoryPath;
            StackTrace = true;
            Initialize();
        }

        private void Initialize()
        {
            Directory.CreateDirectory(LogDirectoryPath);
            LogFilePath = Path.Combine(LogDirectoryPath, $"{DateTime.Now:dd.MM.yyy}.log");
        }

        public virtual void Log(Exception e)
        {
            try
            {
                string info =
                    $"[{DateTime.Now:F}] \r\n [{e.TargetSite.DeclaringType}.{e.TargetSite.Name}] {e.Message} \r\n";
                if (StackTrace)
                    info = string.Concat(info, $"[StackTrace] \r\n [{e.StackTrace}] \r\n");

                Write(info);
            }
            catch
            {
                // ignored
            }
        }

        public void SetError(IErrorReporter errorReporter)
        {
            errorReporter.ErrorHappened = true;
        }

        private void Write(string info)
        {
            File.AppendAllText(LogFilePath, info);
        }
    }
}