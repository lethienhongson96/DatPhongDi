

$('#btn-submit').on('click', function (event) {
    event.preventDefault();
    var saveObj = {};
    saveObj.id = 0;
    saveObj.name = $('#Name').val();
    saveObj.email = $('#Email').val();
    saveObj.phoneNum = $('#PhoneNum').val();
    saveObj.address = $('#Address').val();
    saveObj.country = $('#Country').val();
    saveObj.passport = $('#Passport').val();
    console.log(saveObj);
    $.ajax({
        url: '/customer/payment',
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        data: JSON.stringify(saveObj),
        success: function (response) {
            alert(response.data.message);
        }
    });
})


//$('#input-button').on("click", function () {
//    console.log(JSON.parse(sessionStorage.getItem('bookingdate')));
//})