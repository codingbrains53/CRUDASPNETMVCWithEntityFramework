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
    public partial class Login2 : System.Web.UI.Page
    {
        ConnectFoxproToNet ConnectFoxproToNet = new ConnectFoxproToNet();
        clsLockFile clsLockFile = new clsLockFile();
        string FilePath = ConfigurationManager.AppSettings["FilePath"];
        string INVENTOR = ConfigurationManager.AppSettings["INVENTOR"];
        string LOCINV = ConfigurationManager.AppSettings["LOCINV"];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //clsLockFile.LockFile(FilePath);
                DataTable dt1 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
                clsLockFile.LockFile(FilePath);

                DataTable dt3 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
                clsLockFile.UnLockFile();

                //string FilePath = "F:\\Dbffile\\";
                //string ConnectionString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=" + FilePath + ";Exclusive=No; NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";

                //ConnectFoxproToNet.LockDataBase();
                //  ConnectFoxproToNet.ExecuteTransaction(ConnectionString);
                //   ConnectFoxproToNet.ExecuteTransaction(ConnectionString);
            }
            catch (Exception ex)
            {

            }
          
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           DataTable dt= ConnectFoxproToNet.GetDataFromFoxToNetByCustomerId(txtUsername.Text);
            if(dt.Rows.Count>0)
            {
                Response.Redirect("~/InventorEdit.aspx");
            }
            else
            {
                lblMessage.Text = "invalid customer no and passoword.";
            }
        }
    }
}