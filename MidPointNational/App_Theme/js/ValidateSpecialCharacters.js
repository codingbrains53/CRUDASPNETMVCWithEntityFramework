//Validation for character string...
function ValidateSpecialCharacter(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    //alert(charCode);
    if (charCode != 46 && charCode != 32 && charCode != 95 && charCode != 08 && (charCode < 97 || charCode > 122) && (charCode < 64 || charCode > 90) && (charCode < 44 || charCode > 57) || charCode == 190) {
        alert("Please enter valid data");
        return false;               
    }
}
//**************************************************//

//Valdation for numeric fields
function ValidateNumericField(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    
    if (charCode != 46 && charCode != 32 && charCode != 95 && charCode != 08 && (charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90) && (charCode < 44 || charCode > 57) || charCode == 190) {
        alert("Please enter valid data");
        return false;        
    }
}
//*************************************************//