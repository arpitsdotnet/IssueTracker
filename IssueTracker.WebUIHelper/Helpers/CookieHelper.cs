using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.Helpers;
using IssueTracker.WebUIHelper.Abstracts;

namespace IssueTracker.WebUIHelper.Helpers
{
    public class CookieHelper : ICookieProvider
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public CookieHelper(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public CookieHelper() : this(
            new DateTimeHelper()
            )
        {
        }

        public void AddCookie(string cookieName, List<NameValueCollection> data)
        {
            HttpCookie cookie = new HttpCookie(cookieName);

            foreach (NameValueCollection item in data)
            {
                cookie.Values.Add(item);
            }

            cookie.Expires = _dateTimeProvider.DateTimeNow.AddHours(7);
            if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("localhost"))
                cookie.Expires = _dateTimeProvider.DateTimeNow.AddDays(7);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public HttpCookie GetCookie(string cookieName)
        {
            return HttpContext.Current.Request.Cookies[cookieName];
        }

        public string GetCookie(string cookieName, string fieldName)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName];

            return cookie[fieldName];
        }

        public bool HasKeys(string cookieName)
        {
            HttpCookie userCookie = new HttpCookie(cookieName);
            return userCookie.HasKeys;
        }

        public void RemoveCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Expires = _dateTimeProvider.DateTimeNow.AddHours(-1);
            cookie.Values.Clear();
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
