using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MidPointNational
{
    public partial class InventorEdit : System.Web.UI.Page
    {
        ConnectFoxproToNet ConnectFoxproToNet = new ConnectFoxproToNet();
        clsLockFile clsLockFile = new clsLockFile();

        string FilePath = ConfigurationManager.AppSettings["FilePath"];
        string INVENTOR = ConfigurationManager.AppSettings["INVENTOR"];
        string LOCINV = ConfigurationManager.AppSettings["LOCINV"];
       // string CUSTOMER = ConfigurationManager.AppSettings["CUSTOMER"];
        int  ToatalBOH = 0;
        int ToatlOpenQTY_ALLO = 0;
        int CARTONCOUNT = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if(!IsPostBack)
                {
                    if(SessionList.LoggedUser==null)
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
               
            }
            catch (Exception ex)
            {

            }
        }
        protected void BtnGo_Click(object sender, EventArgs e)
        {
            try
            {
               
                LblMsg1.Text = string.Empty;
                LblMsg1.CssClass = string.Empty;
                LblMsg.Text = string.Empty;
                LblMsg.CssClass = string.Empty;

                BindInventryData();
                //Lock File INVENTOR.DBF and LOCINV.DBF after Read Data  
               // clsLockFile.LockFile(FilePath + INVENTOR);
             //  clsLockFile.LockFile(FilePath + LOCINV);
            }
            catch (Exception rx)
            {

            }
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                LblMsg.Text = string.Empty;
                TxtISBN.Text= string.Empty;
                TxtLocationFrom.Text= string.Empty;
                TxtLocationTo.Text= string.Empty;
            }
            catch (Exception ex)
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

        }

        protected void BindInventryData()
        {
            try
            {

                if (!string.IsNullOrEmpty(TxtISBN.Text))
                {
                   
                    DataTable dt1 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
                    DataTable dt2 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(LOCINV);

                    var inventorytable = (from table1 in dt1.AsEnumerable()
                                          join table2 in dt2.AsEnumerable() on table1.Field<string>("ISBN") equals table2.Field<string>("ISBN")
                                          where table1.Field<string>("ISBN").EndsWith(TxtISBN.Text)
                                          select new
                                          {
                                              ISBN = table1.Field<string>("ISBN").Trim(),
                                              FULL_ISBN = table1.Field<string>("FULL_ISBN"),

                                              QTY_BO = table1.Field<object>("QTY_BO"),
                                              PIECE_WGT = table1.Field<object>("PIECE_WGT"),
                                              CARTON_CUB = table1.Field<object>("CARTON_CUB"),
                                              CARTON_LBS = table1.Field<object>("CARTON_LBS"),
                                              LOC_QTY = table1.Field<object>("LOC_QTY"),
                                              QTY_ALLO = table2.Field<object>("QTY_ALLO"),
                                              LOC = table2.Field<string>("LOC"),
                                              HOLD = table2.Field<string>("HOLD"),
                                              TITLE = table2.Field<string>("TITLE"),
                                              STATUS = table2.Field<string>("STATUS"),

                                              BOH = table2.Field<object>("BOH"),
                                              OBOH = table2.Field<object>("OBOH"),


                                          }).ToList();
                    GVInventry.ShowFooter = true;
                    GVInventry.Columns[2].Visible = false;
                    GVInventry.DataSource = inventorytable;
                    GVInventry.DataBind();
                   
                    foreach ( var i  in inventorytable)
                    {
                        ToatalBOH = ToatalBOH + Convert.ToInt32(i.BOH);
                        ToatlOpenQTY_ALLO= ToatlOpenQTY_ALLO+ Convert.ToInt32(i.QTY_ALLO);
                        CARTONCOUNT= CARTONCOUNT + Convert.ToInt32(i.CARTON_CUB);
                    }
                     if (inventorytable.Count > 0)
                    {
                        LblHeading.Text = " Details by ISBN";
                        pnlSecond.Visible = true;
                        PnlFirst.Visible = false;
                        PnlForISBN.Visible = true;
                        PnlForLOcation.Visible = false;

                        var inventory = inventorytable.FirstOrDefault();

                        LblIsbnNo.Text = inventory.ISBN.ToString();
                        LblTITLE.Text = inventory.TITLE.ToString();
                        LblTOTALBOH.Text = ToatalBOH.ToString();
                        LblTOTALBOH.Text = ToatalBOH.ToString();
                        LblQTYOPEN.Text = ToatlOpenQTY_ALLO.ToString();
                        LblCARTONCOUNT.Text = CARTONCOUNT.ToString();
                        LblCARTONWEIGHT.Text = inventory.CARTON_LBS.ToString();
                    }

                    else
                    {
                        LblMsg1.Text = "Invalid ISBN Number ";
                        LblMsg1.CssClass = "error-msg";
                    }

                }

                else if (!string.IsNullOrEmpty(TxtLocationFrom.Text) && !string.IsNullOrEmpty(TxtLocationTo.Text))
                {
                   
                    DataTable dt1 = ConnectFoxproToNet.GetDataFromFoxToNetByISBN(INVENTOR);
                    DataTable dt2 = ConnectFoxproToNet.GetDataFromFoxToNetByLOC(TxtLocationFrom.Text, TxtLocationTo.Text);

                    var inventorytable = (from table1 in dt1.AsEnumerable()
                                          join table2 in dt2.AsEnumerable() on table1.Field<string>("ISBN") equals table2.Field<string>("ISBN")
                                          
                                          select new
                                          {
                                              ISBN = table1.Field<string>("ISBN"),
                                              FULL_ISBN = table1.Field<string>("FULL_ISBN"),
                                              QTY_BO = table1.Field<object>("QTY_BO"),
                                              PIECE_WGT = table1.Field<object>("PIECE_WGT"),
                                              CARTON_CUB = table1.Field<object>("CARTON_CUB"),
                                              CARTON_LBS = table1.Field<object>("CARTON_LBS"),
                                              LOC_QTY = table1.Field<object>("LOC_QTY"),
                                              LOC = table2.Field<string>("LOC"),
                                              QTY_ALLO = table2.Field<object>("QTY_ALLO"),
                                              HOLD = table2.Field<string>("HOLD"),
                                              TITLE = table2.Field<string>("TITLE"),
                                              STATUS = table2.Field<string>("STATUS"),
                                              BOH = table2.Field<object>("BOH"),
                                              OBOH = table2.Field<object>("OBOH"),
                                          }).ToList();

                    GVInventry.ShowFooter = false;
                    GVInventry.Columns[2].Visible = true;

                    GVInventry.DataSource = inventorytable;
                    GVInventry.DataBind();

                    foreach (var i in inventorytable)
                    {
                        ToatalBOH = ToatalBOH + Convert.ToInt32(i.BOH);
                        ToatlOpenQTY_ALLO = ToatlOpenQTY_ALLO + Convert.ToInt32(i.QTY_ALLO);
                        CARTONCOUNT = CARTONCOUNT + Convert.ToInt32(i.CARTON_CUB);
                    }
                    if (inventorytable.Count() > 0)
                    {
                        LblHeading.Text = " Details by Location";
                        pnlSecond.Visible = true;
                        PnlFirst.Visible = false;
                        PnlForISBN.Visible = false;
                        PnlForLOcation.Visible = true;
                      //  var inventory = inventorytable.FirstOrDefault();
                        LblLOC.Text = TxtLocationFrom.Text + " - " + TxtLocationTo.Text;
                        LblTOTALBOHLOC.Text = ToatalBOH.ToString();

                    }

                    else
                    {
                        LblMsg1.Text = "Invalid Location";
                        LblMsg1.CssClass = "error-msg";
                    }



                }
                else
                {
                    LblMsg1.Text = "Please Enter  ISBN Number or Location ";
                    LblMsg1.CssClass = "error-msg";
                }

            }
            
            catch (Exception ex)
            {

            }
        }

       
        protected void GVInventry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GVInventry.EditIndex = -1;
                BindInventryData();
            }
            catch (Exception ex)
            {

            }

        }

        protected void GVInventry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               
                string ISBN = GVInventry.DataKeys[e.RowIndex].Values[0].ToString();
                string LOC = ((Label)GVInventry.Rows[e.RowIndex].FindControl("LblLOC")).Text;
                string QTY_BO = ((Label)GVInventry.Rows[e.RowIndex].FindControl("LblQTY_BO")).Text;
                if(string.IsNullOrEmpty(QTY_BO)|| QTY_BO=="0")
                {
                    bool result = ConnectFoxproToNet.DeleteQTY_BOInFoxToNetByISBNLOC(ISBN,LOC);
                    if (result == true)
                    {
                        LblMsg.Text = "Location Deleted Successfully. ";
                        LblMsg.CssClass = "alert-success";

                    }
                    else
                    {
                        LblMsg.Text = "Unable to delete location.";
                        LblMsg.CssClass = "error-msg";

                    }
                   
                }
                else
                {
                    LblMsg.Text = "The location can not be deleted.";
                    LblMsg.CssClass = "error-msg";
                }
                BindInventryData();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVInventry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                //clsLockFile.UnLockFile();
                GVInventry.EditIndex = e.NewEditIndex;
                BindInventryData();
            }
            catch(Exception ex)
            {

            }
        }

        protected void GVInventry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
               
             
                string ISBN = GVInventry.DataKeys[e.RowIndex].Values[0].ToString();
                string LOC = ((Label)GVInventry.Rows[e.RowIndex].FindControl("LblLOC")).Text;
                object QTY_BO = ((TextBox)GVInventry.Rows[e.RowIndex].FindControl("TxtQTY_BOEdit")).Text;

                bool result = ConnectFoxproToNet.UpdateQTY_BOInFoxToNetByISBNLOC(ISBN, LOC, QTY_BO);
                if(result==true)
                {
                    LblMsg.Text = "Quantity updated successfully. ";
                    LblMsg.CssClass = "alert-success";
                    GVInventry.EditIndex = -1;
                    BindInventryData();
                }
                else
                {
                    LblMsg.Text = "Unable to update recard.";
                    LblMsg.CssClass = "error-msg";
                    GVInventry.EditIndex = -1;
                    BindInventryData();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnClose2_Click(object sender, EventArgs e)
        {
            pnlSecond.Visible = false;
            PnlFirst.Visible = true;
            LblMsg.Text = string.Empty;
        }

         bool UpdateQTY_BOInInventorTable(string ISBN,int QTY_BO)
        {
            try
            {
                
              
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            GVInventry.PagerSettings.Visible = false;
            GVInventry.ShowFooter = false;
            GVInventry.AllowPaging = false;
            BindInventryData();
            // GVInventry.DataBind();
         
            GVInventry.Columns[2].Visible = true;
            GVInventry.Columns[6].Visible = false;
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GVInventry.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'")
                .Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "PrintPage", sb.ToString());
            GVInventry.PagerSettings.Visible = true;
            GVInventry.ShowFooter = true;
            GVInventry.Columns[6].Visible = true;
            GVInventry.Columns[2].Visible = false;
            GVInventry.AllowPaging = true;
            GVInventry.DataBind();
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GVInventry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ConnectFoxproToNet cc = new ConnectFoxproToNet();
                if (e.CommandName.Equals("ADD"))
                {
                    string ISBN = string.Empty;
                    string Title = string.Empty;
                    //GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    //Label label = row.FindControl("LblTITLE") as Label;

                    foreach (GridViewRow gvr in GVInventry.Rows)
                    {
                        ISBN = GVInventry.DataKeys[gvr.RowIndex].Values["ISBN"].ToString();
                    }
                    //   TextBox TxtAddTitle = (TextBox)((GridView)sender).FooterRow.FindControl("TxtAddTitle");
                    TextBox TxtAddLoc = (TextBox)((GridView)sender).FooterRow.FindControl("TxtAddLoc");
                    TextBox TxtAddBOH = (TextBox)((GridView)sender).FooterRow.FindControl("TxtAddBOH");
                    TextBox TxtAddOBOH = (TextBox)((GridView)sender).FooterRow.FindControl("TxtAddOBOH");
                    TextBox TxtAddQTY_BO = (TextBox)((GridView)sender).FooterRow.FindControl("TxtAddQTY_BO");

                    if (string.IsNullOrEmpty(TxtAddLoc.Text))
                        TxtAddLoc.Text = "0";
                    if (string.IsNullOrEmpty(TxtAddBOH.Text))
                        TxtAddBOH.Text = "0";
                    if (string.IsNullOrEmpty(TxtAddOBOH.Text))
                        TxtAddOBOH.Text = "0";
                    if (string.IsNullOrEmpty(TxtAddQTY_BO.Text))
                        TxtAddQTY_BO.Text = "0";

                    bool result = cc.SaveNewRecardInLOCINVByISBN(ISBN, LblTITLE.Text, TxtAddLoc.Text, TxtAddBOH.Text, TxtAddOBOH.Text, TxtAddQTY_BO.Text);
                    if (result == true)
                    {

                        LblMsg.Text = "New recard added  successfully";
                        LblMsg.CssClass = "alert-success";
                        pnlSecond.Visible = false;
                        PnlFirst.Visible = true;
                    }


                }
                
            }
            catch(Exception ex)
            {

            }
        }
    }
    
}