namespace ETHComboBot.Logger
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     The <see cref="Log"/> class provides various methods to debug, warn, inform, and log errors.
    /// </summary>
    public class Log
    {
        /// <summary>
        ///     Writes a debug message to console
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="memberName">The calling member name</param>
        /// <param name="sourceFilePath">The source file path</param>
        public static void Debug(string msg, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            WriteLine(msg, LogType.Debug, memberName, sourceFilePath);
        }

        /// <summary>
        ///     Writes an informal message to console
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="memberName">The calling member name</param>
        /// <param name="sourceFilePath">The source file path</param>
        public static void Info(string msg, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine(msg, LogType.Info, memberName, sourceFilePath);
            Console.ForegroundColor = lastColor;
        }

        /// <summary>
        ///     Writes a warning message to console
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="memberName">The calling member name</param>
        /// <param name="sourceFilePath">The source file path</param>
        public static void Warn(string msg, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteLine(msg, LogType.Warning, memberName, sourceFilePath);
            Console.ForegroundColor = lastColor;
        }

        /// <summary>
        ///     Writes an error message to console
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="memberName">The calling member name</param>
        /// <param name="sourceFilePath">The source file path</param>
        public static void Error(string msg, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine(msg, LogType.Error, memberName, sourceFilePath);
            Console.ForegroundColor = lastColor;
        }

        /// <summary>
        ///     Writes a message to console
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="type">The type of message</param>
        /// <param name="memberName">The calling member name</param>
        /// <param name="sourceFilePath">The source file path</param>
        private static void WriteLine(string msg, LogType type, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "")
        {
            string file = sourceFilePath?.Split('/', '\\').LastOrDefault()?.Split('.').FirstOrDefault();
            string line = $"{DateTime.Now.ToLongTimeString()}|{type}|{file}.{memberName} >> {msg}";
            Console.WriteLine(line);
        }
    }
}
