using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mynx.widgets
{
    public partial class backgroundImage : widgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.parameters = "";
            this.text = "Choose background image";
            this.type = "Option";
            this.code = "<div class='col col-50' style='float:right' id='bgCol'><iframe id='bgImgUploader' src='/widgets/backgroundImage/upload.aspx' style='width: 100%' class='image-lib-frame'></iframe></div><div class='clear'></div>";
        }
    }
}