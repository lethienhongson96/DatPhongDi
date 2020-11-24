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
                        <td>${v.roomName}</td>
                        <td>${v.customerName}</td>
                        <td>${v.amountNight}</td>
                        <td>${v.checkInStr}</td>
                        <td>${v.checkOutStr}</td>
                        <td>${v.createDateStr}</td>
                        <td>${v.statusName}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="booking.edit(${v.id},${v.roomId},${v.customerId},${v.amountNight},${v.status},'${v.roomName}','${v.customerName}')">
                            Edit</button>
                            <a href="javascript:void(0)" onclick="booking.delete(${v.id})"
                                class="btn btn-danger"> Delete
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

booking.edit = function (id, roomId, customerId, amountNight, status, roomName, customerName) {
    $("#id").val(id);
    $("#roomId").val(roomName);
    $("#customerId").val(customerName);
    $("#amountNight").val(amountNight);
    $("#Status").val(status);
    booking.initStatus(status);
    console.log(status);
    booking.openModal();
}

booking.initStatus = function (defaultStatus) {
    $.ajax({
        url: '/status/getstatusbytableid/'+3,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#Status').empty();
            $.each(response.data, function (i, v) {
                $('#Status').append(
                    `<option value=${v.id}>${v.name}</option>`
                );
                $('#Status').val(defaultStatus);
            });
        }
    });
}

booking.openModal = function () {
    $('#addEditBookingModal').modal('show');
}

booking.delete = function (id) {
    bootbox.confirm({
        message: "Delete <span class='text-danger'>"+"Bạn có chắc"+"</span> ?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            },
            cancel: {
                label: 'No',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Booking/delete/${id}`,
                    method: 'GET',
                    dataType: 'json',
                    success: function (response) {
                        if (response.data.id>0) {
                            window.location.href = "/Booking/Index/";
                        }
                        else {
                            bootbox.alert({
                                message: "Something wrong",
                                callback: function () {
                                    window.location.href = "/Booking/Index/";
                                }
                            })
                        }
                    }
                });
            }
        }
    });
}


booking.init = function () {
    booking.showData();
    booking.initStatus();
}

$(document).ready(function () {
    booking.init();
});