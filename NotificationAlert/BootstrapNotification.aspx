﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BootstrapNotification.aspx.cs" Inherits="NotificationDemo.BootstrapNotification" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <title>Bootstrap - notification popup box using bootstrap-growl JS</title>
    <script type="text/javascript" src="//cdn.jsdelivr.net/jquery/1/jquery.min.js"></script>
 
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-growl/1.0.0/jquery.bootstrap-growl.min.js"></script>


</head>
<body>


<div class="container text-center">


    <br/>
        <h2>Bootstrap - notification popup box using bootstrap-growl JS Plugin</h2>
    <br/>


    <button class="success btn btn-success">Success</button>
    <button class="error btn btn-danger">Error</button>
    <button class="info btn btn-info">Info</button>
    <button class="warning btn btn-warning">Warning</button>


</div>  


<script type="text/javascript">


    $(".success").click(function(){
        $.bootstrapGrowl('We do have the Kapua suite available.',{
            type: 'success',
            delay: 2000,
        });
    });


    $(".error").click(function(){
        $.bootstrapGrowl('You Got Error',{
            type: 'danger',
            delay: 2000,
        });
    });


    $(".info").click(function(){
        $.bootstrapGrowl('It is for your kind information',{
            type: 'info',
            delay: 2000,
        });
    });


    $(".warning").click(function(){
        $.bootstrapGrowl('It is for your kind warning',{
            type: 'warning',
            delay: 2000,
        });
    });
</script>


</body>
</html>