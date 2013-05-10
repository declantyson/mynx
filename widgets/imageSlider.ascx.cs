using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mynx.widgets
{
    public partial class WidgetControl : System.Web.UI.UserControl
    {
        public string parameters = "";
        public void test()
        {
            Response.Write("test");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}