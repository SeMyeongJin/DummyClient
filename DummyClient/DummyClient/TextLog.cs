using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;
using System.Threading;


namespace DummyClient
{
    public enum LOG_LEVEL
    {
        TRACE,
        DEBUG,
        INFO,
        WARN,
        ERROR,
        DISABLE
    }

    public class TextLog
    {
        static System.Collections.Concurrent.ConcurrentQueue<string> textLogQueue = new System.Collections.Concurrent.ConcurrentQueue<string>();

        static Int64 Log_Level = (Int64)LOG_LEVEL.TRACE;

        static public void Init(LOG_LEVEL logLevel)
        {
            ChangeLogLevel(logLevel);
        }

        static public void ChangeLogLevel(LOG_LEVEL logLevel)
        {
            Interlocked.Exchange(ref Log_Level, (int)logLevel);
        }

        public static LOG_LEVEL CurrentLogLevel()
        {
            var curLogLevel = (LOG_LEVEL)Interlocked.Read(ref Log_Level);
            return curLogLevel;
        }

        static public void Write(string msg, LOG_LEVEL logLevel = LOG_LEVEL.TRACE,
                                [CallerFilePath] string fileName = "",
                                [CallerMemberName] string methodName = "",
                                [CallerLineNumber] int lineNumber = 0)
        {
            if (CurrentLogLevel() <= logLevel)
            {
                textLogQueue.Enqueue(string.Format("{0}:{1}| {2}", DateTime.Now, methodName, msg));
            }
        }

        static public bool GetLog(out string msg)
        {
            if (textLogQueue.TryDequeue(out msg))
            {
                return true;
            }

            return false;
        }
    }
}
