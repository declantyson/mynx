using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mynx.widgets
{
    public partial class chooseImage : widgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.parameters = "";
            this.text = "Choose image from library";
            this.type = "Content";
            this.code = "<div class='col edit-col col-33 movable resizable editable'><iframe src='/admin/imagelibrary_min' style='width: 100%' class='image-lib-frame'></iframe></div>";
        }
    }
}