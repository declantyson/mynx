using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mynx.widgets
{
    public partial class rawHtml : widgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.parameters = "";
            this.text = "Raw HTML Column";
            this.type = "Content";
            this.code = "<div class='col edit-col col-33 movable resizable raw'><textarea></textarea></div>";
        }
    }
}