<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventorEdit.aspx.cs" EnableEventValidation="false" Inherits ="MidPointNational.InventorEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <script>
    function PrintPage() {
        var printContent = document.getElementById('<%= pnlGridView.ClientID %>');
        var printWindow = window.open("All Records", "Print Panel", 'left=50000,top=50000,width=0,height=0');
        printWindow.document.write(printContent.innerHTML);
        printWindow.document.close();
        printWindow.focus();
        printWindow.print();
    }

</script>
      <div class="row">
    <section class="content-header">
        <h3>
            Inventory Management
        </h3>
    </section>
        
   <div class="content-header">
     <asp:Panel ID="PnlFirst" runat="server"  CssClass="panel panel-primary">
      <div class="panel-heading">Tiger Tales lookup by Location or ISBN</div>
      <div class="panel-body">
        
          <div class="form-horizontal">
              <div class="form-group">
    <div class="col-sm-12 text-bold"><h3>CHOOSE ONE :</h3></div>
    
  </div>
  <div class="form-group">
    <div class="col-sm-3 text-bold"> Enter Last 6 OF ISBN :</div>
    <div class="col-sm-9">
        <div class="col-sm-4">   
      <asp:TextBox ID="TxtISBN" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-3 text-bold">Enter Location OR Range:</div>
    <div class="col-sm-9"> 
         <div class="col-sm-4">    <asp:TextBox ID="TxtLocationFrom" runat="server" CssClass="form-control"></asp:TextBox></div>
         <div class="col-sm-1 text-center text-bold"> TO  </div>
         <div class="col-sm-4">   <asp:TextBox ID="TxtLocationTo" runat="server" CssClass="form-control"></asp:TextBox></div>

    </div>
  </div>
 
  <div class="form-group"> 
    <div class="col-sm-3">
    </div>
       <div class="col-sm-9">
            <asp:Button ID="BtnGo" Text="Go" runat="server" CssClass="btn btn-success btn-block btn-lg fa fa-sign-in" OnClick="BtnGo_Click" /> 
             <asp:Button ID="BtnClose" Text="Close" runat="server" CssClass="btn btn-danger btn-block btn-lg fa fa-sign-in" OnClick="BtnClose_Click" />
        
           </div>
</div>
              <div class="form-group"> 
    <div class="col-sm-3">
    </div>
       <div class="col-sm-9">
         
           <asp:Label ID="LblMsg1" runat="server" ></asp:Label>
        
           </div>
</div>

      </div>
  </div>
  
</asp:Panel>
      
       <div class="row">
  
         <div> <asp:Label ID="LblMsg"  runat="server"></asp:Label></div>
      </div>
        <asp:Panel ID="pnlSecond" runat="server"  CssClass="panel panel-primary" Visible="false">
      <div class="panel-heading"><asp:Label ID="LblHeading" runat="server"></asp:Label></div>
      <div class="panel-body">
            <div class="form-horizontal" id="PnlForISBN" runat="server">
              <div class="form-group">
    <div class="col-sm-2 text-bold">ISBN  :</div>
    <div class="col-sm-10">
     <asp:Label ID="LblIsbnNo" runat="server" ></asp:Label>
    </div>
                  </div>
           <div class="form-group">
       <div class="col-sm-2 text-bold">TITLE  :</div>
    <div class="col-sm-10">
     <asp:Label ID="LblTITLE" runat="server" ></asp:Label>
    </div>
               </div>
           <div class="form-group">
                   <div class="col-sm-2 text-bold">TOTAL BOH  :</div>
    <div class="col-sm-3">
     <asp:Label ID="LblTOTALBOH" runat="server" ></asp:Label>
    </div>
                 <div class="col-sm-2 text-bold">QTY OPEN  :</div>
    <div class="col-sm-3">
     <asp:Label ID="LblQTYOPEN" runat="server" ></asp:Label>
    </div>
  </div>
                 <div class="form-group">
                   <div class="col-sm-2 text-bold">CARTON COUNT :</div>
    <div class="col-sm-3">
     <asp:Label ID="LblCARTONCOUNT" runat="server" ></asp:Label>
    </div>
                 <div class="col-sm-2 text-bold">CARTON WEIGHT  :</div>
    <div class="col-sm-3">
     <asp:Label ID="LblCARTONWEIGHT" runat="server" ></asp:Label>
    </div>
  </div>
  </div>
         
            <div class="form-horizontal" id="PnlForLOcation" runat="server" visible="false">
             
           <div class="form-group">
       <div class="col-sm-2 text-bold">LOC  :</div>
    <div class="col-sm-10">
     <asp:Label ID="LblLOC" runat="server" ></asp:Label>
    </div>
               </div>
           <div class="form-group">
       <div class="col-sm-2  text-bold">TOTAL BOH  :</div>
    <div class="col-sm-10">
     <asp:Label ID="LblTOTALBOHLOC" runat="server" ></asp:Label>
    </div>
     </div>
                 
  </div>
          <div class="col-sm-12">
              <div class="table table-responsive">
                  <table width="100%" id="pnlGridView" runat="server">
    <tr>
        <td colspan="2">
                     <asp:GridView ID="GVInventry" runat="server" 
                         CssClass="table table-striped" AutoGenerateColumns="false" 
                         DataKeyNames="ISBN"
                         PageSize="10"
                          AllowPaging="true"
            OnPageIndexChanging="GVInventry_PageIndexChanging"
            OnPageIndexChanged="GVInventry_PageIndexChanged"
                         OnRowCancelingEdit="GVInventry_RowCancelingEdit"
                         OnRowDeleting="GVInventry_RowDeleting" OnRowEditing="GVInventry_RowEditing"
                         OnRowUpdating="GVInventry_RowUpdating"
                         OnRowCommand="GVInventry_RowCommand">
            <Columns>
                 <asp:TemplateField HeaderText="ISBN">
                    <ItemTemplate>
                       <asp:Label ID="LblISBN" runat="server"  Text='<%#Eval("ISBN") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle CssClass="bg-blue" />
        
                </asp:TemplateField>

                <asp:TemplateField HeaderText="LOC" >
                    <ItemTemplate>
                       <asp:Label ID="LblLOC" runat="server"  Text='<%#Eval("LOC") %>'></asp:Label>
                    </ItemTemplate>
                 
                    <FooterTemplate>
                        <asp:TextBox ID="TxtAddLoc" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtAddLOC" runat="server" ValidationGroup="Add" ControlToValidate="TxtAddLoc"
                            Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter Location.">
                        </asp:RequiredFieldValidator>
                    </FooterTemplate>
                      <HeaderStyle CssClass="bg-blue" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="TITLE" Visible="false">
                    <ItemTemplate>
                       <asp:Label ID="LblTITLE" runat="server"  Text='<%#Eval("TITLE") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:Label ID="LblTITLE1" runat="server"  Text='<%#Eval("TITLE") %>'></asp:Label>
                    </EditItemTemplate>
                 
                       <HeaderStyle CssClass="bg-blue" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="BOH">
                    <ItemTemplate>
                       <asp:Label ID="LblBOH" runat="server"  Text='<%#Eval("BOH") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="LblBOH" runat="server"  Text='<%#Eval("BOH") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TxtAddBOH" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtAddBOH" runat="server" ValidationGroup="Add" ControlToValidate="TxtAddBOH"
                            Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter BOH.">
                        </asp:RequiredFieldValidator>
                    </FooterTemplate>
                        <HeaderStyle CssClass="bg-blue" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="MARKED">   
                      <ItemTemplate>
                       <asp:Label ID="LblOBOH" runat="server"  Text='<%#Eval("OBOH") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="LblOBOH" runat="server"  Text='<%#Eval("OBOH") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TxtAddOBOH" runat="server" CssClass="form-control"></asp:TextBox>
                    </FooterTemplate>
                        <HeaderStyle CssClass="bg-blue" />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="EDIT QTY">
                    <ItemTemplate>
                       <asp:Label ID="LblQTY_BO" runat="server"  Text='<%#Eval("QTY_ALLO") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TxtQTY_BOEdit" runat="server" CssClass="form-control"  Text='<%#Eval("QTY_ALLO") %>'></asp:TextBox>
                    </EditItemTemplate>
                  <FooterTemplate>
                        <asp:TextBox ID="TxtAddQTY_BO" runat="server" CssClass="form-control"></asp:TextBox>
                  </FooterTemplate>
                        <HeaderStyle CssClass="bg-blue" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Action">
                   <ItemTemplate>
                <span>
                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-primary" Text="Edit" runat="server" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                      <asp:LinkButton ID="BtnDelete" CssClass="btn btn-danger" Text="Delete" runat="server" CommandName="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </span>
            
            </ItemTemplate>
                    <EditItemTemplate>
                <span onclick="return confirm('Are you sure want to update?')">
                    <asp:LinkButton ID="btnUpdate" CssClass="btn btn-success" Text="Update" runat="server" CommandName="Update" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </span>
                <span >
                    <asp:LinkButton ID="btnCancel" CssClass="btn btn-danger" Text="Cancel" runat="server" CommandName="Cancel" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </span>
            </EditItemTemplate>
                    <FooterTemplate>
                      <span onclick="return confirm('Are you sure want to add?')">
                          <asp:LinkButton ID="BtnAddNew" Text="Add New" runat="server" CssClass="btn btn-info"   ValidationGroup="Add"   CommandName="ADD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                   </span>
                   </FooterTemplate>
                       <HeaderStyle CssClass="bg-blue" />
                </asp:TemplateField>
            </Columns>
             <EmptyDataTemplate>
                No Inventry details available</EmptyDataTemplate>
            <PagerStyle CssClass="pagination pagination-sm" />  
        </asp:GridView>
              </td></tr></table>
              </div>
          </div>
          
            <div class="form-group"> 
   
       <div class="col-sm-12  text-center">
            <asp:Button ID="BtnPrint" Text="Print" runat="server" CssClass="btn btn-info" OnClick="BtnPrint_Click" />
             <asp:Button ID="BtnClose2" Text="Close" runat="server"  OnClick="BtnClose2_Click" CssClass="btn btn-danger" />
           
           </div>
</div>
</div>

</asp:Panel>

     
 </div>
</div>
</asp:Content>
