namespace IssueTracker.WebUIHelper.Constants
{
    public static class PageSets
    {
        public static string[] Admins = { "/dashboard", "/admin/employees", "admin/employees/edit", "/admin/employees/add", "/admin/emprole" };
        public static string[] Settings = { "/settings", "/settings/category", "/settings/category/add", "/settings/category/edit", "/settings/service", "/settings/services/add", "/settings/services/edit" };
        public static string[] Customers = { "/customers", "/customer/account", "/customer/account/add", "/customer/account/edit", "/customer/contact", "/customer/contact/add", "/customer/contact/edit" };
        public static string[] Quotes = { "/quotes", "/quotes/add", "/quotes/edit", "/quotes/opportunities" };
        public static string[] Sales = { "/sales", "/sales/invoice", "/sales/invoice", "/sales/invoice/add", "/sales/invoice/edit", "/sales/receipt", "/sales/payment/add", "/sales/payment/edit", "/sales/expense", "/sales/expense/add", "/sales/expense/edit" };
        public static string[] Projects = { "/projects", "/projects/edit", "/projects/prodivision" };
        public static string[] Employees = { "/employee/dashboard", "/employee/mytimeview", "/employee/mytask", "/employee/myprofile", "/employee/myprofile/edit" };

        public const string Unauthorize = "/unauthorize";
        public const string NotFoud = "/notfound";

    }
}
