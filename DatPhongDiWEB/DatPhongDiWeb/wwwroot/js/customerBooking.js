var customerBooking = {} || customerBooking;

customerBooking.saveCustomerInfo = function (event) {
    event.preventDefault();
    var saveObj = {};
    saveObj.id = 0;
    saveObj.name = $('#Name').val();
    saveObj.email = $('#Email').val();
    saveObj.phoneNum = $('#PhoneNum').val();
    saveObj.address = $('#Address').val();
    saveObj.country = $('#Country').val();
    saveObj.passport = $('#Passport').val();
    $.ajax({
        url: '/customer/payment',
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        data: JSON.stringify(saveObj),
        success: function (response) {
            if (parseInt(response.data.id) > 0) {
                customerBooking.saveBooking(parseInt(response.data.id));
            }
        }
    });
}

customerBooking.saveBooking = function (customerId) {
    var bookingdate = JSON.parse(sessionStorage.getItem('bookingdate'));
    var saveObj = {};
    saveObj.id = 0;
    saveObj.customerId = customerId;
    saveObj.amountNight = bookingdate.amountnight;
    saveObj.checkIn = new Date(bookingdate.checkindate);
    saveObj.checkIn.setDate(saveObj.checkIn.getDate() + 1);

    saveObj.checkOut = new Date(bookingdate.checkoutdate);
    saveObj.checkOut.setDate(saveObj.checkOut.getDate() + 1);
    saveObj.status = 3;

    $.ajax({
        url: '/Booking/save',
        method: 'POST',
        dataType: 'JSON',
        contentType: 'application/json',
        data: JSON.stringify(saveObj),
        success: function (response) {
            return response.data.message;
        }
    });
}


//$('#input-button').on("click", function () {
//    console.log(JSON.parse(sessionStorage.getItem('bookingdate')));
//})