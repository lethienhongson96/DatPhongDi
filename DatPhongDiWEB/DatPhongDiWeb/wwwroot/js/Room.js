
var room = {} || room;

room.showData = function () {
    $.ajax({
        url: '/room/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbRoom>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbRoom>tbody').append(
                    `<tr>
                        <td>${v.id}</td>
                        <td>${v.name}</td>                     
                        <td>${v.statusName}</td>
                        <td>${v.typeOfRoomName}</td>
                        <td>${v.description}</td>
                        <td>${v.size}</td>
                        <td>${v.createDateStr}</td>
                        <td>${v.modifiedDateStr}</td>
                        <td>
                            <a href="javascript:void(0);" title="Edit Room"
                                onclick="room.Edit(${v.id},${v.name},'${v.status}','${v.typeOfRoomId}',
                                '${v.description}',${v.size})">
                                <i class="far fa-eye"></i>
                            </a>||
                            <a onclick="room.Delete(${v.id})"
                               href="javascript:void(0);" title="Delete Room" >
                               <i class='fas fa-trash'></i>
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

room.Edit = function (id, name, statusName, typeOfRoomName, description, size) {
    $('#RoomId').val(id);
    $('#Name').val(name);
    room.initStatus(statusName);
    room.TypeOfRoom(typeOfRoomName);
    $('#Description').val(description);
    $('#Size').val(size);
    room.openModal();
}

room.openModal = function () {
    $('#addEditRoomModal').modal('show');
}

room.init = function () {
    room.showData();
    room.initStatus();
    room.TypeOfRoom();
}
$(document).ready(function () {
    room.init();
});

room.save = function () {
    if ($('#frmAddEditRoom').valid()) {
        var saveObj = {};
        saveObj.id = parseInt($('#RoomId').val());
        saveObj.name = parseInt($('#Name').val());
        saveObj.status = parseInt($('#Status').val());
        saveObj.TypeOfRoomId = parseInt($('#TypeOfRoomId').val());
        saveObj.description = $('#Description').val();
        saveObj.size = parseInt($('#Size').val());
        $.ajax({
            url: '/room/saveroom',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                $('#frmAddEditRoom').trigger('reset');
                $('#addEditRoomModal').modal('hide');
                bootbox.alert({
                    message: response.data.message,
                    callback: function () {
                        room.showData();
                    }
                })

            }
        });
    }
}


room.TypeOfRoom = function (TypeOfRoomId) {
    $.ajax({
        url: '/room/GetTypeofrooms',
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

$('#Close').on('click', function () {
    $('#addEditRoomModal').modal('hide');
    $('#frmAddEditRoom').trigger('reset');
})

room.initStatus = function (status) {
    $.ajax({
        url: '/room/Status/Gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#Status').empty();
            $.each(response.data, function (i, v) {
                $('#Status').append(
                    `<option value=${v.id}>${v.name}</option>`
                );
                if (status != null) {
                    $('#Status').val(status);
                }
            });
        }
    });
}

room.Delete = function (id) {
    bootbox.confirm({
        message: "Delete <span class='text-danger'>" + "Bạn có chắc" + "</span> ?",
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
                    url: `/room/delete/${id}`,
                    method: 'GET',
                    dataType: 'json',
                    success: function (response) {
                        if (response.data.id > 0) {
                            window.location.href = "/room/Index/";
                        }
                        else {
                            bootbox.alert({
                                message: "Something wrong",
                                callback: function () {
                                    window.location.href = "/room/Index/";
                                }
                            })
                        }
                    }
                });
            }
        }
    });
}
