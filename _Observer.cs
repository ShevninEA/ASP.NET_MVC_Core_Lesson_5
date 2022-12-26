using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core_Lesson_5
{
    /// <summary>
    /// Observer
    /// </summary>
    /// <param name="args"></param>
    internal class _Observer
    {

        //static void PrintInfo(string text) // Action<string>
        //{
        //    Console.WriteLine(text);
        //}

        static void Main(string[] args)
        {

            MyLogFileReader myLogFileReader = new MyLogFileReader("C:/logs/sample.log", text =>
            {
                Console.WriteLine(text);
            });

            Console.ReadKey(true);
        }
    }

    public class MyLogFileReader : IDisposable
    {
        private readonly string _logFileName;
        private readonly Action<string> _logEntrySubscriber;
        private readonly static TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);
        private readonly StreamReader _textReader;
        private readonly FileStream _fileStream;
        private readonly Timer _timer;

        public MyLogFileReader(string logFileName, Action<string> logEntrySubscriber)
        {
            if (!File.Exists(logFileName))
                throw new FileNotFoundException();

            _logFileName = logFileName;

            _fileStream = new FileStream(_logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _textReader = new StreamReader(_fileStream);


            _logEntrySubscriber = logEntrySubscriber;

            _timer = new Timer(t => CheckFile(), null, CheckFileInterval, CheckFileInterval);
        }

        public void Dispose()
        {
            if (_timer != null)
                _timer.Dispose();
            if (_fileStream != null)
                _fileStream.Dispose();
            if (_textReader != null)
                _textReader.Dispose();
        }

        private void CheckFile()
        {
            foreach (var text in ReadNewLogEntries())
            {
                _logEntrySubscriber(text);
            }
        }

        private IEnumerable<string> ReadNewLogEntries()
        {
            while (!_textReader.EndOfStream)
            {
                yield return _textReader.ReadLine();
            }
        }
    }
}
