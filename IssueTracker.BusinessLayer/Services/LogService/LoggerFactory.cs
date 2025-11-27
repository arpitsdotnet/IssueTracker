using IssueTracker.BusinessLayer.Services.Abstracts;

namespace IssueTracker.BusinessLayer.Services.LogService
{
    public static class LoggerFactory<T> 
    {
        private static ILogger<T> _Instance;
        static LoggerFactory() { }
        public static ILogger<T> Instance
        {
            get
            {
                if (_Instance is null)
                    _Instance = new FileLogger<T>();

                return _Instance;
            }
        }
    }
}
