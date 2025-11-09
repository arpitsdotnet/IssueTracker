using System;

namespace IssueTracker.WebUI.UserControls
{
    public partial class TextboxControl : System.Web.UI.UserControl
    {

        public override string ID { get; set; }
        public bool IsRequired { get; set; } = true;
        public string LabelCssClass { get; set; }
        public string LabelText { get; set; }
        public string CssClass { get; set; }
        public string Text { get; set; }
        public string Placeholder { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Lbl.CssClass = $"{LabelCssClass}";
                Lbl.Text = LabelText;
                Lbl.ID = "Lbl_" + ID;

                M_Req.Visible = IsRequired;
                M_Req.ID = "M_Req_" + ID;

                Txt.CssClass = $"form-control {CssClass}";
                Txt.Text = Text;
                Txt.Attributes["placeholder"] = Placeholder;
                Txt.ID = ID;
            }
        }
    }
}