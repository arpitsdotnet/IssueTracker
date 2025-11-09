using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IssueTracker.ModelLayer.Users.Models;
using IssueTracker.WebUIHelper;
using IssueTracker.WebUIHelper.Abstracts;
using IssueTracker.WebUIHelper.Constants;
using IssueTracker.WebUIHelper.Helpers;

namespace IssueTracker.WebUI
{
    public partial class _Default : RootPage
    {
        private readonly ICookieProvider _cookieProvider;

        public _Default(ICookieProvider cookieProvider)
        {
            _cookieProvider = cookieProvider;
        }
        public _Default() : this(new CookieHelper())
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                if (!IsPostBack)
                {
                    if (Request.Cookies[Var.USER_SESSION] != null)
                    {
                        HttpCookie userCookie = Request.Cookies[Var.USER_SESSION];
                        string employeeRoleString = userCookie[Var.EMPLOYEE_ROLES_SESSION].ToString();
                        List<string> employeeAssignedRoles = (employeeRoleString.Split('|').Select(item => item)).ToList();

                        RedirectBasedOnRoles(employeeAssignedRoles);
                        return;
                    }
                }
            });
        }

        private void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void RedirectBasedOnRoles(List<string> employeeAssignedRoles)
        {
            string returnUrl = GetReturnUrl();

            if (employeeAssignedRoles == null)
            {
                string path1 = returnUrl != "" ? returnUrl : WebUIHelper.Constants.PageSets.Employees[0];
                Response.Redirect(path1, false);
                return;
            }

            string path = "";

            //Get & Set Cookie
            List<string> approvedPages = new List<string>();
            foreach (var role in employeeAssignedRoles)
            {
                path = GetUrlByRole(returnUrl, path, role);

                // Refector - 2.0
                SetApprovedPagesByRole(approvedPages, role);

                //break;
            }

            SetPageCookie(approvedPages);
            Response.Redirect(path, false);
            return;
        }
        private string GetReturnUrl()
        {
            string returnUrl = Page.RouteData.Values["returnurl"] == null ? "" : Page.RouteData.Values["returnurl"].ToString();

            //To remove first slash operator in return url if exists
            returnUrl = returnUrl.StartsWith("|") == true ? returnUrl.Remove(0, 1) : returnUrl;

            //To replce pipe operator to slash operator
            returnUrl = returnUrl == "" ? "" : "/" + returnUrl.Replace('|', '/');

            return returnUrl;
        }
        private string GetUrlByRole(string returnUrl, string path, string role)
        {
            if (returnUrl != "")
                return returnUrl;

            if (path != "")
                return path;

            switch (role)
            {
                case "ROLE_ADMIN":
                case "DIVISION_DIRECTORS":
                    return WebUIHelper.Constants.PageSets.Admins[0];

                case "DIVISION_MANAGERS":
                case "ROLE_ANALYSIS":
                    return WebUIHelper.Constants.PageSets.Employees[0];

                default:
                    return WebUIHelper.Constants.PageSets.Employees[0];
            }
        }
        private void SetApprovedPagesByRole(List<string> approvedPages, string role)
        {
            switch (role)
            {
                case "ROLE_ADMIN":
                case "DIVISION_DIRECTORS":
                    approvedPages.AddRange(PageSets.Admins);
                    approvedPages.AddRange(PageSets.Settings);
                    approvedPages.AddRange(PageSets.Customers);
                    approvedPages.AddRange(PageSets.Quotes);
                    approvedPages.AddRange(PageSets.Sales);
                    break;

                case "DIVISION_MANAGERS":
                case "ROLE_ANALYSIS":
                    approvedPages.AddRange(PageSets.Customers);
                    approvedPages.AddRange(PageSets.Quotes);
                    break;

                case "ROLE_MARKETING":
                    approvedPages.AddRange(PageSets.Customers);
                    approvedPages.AddRange(PageSets.Quotes);
                    approvedPages.AddRange(PageSets.Sales);
                    break;

                case "ROLE_DEVELOPMENT":
                    break;

                    //case "ROLE_OPERATIONS":
                    //    approvedPages.AddRange(Pages.Testing);
                    //    break;

            }

            approvedPages.AddRange(PageSets.Projects);

            ////return approvedPages;
        }
        private void SetPageCookie(List<string> approvedPages)
        {
            if (_cookieProvider.HasKeys(Var.PAGES_SESSION))
                _cookieProvider.RemoveCookie(Var.PAGES_SESSION);

            var collection = new List<NameValueCollection>();

            //Add employee page properties to 1
            collection.AddRange(PageSets.Employees.Select(page => new NameValueCollection { { page, "1" } }));

            // Set approved pages properties to 1
            collection.AddRange(approvedPages.Select(page => new NameValueCollection { { page, "1" } }));

            _cookieProvider.AddCookie(Var.PAGES_SESSION, collection);

            //Response.Cookies.Remove(Var.Pages);
            //HttpCookie pageCookie = new HttpCookie(Var.Pages);

            //foreach (string page in Pages.Employees)
            //{
            //    pageCookie.Values.Add(page, "1"); //Add employee page properties to 1
            //}

            //foreach (string page in approvedPages)
            //{
            //    pageCookie.Values.Add(page, "1");
            //    //PageCookie.Values[page] = "1"; // Set approved pages properties to 1
            //}

            //pageCookie.Expires = _dateTimeProvider.Now.AddHours(7);
            //if (Request.Url.AbsolutePath.Contains("localhost"))
            //    pageCookie.Expires = _dateTimeProvider.Now.AddDays(7);

            //Response.Cookies.Add(pageCookie);
        }

        private void SetUserCookie(User user)
        {
            if (_cookieProvider.HasKeys(Var.USER_SESSION))
                _cookieProvider.RemoveCookie(Var.USER_SESSION);

            if (user == null)
                _cookieProvider.RemoveCookie(Var.USER_SESSION);

            var collection = new List<NameValueCollection>
            {
                new NameValueCollection { { "EmployeeID", user.UserId.ToString()} },
                new NameValueCollection { { "Username", user.UserName } },
                new NameValueCollection { { "FullName", user.UserName } },
                new NameValueCollection { { "ImageFileName", user.ProfileFilePath } },
                new NameValueCollection { { "MobileNumber", user.UserPhone } },
            };

            if (!string.IsNullOrEmpty(user.UserRoleCode))
            {
                collection.Add(new NameValueCollection { { "EmployeeRoles", string.Join("|", user.UserRoleCode.Select(role => role).ToArray()) } });
            }

            _cookieProvider.AddCookie(Var.USER_SESSION, collection);
        }
    }
}