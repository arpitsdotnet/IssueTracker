using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace IssueTracker.WebUIHelper.Abstracts
{
    public interface ICookieProvider
    {
        void AddCookie(string cookieName, List<NameValueCollection> data);
        HttpCookie GetCookie(string cookieName);
        string GetCookie(string cookieName, string fieldValue);
        bool HasKeys(string cookieName);
        void RemoveCookie(string cookieName);
    }
}
