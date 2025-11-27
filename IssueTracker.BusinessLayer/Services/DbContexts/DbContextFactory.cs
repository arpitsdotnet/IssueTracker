using IssueTracker.BusinessLayer.Contracts;

namespace IssueTracker.BusinessLayer.Services.DbContexts
{
    public class DbContextFactory
    {
        private static readonly object lockObject = new object();
        private static IApplicationDBContext _Instance;

        public static IApplicationDBContext Instance
        {
            get
            {
                //Lock is used to make the call Thread-safe
                if (_Instance == null)
                {
                    lock (lockObject)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new SQLDataAccess();
                        }
                    }
                }
                return _Instance;
            }
        }
    }
}
