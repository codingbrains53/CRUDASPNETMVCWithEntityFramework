using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MidPointNational
{
    public partial class Inventory : System.Web.UI.Page
    {
        ConnectFoxproToNet ConnectFoxproToNet = new ConnectFoxproToNet();
        string FilePath = ConfigurationManager.AppSettings["FilePath"];
        string INVENTOR = ConfigurationManager.AppSettings["INVENTOR"];
        string LOCINV = ConfigurationManager.AppSettings["LOCINV"];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindInventryData();
            }
            catch(Exception ex)
            {

            }
        }

        protected void GVInventry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVInventry.PageIndex = e.NewPageIndex;
            BindInventryData();
        }

        protected void GVInventry_PageIndexChanged(object sender, EventArgs e)
        {
            BindInventryData();
        }

        protected void BindInventryData()
        {
            try
            {
                DataTable dt = ConnectFoxproToNet.GetINVENTORYTableDetails();
                GVInventry.DataSource = dt;
                GVInventry.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}