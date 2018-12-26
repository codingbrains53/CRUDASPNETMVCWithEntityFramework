<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="MidPointNational.Login2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div style="max-width: 400px;">
    <h2 class="form-signin-heading">
        Login</h2>
    <label for="txtUsername">
        Username</label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Customer No" required />
    <br />
    <label for="txtPassword">
        Password</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
        placeholder="Enter Password" required />
    <div class="checkbox">
        <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" />
    </div>
    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" Class="btn btn-primary"  />
    <br />
    <br />
    <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        <strong>Error!</strong>
        <asp:Label ID="lblMessage" runat="server" />
    </div>
</div>


</asp:Content>
