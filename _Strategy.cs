namespace ASP.NET_MVC_Core_Lesson_5
{
    internal class _Strategy
    {
        /// <summary>
        /// Strategy
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            new LogFileReader();
            new WindowsEventLogReader();

            LogProcessor logProcessor = new LogProcessor(new LogFileReader());
            LogProcessor logProcessor2 = new LogProcessor(new WindowsEventLogReader());
            LogProcessor logProcessor3 = new LogProcessor(() => new LogFileReader().Read());
            logProcessor.ProcessLogs();
            logProcessor2.ProcessLogs();
        }
    }

    public class LogEntry : LogEntryBase
    {
        public override void Print()
        {
            base.Print();
        }
    }

    public interface ILogReader
    {
        public List<LogEntry> Read();
    }

    public class LogFileReader : ILogReader
    {
        public List<LogEntry> Read()
        {
            throw new NotImplementedException();
        }
    }

    public class WindowsEventLogReader : ILogReader
    {
        public List<LogEntry> Read()
        {
            throw new NotImplementedException();
        }
    }

    public class LogProcessor
    {
        private readonly ILogReader _logReader;
        private readonly Func<List<LogEntry>> _logImporter;


        /// <summary>
        /// Вариант 2
        /// </summary>
        public LogProcessor(Func<List<LogEntry>> logImporter)
        {
            _logImporter = logImporter;
        }

        /// <summary>
        /// Вариант 1
        /// </summary>
        /// <param name="logreader"></param>
        public LogProcessor(ILogReader logreader)
        {
            _logReader = logreader;
        }

        /// <summary>
        /// Вариант 2
        /// </summary>
        public void ProcessLogsV2()
        {
            foreach (var log in _logImporter.Invoke())
            {
                SaveLogEntry(log);
            }
        }

        /// <summary>
        /// Вариант 1
        /// </summary>
        public void ProcessLogs()
        {
            var logs = _logReader.Read();
            foreach (var log in logs)
            {
                SaveLogEntry(log);
            }
        }

        private void SaveLogEntry(LogEntry logEntry)
        {
            //TODO: ....
        }
    }
}