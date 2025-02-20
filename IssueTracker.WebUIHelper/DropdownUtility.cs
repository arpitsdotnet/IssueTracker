using System.Web.UI.WebControls;

namespace IssueTracker.WebUIHelper
{
    public static class DropdownUtility
    {
        public static void BindData(this DropDownList ddl, object data = null, string textField = "", string valueField = "", string defaultItemText = "- Select -", string defaultItemValue = "0")
        {
            if (data == null)
            {
                ddl.Items.Clear();
                ddl.DataSource = null;
                ddl.DataBind();
                return;
            }

            ddl.DataSource = data;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();

            if (defaultItemText != "")
                ddl.Items.Insert(0, new ListItem(defaultItemText, defaultItemValue));
        }
    }
}
