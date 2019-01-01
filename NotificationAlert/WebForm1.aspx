<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NotificationDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <title></title>
    <script src="toastr.js"></script>
   
    

    <script>
function showAndDismissAlert(type, message) {

  var htmlAlert = '<div class="alert alert-' + type + '">' + message + '</div>';
  $(".alert-messages").prepend(htmlAlert);
  $(".alert-messages .alert").hide().fadeIn(600).delay(2000).fadeOut(1000, function() {
    $(this).remove();
  });

        }

      
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="alert-messages page-alert">
               
            </div>

<div class="buttons">
  <button type="button" name="button" class="btn btn-success" onclick="showAndDismissAlert('success', 'Saved Successfully!')">Button1</button>
  <button type="button" name="button" onclick="showAndDismissAlert('danger', 'Error Encountered')">Button2</button>
  <button type="button" name="button" onclick="showAndDismissAlert('info', 'Message Received')">Button3</button>
</div>
        </div>



     
    </form>
</body>
</html>
