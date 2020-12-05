var typeOfRoomService = {} || typeOfRoomService;

typeOfRoomService.showData = function () {
    $.ajax({
        url: '/typeOfRoomService/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbTypeOfRoomService>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbTypeOfRoomService>tbody').append(
                    `<tr>
                       <td>${v.id}</td>
                       <td> <option></option></td>
                        <td>${v.typeOfRoomName}</td>
                        <td>
                          <a onclick="typeOfRoomService.Delete(${v.id})"
                               href="javascript:void(0);" title="Delete typeOfRoomService" >
                               <i class='fas fa-trash'></i>
                            </a>
                        </td>
                    </tr>`
                );
            });
        }   
    });
}


typeOfRoomService.save = function () {
    if ($('#frmAddEditTypeOfRoomService').valid()) {
       
        var saveObj = {};
        saveObj.Id = parseInt($('#Id').val());
        //thêm phần tử vào mảng 
        saveObj.ServiceId = [];
        for (var i = 0; i < typeOfRoomService.arr.length; i++) {
            if (typeOfRoomService.arr[i].checked == true) {
                saveObj.ServiceId.push(parseInt(typeOfRoomService.arr[i].value));
            }
        }
        saveObj.TypeOfRoomId = parseInt($('#TypeOfRoomId').val());
        $.ajax({
            url: '/typeOfRoomService/save',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.id > 0) {
                    $('#addEdittypeOfRoomServiceModal').modal('hide');
                    $('#frmAddEdittypeOfRoomService').trigger('reset');
                    typeOfRoomService.showData();
                }
            }
        });
    }
}

typeOfRoomService.initTypeOfRoom = function (TypeOfRoomId) {
    $.ajax({
        url: '/typeOfRoomService/GetTypeofrooms',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#TypeOfRoomId').empty();
            $.each(response.data, function (i, v) {
                $('#TypeOfRoomId').append(
                    `<option value=${v.id}>${v.name}</option>`
                );
                if (TypeOfRoomId != null) {
                    $('#TypeOfRoomId').val(TypeOfRoomId);
                }
            });
        }
    });
}

typeOfRoomService.initService = function () {
  
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
                typeOfRoomService.arr.push(document.getElementById(v.id));
            });
        }
    });
}

typeOfRoomService.arr = [];

typeOfRoomService.openModal = function () {
    $('#addEditTypeOfRoomServiceModal').modal('show');
}

typeOfRoomService.init = function () {
    typeOfRoomService.initService();
    typeOfRoomService.initTypeOfRoom();
    typeOfRoomService.select();
    typeOfRoomService.showData();
}

$(document).ready(function () {
    typeOfRoomService.init();
});

$('#Close').on('click', function () {
    $('#addEdittypeOfRoomServiceModal').modal('hide');
    $('#frmAddEdittypeOfRoomService').trigger('reset');
})

typeOfRoomService.Delete = function (id) {
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
                    url: `/typeOfRoomService/delete/${id}`,
                    method: 'GET',
                    dataType: 'json',
                    success: function (response) {
                        if (response.data.id > 0) {
                            window.location.href = "/typeOfRoomService/Index/";
                        }
                        else {
                            bootbox.alert({
                                message: "Something wrong",
                                callback: function () {
                                    window.location.href = "/typeOfRoomService/Index/";
                                }
                            })
                        }
                    }
                });
            }
        }
    });
}