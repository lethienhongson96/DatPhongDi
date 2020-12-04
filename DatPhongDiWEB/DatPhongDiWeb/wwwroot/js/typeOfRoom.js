﻿var typeOfRoom = {} || typeOfRoom;

typeOfRoom.showData = function () {
    $.ajax({
        url: '/TypeOfRoom/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbTypeOfRoom>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbTypeOfRoom>tbody').append(
                    `<tr>
                        <td>${v.id}</td>
                        <td>${v.name}</td>
                        <td>${v.amountAdults}</td>
                        <td>${v.amountChild}</td>
                        <td>${v.pricePerNight}</td>
                        <td><a href="javascript:void(0)" onclick="typeOfRoom.ManagementService(${v.id})"
                                class="btn btn-danger"> Dịch vụ
                            </a>
                        </td>
                        <td>${v.statusName}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="typeOfRoom.edit(${v.id},'${v.name}',${v.amountAdults},
                            ${v.amountChild},${v.pricePerNight},${v.status})">Chỉnh sửa</button>
                            <a href="javascript:void(0)" onclick="typeOfRoom.delete(${v.id},${v.status})"
                                class="btn btn-danger"> Xóa
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

typeOfRoom.arr = [];

typeOfRoom.initService = function () {
    $.ajax({
        url: '/typeOfRoomService/GetsService',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#ServiceId').empty();
            $.each(response.data, function (i, v) {
                $('#ServiceId').append(
                    `<input id=${v.id} type="checkbox" value=${v.id}>
                    <label>${v.name}</label><br>
                    `
                );
                typeOfRoom.arr.push(document.getElementById(v.id));
            });
        }
    });
}
var idRoom = 0;
// 1 khi click vào dịch vụ 
typeOfRoom.ManagementService = function (id) {
    idRoom = id;
    // 2 xuất hiện 1 bảng check service
    typeOfRoom.initService();
    // Lấy tất cả dịch vụ của loại phòng
    typeOfRoom.GetServiceByTypeOfRoomId(id);
    // 3  show ra toàn bộ service
    typeOfRoom.openModalManagementService();
}

typeOfRoom.openModalManagementService = function () {
    $('#ManagementService').modal('show');
}

typeOfRoom.GetServiceByTypeOfRoomId = function (id) {
    $.ajax({
        url: `/typeofroom/GetServiceByRoomtypeId/${id}`,
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            var ServiceArr = [];

            $.each(response.data, function (i, v) {
                ServiceArr.push(v.id);
            });

            for (var i = 0; i < typeOfRoom.arr.length; i++) {
                for (var j = 0; j < ServiceArr.length; j++) {
                    if (typeOfRoom.arr[i].value == ServiceArr[j]) {
                        typeOfRoom.arr[i].checked = true;
                        break;
                    }
                }
            }
        }
    });
}

//Demo//
typeOfRoom.saveService = function () {
    if ($('#frmManagementService').valid()) {

        var saveObj = {};
        saveObj.TypeOfRoomId = idRoom;
        //thêm phần tử vào mảng 
        saveObj.ServiceId = [];
        for (var i = 0; i < typeOfRoom.arr.length; i++) {
            if (typeOfRoom.arr[i].checked == true) {
                saveObj.ServiceId.push(parseInt(typeOfRoom.arr[i].value));
            }
        }
        $.ajax({
            url: '/typeOfRoomService/save',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.id > 0) {
                    $('#addEditTypeOfRoomModal').modal('hide');
                    $('#frmManagementService').trigger('reset');

                    typeOfRoom.showData();
                }
            }
        });
        console.log(saveObj.TypeOfRoomId);
    }
}

typeOfRoom.save = function () {
    if ($('#frmAddEditTypeOfRoom').valid()) {
        var saveObj = {};
        saveObj.id = parseInt($('#Id').val());
        saveObj.name = $('#Name').val();
        saveObj.amountAdults = parseInt($('#AmountAdults').val());
        saveObj.amountChild = parseInt($('#AmountChild').val());
        saveObj.pricePerNight = parseInt($('#PricePerNight').val());
        saveObj.status = parseInt($('#Status').val());
        console.log(status);
        $.ajax({
            url: '/typeofroom/Save',
            method: 'PATCH',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.id > 0) {
                    $('#addEditTypeOfRoomModal').modal('hide');
                    $("#frmAddEditTypeOfRoom").trigger("reset");
                    typeOfRoom.showData();
                }
            }
        });
    }
}

typeOfRoom.delete = function (id) {
    bootbox.confirm({
        message: "Bạn có chắc chắn muốn xóa loại phòng này không <span class='text-danger'></span> ?",
        buttons: {
            confirm: {
                label: 'Có',
                className: 'btn-success'
            },
            cancel: {
                label: 'Không',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            var saveObj = {};
            saveObj.id = parseInt(id);
            saveObj.status = 2;
            console.log(saveObj);
            if (result) {
                $.ajax({
                    url: `/typeofroom/delete`,
                    method: 'PATCH',
                    dataType: 'JSON',
                    contentType: 'application/json',
                    data: JSON.stringify(saveObj),
                    success: function (response) {
                        bootbox.alert(`<h4 class="alert alert-danger">Xóa thành công !!!</h4>`);
                        if (response.data.id > 0) {
                            $('#addEditTypeOfRoomModal').modal('hide');
                            $("#frmAddEditTypeOfRoom").trigger("reset");
                            typeOfRoom.showData();
                        }
                    }
                });
            }
        }
    });
}

typeOfRoom.edit = function (id, name, amountAdults, amountChild, pricePerNight, status) {
    $("#Id").val(id);              
    $("#Name").val(name);                   
    $("#AmountAdults").val(amountAdults);
    $("#AmountChild").val(amountChild);
    $("#PricePerNight").val(pricePerNight);
    $("#Status").val(status);
    typeOfRoom.initStatus(status);
    typeOfRoom.openModal();
    //document.getElementById('st').style.display = 'none';
    //$("#st").hide();
}

typeOfRoom.initStatus = function (defaultStatus) {
    $.ajax({
        url: '/TypeOfRoom/status/gets',
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

typeOfRoom.openModal = function () {
    $('#addEditTypeOfRoomModal').modal('show');
    //$("#st").show();
}

$('#closeButton').on('click', function () {
    //Close Modal
    $(".modal").modal("hide");
    //Reset Values
    $("#frmAddEditTypeOfRoom").trigger("reset");
});


typeOfRoom.init = function () {
    typeOfRoom.showData();
    typeOfRoom.initStatus();
}

$(document).ready(function () {
    typeOfRoom.init();
});