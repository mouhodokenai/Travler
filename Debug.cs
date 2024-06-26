using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public static class DebugLogger
    {
        public static void WriteLine(string message)
        {
#if DEBUG
            Console.WriteLine(message);
            Debug.WriteLine(message); // Пишет в окно Output 
#endif
        }

        public static void WriteError(string message)
        {
#if DEBUG
            Console.Error.WriteLine(message);
            Debug.WriteLine("ERROR: " + message); 
#endif
        }

        public static void Assert(bool condition, string message)
        {
#if DEBUG
            if (!condition)
            {
                WriteError("ASSERT FAILED: " + message);
                throw new InvalidOperationException(message);
            }
#endif
        }
    }
}
