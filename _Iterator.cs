using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core_Lesson_5
{
    /// <summary>
    /// Iterator
    /// </summary>
    /// <param name="args"></param>

    internal class _Iterator
    {
        static void Main(string[] args)
        {
            LogFileSource logFileSource = new LogFileSource("C:/Logs/sample.log");

            foreach(var line in logFileSource)
            {
                //TODO: ...
            }
        }
    }

    public class LogFileSource : IEnumerable<LogEntry>
    {
        private readonly string _logFileName;

        public LogFileSource(string logFileName)
        {
            _logFileName = logFileName;
        }

        public IEnumerator<LogEntry> GetEnumerator()
        {
            //yield return new LogEntry();
            //yield return new LogEntry();
            //yield return new LogEntry();
            //yield return new LogEntry();
            //yield return new LogEntry();

            foreach (var line in File.ReadAllLines(_logFileName)){
                yield return new LogEntry
                {
                    Message = line
                };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
