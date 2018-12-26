<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="MidPointNational.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <section class="content-header">
        <h2>
            Inventry Management
        </h2>
    </section>
   
   <div class="row">
    <div class="table table-responsive">
        <asp:GridView ID="GVInventry" runat="server" AutoGenerateColumns="true"  AllowPaging="true" 
            OnPageIndexChanging="GVInventry_PageIndexChanging"
            OnPageIndexChanged="GVInventry_PageIndexChanged" >
            <Columns>
                <asp:TemplateField HeaderText="ISBN" Visible="false">
                   
                    <ItemTemplate>
                       <asp:Label ID="Lbl" runat="server"  Text='<%#Eval("ISBN") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Lbl" runat="server"  Text='<%#Eval("ISBN") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>

                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
             <EmptyDataTemplate>
                No Inventry details available</EmptyDataTemplate>
            <PagerStyle CssClass="pagination pagination-sm" />  
        </asp:GridView>
        </div>
    </div>
</asp:Content>
