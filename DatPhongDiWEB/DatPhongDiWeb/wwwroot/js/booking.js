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
                        <td>${v.roomId}</td>
                        <td>${v.customerId}</td>
                        <td>${v.amountNight}</td>
                        <td>${v.checkInStr}</td>
                        <td>${v.checkOutStr}</td>
                        <td>${v.createDateStr}</td>
                        <td>${v.statusName}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="booking.edit()">Edit</button>
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

booking.edit = function (moduleId, moduleName, duration, status) {
    $("#ModuleName").val(moduleName);
    $("#Duration").val(duration);
    $("#ModuleId").val(moduleId);
    module.initStatus(status);
    module.openModal();
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
                                    window.location.href = "/module/Index/";
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
    //booking.initStatus();
}

$(document).ready(function () {
    booking.init();
});