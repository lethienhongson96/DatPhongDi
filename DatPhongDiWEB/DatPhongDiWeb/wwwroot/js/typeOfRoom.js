var typeOfRoom = {} || typeOfRoom;

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
                        <td>${v.statusName}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="module.edit(${v.moduleId},'${v.moduleName}',${v.duration},${v.status})">Chỉnh sửa</button>
                            <a href="javascript:void(0)" onclick="module.delete(${v.moduleId},'${v.moduleName}')"
                                class="btn btn-danger"> Xóa
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

typeOfRoom.save = function () {
    if ($('#frmAddEditTypeOfRoom').valid()) {
        var saveObj = {};
        saveObj.id = parseInt($('#Id').val());
        saveObj.name = $('#Name').val();
        saveObj.status = parseInt($('#Status').val());
        $.ajax({
            url: '/typeofroom/Save',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.moduleId > 0) {
                    $('#addEditTypeOfRoomModal').modal('hide');
                    $("#frmAddEditTypeOfRoom").trigger("reset");
                    typeOfRoom.showData();
                }
            }
        });
    }
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
                    `<option value=${v.status}>${v.statusName}</option>`
                );
                $('#Status').val(defaultStatus);
            });
        }
    });
}

typeOfRoom.openModal = function () {
    $('#addEditTypeOfRoomModal').modal('show');
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