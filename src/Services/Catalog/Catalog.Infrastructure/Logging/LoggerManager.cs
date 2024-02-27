
using Catalog.Domain.Logging;
using NLog;

namespace Catalog.Infrastructure.Logging;

/// <summary>
/// Represents a logger manager. Provides logging interface and utility functions.
/// </summary>
public class LoggerManager : ILoggerManager
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();

    public LoggerManager()
    {
    }

    /// <summary>
    /// Writes the diagnostic message at the Info level.
    /// </summary>
    /// <param name="message">Log message.</param>
    public void LogInfo(string message) => logger.Info(message);

    /// <summary>
    /// Writes the diagnostic message at the Warn level.
    /// </summary>
    /// <param name="message">Log message.</param>
    public void LogWarn(string message) => logger.Warn(message);

    /// <summary>
    /// Writes the diagnostic message at the Debug level.
    /// </summary>
    /// <param name="message">Log message.</param>
    public void LogDebug(string message) => logger.Debug(message);

    /// <summary>
    /// Writes the diagnostic message at the Error level.
    /// </summary>
    /// <param name="message">Log message.</param>
    public void LogError(string message) => logger.Error(message);
}