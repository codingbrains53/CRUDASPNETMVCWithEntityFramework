<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MidPointNational.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Inventory  Management Login</title>
    <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="../../App_Theme/bootstrap/css/bootstrap.min.css" />  
  <!-- Theme style -->
   <link rel="stylesheet" href="App_Theme/css/app-pageStyles.css" />
    <link href="App_Theme/css/app-pageStyles.css" rel="stylesheet" />
    <link href="App_Theme/css/agency.css" rel="stylesheet" type="text/css" />
    <link href="App_Theme/css/style.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700" rel="stylesheet" />
    <link href="App_Theme/bootstrap/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
      <link href="~/favicon.jpg" rel="shortcut icon" type="image/x-icon" />
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
    <div class="login-box">
  <div class="login-logo">
   
  </div>
                
                    <div class="login-box-body">                        
                        <h3 class="text-center">
                             Inventory Management Login</h3>
                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                               
                                    <asp:Label CssClass="control-label" runat="server" Text="Customer Number"></asp:Label>
                                    <asp:TextBox ID="TxtUserName" CssClass="form-control input-lg" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLoginEmail" runat="server" Display="Dynamic" ControlToValidate="TxtUserName"
                                        ErrorMessage="Please Enter Your Customer Number" ValidationGroup="Login" CssClass="error-msg"></asp:RequiredFieldValidator>
                               </div>
                                <div class="col-md-12">
                                    <asp:Label CssClass="control-label" runat="server" Text="Password"></asp:Label>
                                    <asp:TextBox ID="txtLoginPassword" CssClass="form-control input-lg" runat="server" TextMode="Password" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLoginPassword" runat="server" Display="Dynamic"
                                        ControlToValidate="txtLoginPassword" ErrorMessage="Please Enter Password" ValidationGroup="Login"
                                        CssClass="error-msg"></asp:RequiredFieldValidator>
                               
                            </div>
                        </div>
                           <asp:Label ID="lblSignInFail" runat="server" Text="" CssClass="error-msg"></asp:Label>
                        <div class="form-group text-center margin-top-20">
                            
                                
                                 <asp:Button ID="btnLogin" CssClass="fa fa-sign-in btn btn-theme btn-block btn-lg" runat="server"
                                        Text="Login" ValidationGroup="Login" OnClick="btnLogin_Click" />
                                 
                             
                            
                        </div>
                       <%-- <div class="form-group text-center margin-top-20">
                               <a class="btn btn-link" href="<%=ResolveClientUrl("~/home.aspx")%>"><i class="fa fa-angle-left"></i> Back to Home</a>
                            </div>--%>
                      
                       
                    </div>
                

  
</div>
    </form>
</body>
</html>