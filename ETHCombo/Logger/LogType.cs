namespace ETHComboBot.Logger
{
    using System;

    /// <summary>
    ///     The <see cref="LogType"/> enum contains different ways to log information
    /// </summary>
    [Flags]
    public enum LogType
    {
        /// <summary>
        ///     Used to display debug information
        /// </summary>
        Debug,

        /// <summary>
        ///     Used to display general information
        /// </summary>
        Info,

        /// <summary>
        ///     Used to display warnings
        /// </summary>
        Warning,

        /// <summary>
        ///     Used to display errors
        /// </summary>
        Error
    }
}
