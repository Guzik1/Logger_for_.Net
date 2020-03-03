using System;
using System.Collections.Generic;
using System.Text;

namespace NLogger
{
    /// <summary>
    /// Enum of log types.
    /// </summary>
    public enum LogType
    {
        /// <summary>Info layer</summary>
        Info,
        /// <summary>Info2 layer</summary>
        Info2,
        /// <summary>Waring layer</summary>
        Warning,
        /// <summary>Error layer</summary>
        Error,
        /// <summary>Fatal error layer</summary>
        FatalError,
        /// <summary>Debug layer</summary>
        Debug
    }
}
