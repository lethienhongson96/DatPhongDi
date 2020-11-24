var booking = {} || booking;

booking.showData = function () {
    $.ajax({
        url: '/booking/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbBooking>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbBooking>tbody').append(
                    `<tr>
                        <td>${v.id}</td>
                        <td>${v.roomId}</td>
                        <td>${v.customerId}</td>
                        <td>${v.amountNight}</td>
                        <td>${v.checkInStr}</td>
                        <td>${v.checkOutStr}</td>
                        <td>${v.createDateStr}</td>
                        <td>${v.StatusName}</td>
                    </tr>`
                );
            });
        }
    });
}


booking.init = function () {
    booking.showData();
    //booking.initStatus();
}

$(document).ready(function () {
    booking.init();
});