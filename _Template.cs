using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASP.NET_MVC_Core_Lesson_5
{
    /// <summary>
    /// Template
    /// </summary>
    /// <param name="args"></param>
    internal class _Template
    {
        static void Main(string[] args)
        {
        }
    }

    public enum LogLevel
    {
        Information,
        Warning,
        Error
    }

    public abstract class LogEntryBase
    {
        public DateTime EntryDateTime { get; set; }

        public LogLevel EntryLevel { get; internal set; }

        public string Message { get; internal set; }

        public string AdditionalInformation { get; internal set; }

        public virtual void Print()
        {
            Console.WriteLine($"{EntryDateTime}: {Message}");
        }

    }

    public static class LogEntryBaseExtensions
    {
        public static string GetText(this LogEntryBase logEntry)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("[{0}] ", logEntry.EntryDateTime)
            .AppendFormat("[{0}] ", logEntry.EntryLevel)
            .AppendLine(logEntry.Message)
            .AppendLine(logEntry.AdditionalInformation);
            return sb.ToString();
        }
    }
}
