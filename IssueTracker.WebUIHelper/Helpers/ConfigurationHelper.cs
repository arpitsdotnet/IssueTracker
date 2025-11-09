using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.WebUIHelper.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetKeyValue(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Please provide a key.");
            }

            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                throw new ArgumentNullException($"Unable to find Configuration Key : {key}.");
            }
        }
    }
}
