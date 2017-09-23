using System;
using System.IO;
using System.Text;

namespace ExceptionHandling
{
    public class FileLogger : ILogger
    {
        #region Constructor

        public FileLogger(string logDirectoryPath)
        {
            LogDirectoryPath = logDirectoryPath;
            StackTrace = true;
            Initialize();
        }

        #endregion

        #region ILogger implementation

        public virtual void Log(Exception e)
        {
            try
            {
                StringBuilder s = new StringBuilder();

                s.Append(
                    $"[{DateTime.Now:F}]\r\n[{e.TargetSite.DeclaringType}.{e.TargetSite.Name}]\r\n");

                s.Append($"[Message]\r\n{e.Message} \r\n");

                if (StackTrace)
                    s.Append($"[StackTrace] \r\n [{e.StackTrace}] \r\n");

                s.Append("\r\n");
                Write(s.ToString());
            }
            catch
            {
                // ignored
            }
        }

        public void Log(string text)
        {
            Write(text);
        }

        #endregion

        #region IErrorHandler implementation

        public void SetError(IErrorReporter errorReporter)
        {
            errorReporter.ErrorHappened = true;
        }

        #endregion

        #region Properties

        public string LogDirectoryPath { get; set; }
        public bool StackTrace { get; set; }

        protected string LogFilePath { get; set; }

        #endregion

        #region Private methods

        private void Initialize()
        {
            Directory.CreateDirectory(LogDirectoryPath);
            LogFilePath = Path.Combine(LogDirectoryPath, $"{DateTime.Now:dd.MM.yyy}.log");
        }

        private void Write(string info)
        {
            File.AppendAllText(LogFilePath, info);
        }

        #endregion
    }
}