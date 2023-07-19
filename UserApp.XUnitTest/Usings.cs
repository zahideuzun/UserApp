global using Xunit;
global using NLog;

Logger logger = LogManager.GetCurrentClassLogger();

logger.Error("This is info error message");
Console.Read();