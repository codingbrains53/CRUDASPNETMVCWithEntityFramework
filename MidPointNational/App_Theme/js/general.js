$(document).ready(function () {
    $("#MainContent_txtForOTPInput1").keyup(function (e) {
       // alert("san");
        if (this.value.length == this.maxLength) {            
            $("#MainContent_txtForOTPInput2").focus();
        }
    });

    $("#MainContent_txtForOTPInput2").keyup(function (e) {        
        if (this.value.length == this.maxLength) {            
            $("#MainContent_txtForOTPInput3").focus();
        }
    });

    $("#MainContent_txtForOTPInput3").keyup(function (e) {        
        if (this.value.length == this.maxLength) {            
            $("#MainContent_txtForOTPInput4").focus();
        }
    });


 
});