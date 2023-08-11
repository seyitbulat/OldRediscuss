namespace Rediscuss.Business.Interfaces
{
	public interface ILoggerBs
	{
		void LogInfo(string message);
		void LogWarning(string message);
		void LogError(string message);
		void LogDebug(string message);
	}
}
