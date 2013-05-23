using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mynx.widgets
{
    public partial class backgroundColor : widgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.parameters = "";
            this.text = "Choose background colour";
            this.type = "Option";
            
            // add spectrum dependencies
            this.code = "<scr\"+\"ipt src='/lib/spectrum.js'></scr\"+\"ipt><link rel='stylesheet' href='/lib/spectrum.css' />";
            // the input
            this.code += "<div class='col col-50' style='float:right'><input type='text' id='backgroundColor' name='backgroundColor' /></div><div class='clear'></div>";
            // handling
            this.code += "<scr\'+\'ipt>";
            this.code += "globhex = '';$('#backgroundColor').spectrum({change:function(color){globhex = color.toHexString(); preRasterize.backgroundColor = function(){ $('.editable-content').append('<style> html,body { background-color: ' + globhex + ' } </style>'); };}});";
            this.code += "</scr\'+\'ipt>";
        }
    }
}