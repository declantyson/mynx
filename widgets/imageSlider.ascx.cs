using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mynx.widgets
{
    public partial class imageSlider : widgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.parameters = "";
            this.text = "";
            this.type = "";
            this.code = "";
        }
    }
}