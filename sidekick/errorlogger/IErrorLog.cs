using System;

namespace sidekick
{
    /// <summary>
    ///     Required elements for a log entry
    /// </summary>
    public interface IErrorLog
    {
        /// <summary>
        ///     Time of the exception
        /// </summary>
        DateTime Time { get; set; }

        /// <summary>
        ///     Exception
        /// </summary>
        string Exception { get; set; }

        /// <summary>
        ///     Inner Exception Details
        /// </summary>
        string InnerException { get; set; }

        /// <summary>
        ///     Stack trace message
        /// </summary>
        string StackTrace { get; set; }

        /// <summary>
        ///     The current user when the error occured
        /// </summary>
        string User { get; set; }

        /// <summary>
        ///     Query in the URL
        /// </summary>
        string Query { get; set; }

        /// <summary>
        ///     Route that caused the exception
        /// </summary>
        string Route { get; set; }

        /// <summary>
        ///     Custom comments
        /// </summary>
        string Comments { get; set; }
    }
}

