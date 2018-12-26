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
    public partial class Login : System.Web.UI.Page
    {
        ConnectFoxproToNet ConnectFoxproToNet = new ConnectFoxproToNet();
        clsLockFile clsLockFile = new clsLockFile();
        string FilePath = ConfigurationManager.AppSettings["FilePath"];
        string INVENTOR = ConfigurationManager.AppSettings["INVENTOR"];
        string LOCINV = ConfigurationManager.AppSettings["LOCINV"];
        //Session Databale 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  clsLockFile.LockFile(FilePath);
                //DataTable dt1 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
                //clsLockFile.LockFile(FilePath + INVENTOR);

                //DataTable dt3 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
                //clsLockFile.UnLockFile();
                //DataTable dt4 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
            }
         
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ConnectFoxproToNet.GetDataFromFoxToNetByCustomerId(TxtUserName.Text);
                if (dt.Rows.Count > 0)
                {
                    SessionList.LoggedUser = dt.Rows[0].Field<object>("CUST_NO").ToString();
                    Response.Redirect("~/InventorEdit.aspx",false);
                }
                else
                {
                    lblSignInFail.Text = "invalid customer no or passoword.";
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}