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
                        <td>${v.serviceName}</td>                     
                        <td>${v.typeOfRoomName}</td>
                        <td>
                           dd
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
        saveObj.id = parseInt($('#Id').val());
        saveObj.serviceId = parseInt$('#ServiceId').val();
        saveObj.typeOfRoomId = parseInt$('#TypeOfRoomId').val();
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

typeOfRoomService.openModal = function () {
    $('#addEditTypeOfRoomServiceModal').modal('show');
}

typeOfRoomService.init = function () {
    typeOfRoomService.showData();
}

$(document).ready(function () {
    typeOfRoomService.init();
});

$('#Close').on('click', function () {
    $('#addEdittypeOfRoomServiceModal').modal('hide');
    $('#frmAddEdittypeOfRoomService').trigger('reset');
})