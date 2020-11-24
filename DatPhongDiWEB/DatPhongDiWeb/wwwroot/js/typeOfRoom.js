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

typeOfRoom.openModal = function () {
    $('#addEditTypeOfRoomModal').modal('show');
}

$('#closeButton').on('click', function () {
    //Close Modal
    $(".modal").modal("hide");
    //Reset Values
    $("#frmAddEditModule").trigger("reset");
});


typeOfRoom.init = function () {
    typeOfRoom.showData();
    //typeOfRoom.initStatus();
}

$(document).ready(function () {
    typeOfRoom.init();
});