using System;
using System.Configuration;

namespace IssueTracker.BusinessLayer.Services
{
    public class ConfigurationServices 
    {
        public static string GetAppSettingKey(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].Trim();
            }
            catch
            {
                throw new Exception("Unable to find App Setting Key : " + key);
            }
        }
    }
}
