var booking = {} || booking;


booking.showData = function () {
    $.ajax({
        url: '/booking/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbBooking>tbody').empty();
            console.log(response.data);
            $.each(response.data, function (i, v) {
                $('#tbBooking>tbody').append(
                    `<tr>
                        <td>${v.customerId}</td>                        
                        <td>${v.checkInStr}</td>
                        <td>${v.checkOutStr}</td>
                        <td>${v.createDateStr}</td>
                        <td>${v.statusName}</td>
                        <td>${v.totalPrice}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="booking.edit(${v.id},${v.customerId},${v.status},'${v.totalPrice}',
                                                    '${v.customerName}','${v.checkInStr}','${v.checkOutStr}')">
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

//khi bấm vào nút edit thì đưa dữ liệu vào các thẻ thành phần ở trong form edit
booking.edit = function (id,  customerId, status, totalPrice, customerName, checkInStr, checkOutStr) {
    $("#id").val(id);
    $("#totalPrice").val(totalPrice);
    $("#customerName").val(customerName);   
    $("#Status").val(status);
    $("#customerId").val(customerId);

    document.getElementById("checkin").defaultValue = checkInStr;
    document.getElementById("checkout").defaultValue = checkOutStr;

    booking.initStatus(status);
    booking.openModal();
}

//lưu tất cả thay đổi ở trong form và gửi yêu cầu lên server để update dữ liệu
booking.save = function () {
    if ($('#frmAddEditBooking').valid()) {
        var saveObj = {};
        saveObj.Id = parseInt($('#id').val());
        saveObj.RoomId = parseInt($('#room').val());
        saveObj.CustomerId = parseInt($('#customerId').val());       
        saveObj.Status = parseInt($('#Status').val());
        saveObj.CheckIn = $('#checkin').val();
        saveObj.CheckOut = $('#checkout').val();

        $.ajax({
            url: '/Booking/save',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                $('#addEditBookingModal').modal('hide');
                bootbox.alert({
                    message: response.data.message,
                    callback: function () {
                        window.location.href = "/Booking/Index/";
                    }
                })
            }
        });
    }
}

//lấy dử liệu status của booking,với tableId=3 và đổ dử liệu vào dropdown status
booking.initStatus = function (defaultStatus) {
    $.ajax({
        url: '/Booking/Status/Gets',
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

//lấy những phòng có trạng thái đang hoạt động, và đổ dử liệu vào dropdown room
booking.initroom = function (defaultroom) {
    $.ajax({
        url: '/room/gets/',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#room').empty();
            $.each(response.data, function (i, v) {
                $('#room').append(
                    `<option value=${v.id}>${v.name}</option>`
                );
                $('#room').val(defaultroom);
            });
        }
    });
}

//mở form edit lên
booking.openModal = function () {
    $('#addEditBookingModal').modal('show');
}

//xóa booking là chuyển booking đó sang trạng thái đã hủy
booking.delete = function (id) {
    bootbox.confirm({
        message: "<span class='text-danger'>" + "Bạn có chắc" + "</span> ?",
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
                        if (response.data.id > 0) {
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
    booking.initroom();
}

$(document).ready(function () {
    booking.init();
});