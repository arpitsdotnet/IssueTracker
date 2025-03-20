using System.Web.UI.WebControls;

namespace IssueTracker.WebUIHelper
{
    public static class RadioButtonListUtility
    {
        public static void BindData(this RadioButtonList rbl, object data = null, string textField = "", string valueField = "", string defaultItemText = "", string defaultItemValue = "")
        {
            if (data == null)
            {
                rbl.Items.Clear();
                rbl.DataSource = null;
                rbl.DataBind();
                return;
            }

            rbl.DataSource = data;
            rbl.DataTextField = textField;
            rbl.DataValueField = valueField;
            rbl.DataBind();

            if (defaultItemText != "")
                rbl.Items.Insert(0, new ListItem(defaultItemText, defaultItemValue));
        }
    }
}
