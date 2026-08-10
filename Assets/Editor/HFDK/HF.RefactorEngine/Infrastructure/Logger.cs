using System;
using System.Collections.Generic;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Central logging service for HF.RefactorEngine.
    /// Supports multiple log levels and listeners.
    /// </summary>
    public sealed class Logger
    {
        private readonly List<ILogSink> _sinks;

        public LogLevel MinimumLevel { get; set; }

        public Logger()
        {
            _sinks = new List<ILogSink>();

            MinimumLevel = LogLevel.Information;
        }

        //----------------------------------------------------
        // Public API
        //----------------------------------------------------

        public void RegisterSink(
            ILogSink sink)
        {
            if (sink == null)
                throw new ArgumentNullException(nameof(sink));

            if (!_sinks.Contains(sink))
            {
                _sinks.Add(sink);
            }
        }

        public void UnregisterSink(
            ILogSink sink)
        {
            if (sink == null)
                return;

            _sinks.Remove(sink);
        }

        //----------------------------------------------------
        // Logging
        //----------------------------------------------------

        public void Trace(string message)
        {
            Write(LogLevel.Trace, message, null);
        }

        public void Debug(string message)
        {
            Write(LogLevel.Debug, message, null);
        }

        public void Info(string message)
        {
            Write(LogLevel.Information, message, null);
        }

        public void Warning(string message)
        {
            Write(LogLevel.Warning, message, null);
        }

        public void Error(string message)
        {
            Write(LogLevel.Error, message, null);
        }

        public void Error(
            Exception exception)
        {
            if (exception == null)
                return;

            Write(
                LogLevel.Error,
                exception.Message,
                exception);
        }

        public void Critical(
            string message)
        {
            Write(LogLevel.Critical, message, null);
        }

        //----------------------------------------------------
        // Internal
        //----------------------------------------------------

        private void Write(
            LogLevel level,
            string message,
            Exception exception)
        {
            if (level < MinimumLevel)
                return;

            LogEntry entry = new LogEntry
            {
                Timestamp = DateTime.UtcNow,
                Level = level,
                Message = message,
                Exception = exception
            };

            foreach (ILogSink sink in _sinks)
            {
                sink.Write(entry);
            }
        }
    }

    //--------------------------------------------------------
    // Log Entry
    //--------------------------------------------------------

    public sealed class LogEntry
    {
        public DateTime Timestamp { get; set; }

        public LogLevel Level { get; set; }

        public string Message { get; set; } = string.Empty;

        public Exception Exception { get; set; }
    }

    //--------------------------------------------------------
    // Sink Interface
    //--------------------------------------------------------

    public interface ILogSink
    {
        void Write(LogEntry entry);
    }

    //--------------------------------------------------------
    // Log Levels
    //--------------------------------------------------------

    public enum LogLevel
    {
        Trace = 0,

        Debug = 1,

        Information = 2,

        Warning = 3,

        Error = 4,

        Critical = 5
    }
}