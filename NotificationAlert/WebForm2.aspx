<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="NotificationDemo.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
     <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
     <link href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet"/>
    <script>
          $("#alert-target").click(function () {
    toastr["info"]("I was launched via jQuery!")
});
    </script>

  <%--  <script>
          $("#alert-target").click(function () {
   toastr["success"]("My name is Inigo Montoya. You killed my father. Prepare to die!")

toastr.options = {
  "closeButton": true,
  "debug": false,
  "newestOnTop": false,
  "progressBar": true,
  "positionClass": "toast-top-right",
  "preventDuplicates": true,
  "showDuration": "300",
  "hideDuration": "1000",
  "timeOut": "5000",
  "extendedTimeOut": "1000",
  "showEasing": "swing",
  "hideEasing": "linear",
  "showMethod": "fadeIn",
  "hideMethod": "fadeOut"
}
});
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
               <!-- Info message -->
<a class="btn btn-info" onclick="toastr.info('Hi! I am info message.');">Info message</a>
<!-- Warning message -->
<a class="btn btn-warning" onclick="toastr.warning('Hi! I am warning message.');">Warning message</a>
<!-- Success message -->
<a class="btn btn-success" onclick="toastr.success('Hi! I am success message.');">Success message</a>
<!-- Error message -->
<a class="btn btn-danger" onclick="toastr.error('Hi! I am error message.');">Error message</a>
        </div>
    </form>
</body>
</html>
