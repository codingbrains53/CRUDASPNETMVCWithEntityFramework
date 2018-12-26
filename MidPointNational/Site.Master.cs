using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MidPointNational
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void LnkLogpout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            SessionList.LoggedUser = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}