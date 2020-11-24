var service = {} || service;

service.showData = function () {
    $.ajax({
        url: '/service/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbService>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbService>tbody').append(
                    `<tr>
                        <td>${v.id}</td>
                        <td>${v.name}</td>
                        <td>${v.icon}</td>
                        <td>${v.statusName}</td>
                        <td><a href="javascript:void(0);" class="btn btn-success"
                        onclick="service.Update(${v.id},'${v.name}',${v.icon},'${v.statusName}')">Chỉnh sửa</a>
                        <a href="javascript:void(0);" class="btn btn-warning"
                        onclick="service.Delete(${v.id},'${v.name}')">Xóa</a></td>
                    </tr>`
                );
            });
        }
    });
}

service.Update = function (id, name, icon, statusName) {
    $('#Id').val(id);
    $('#Name').val(name);
    $('#Icon').val(icon);
    $('#Status').val(statusName);
    service.initStatus();
    service.openModal();

}

service.openModal = function () {
    $('#addEditServiceModal').modal('show');
}

service.initStatus = function () {
    $.ajax({
        url: '/service/status/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#Status').empty();
            $.each(response.data, function (i, v) {
                $('#Status').append(
                    `<option value=${v.id}>${v.name}</option>`
                );
            });
        }
    });
}

service.save = function () {
    if ($('#formAddEditService').valid()) {
        var saveObj = {};
        saveObj.id = parseInt($('#Id').val());
        saveObj.name = $('#Name').val();
        saveObj.icon = parseInt($('#Icon').val());
        saveObj.statusName = parseInt($('#Status').val());
        $.ajax({
            url: '/service/save',
            method: 'POST',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.moduleId > 0) {
                    $('#addEditServiceModal').modal('hide');
                    $('#formAddEditService').trigger('reset');
                    service.showData();

                }
            }
        });
    }
}

$('#Close').on('click', function () {
    $('#addEditServiceModal').modal('hide');
    $('#formAddEditService').trigger('reset');
})


service.init = function () {
    service.showData();
    service.initStatus();
}

$(document).ready(function () {
    service.init();
});

service.Delete = function (id, name) {
    bootbox.confirm({
        message: "Bạn có chắc chắn muốn xóa ? <span class='text-danger'>" + name + "</span>",
        buttons: {
            cancel: {
                label: 'No',
                className: 'btn-danger'
            },
            confirm: {
                label: 'Yes',
                className: 'btn-success'
            }
        },
        callback: function (result) {
            if (result) {
                service.showData();
                //window.location.href = "Module/Delete?id=" + id;
                bootbox.alert("Xóa thành công ");
            }
        }
    });
};
