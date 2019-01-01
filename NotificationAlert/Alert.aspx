<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alert.aspx.cs" Inherits="NotificationDemo.Alert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        function ShowSuccessAlert() {
            //swal("Hello world!");
            // swal("Successfully!", "Your details save sucssfully!", "success");

            swal({
                title: "Good job!",
                text: "Your details save sucssfully!",
                icon: "success",
            });
        }

        function ShowDeletedAlert() {
            swal({
                title: "Are you sure?",
                text: "Once deleted, you will not be able to recover this imaginary file!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        swal("Poof! Your imaginary file has been deleted!", {
                            icon: "success",
                        });
                    } else {
                        swal("Your imaginary file is safe!");
                    }
                });

        }


        function ShowOKAlert() {
            swal({
                icon: "success",
                text: "",
                value: true,
                visible: true,
                className: "",
                closeModal: true,
            })
        }

        function ShowConfirmAlert() {
            swal({

                icon: "warning",
                text: "Do you want to sure",
                value: true,
                visible: true,
                buttons: {
                    cancel: true,
                    confirm: true,
                },
            })
        }

        function ShowWarningAlert() {
            swal({
                icon: "error",
                text: "Opps.!! Your password not change successfully, Due to some technical problems",
                value: true,
                visible: true,
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button type="button" name="button" class="btn btn-success" onclick="ShowSuccessAlert()">Success</button>
            <button type="button" name="button" class="btn btn-warning" onclick="ShowWarningAlert()">Warning </button>
            <button type="button" name="button" class="btn btn-success" onclick="ShowDeletedAlert()">Deleted </button>
            <button type="button" name="button" class="btn btn-success" onclick="ShowOKAlert()">OK </button>
            <button type="button" name="button" class="btn btn-success" onclick="ShowConfirmAlert()">Confirm </button>
        </div>
    </form>
</body>
</html>
