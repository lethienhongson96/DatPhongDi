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
                        <td>${v.amountAdults}</td>
                        <td>${v.amountChild}</td>
                        <td>${v.pricePerNight}</td>
                        <td>${v.statusName}</td>
                        <td align="center">
                            <button class="btn btn-info"
                            onclick="typeOfRoom.edit(${v.id},'${v.name}',${v.amountAdults},
                            ${v.amountChild},${v.pricePerNight},${v.status})">Chỉnh sửa</button>
                            <a href="javascript:void(0)" onclick="typeOfRoom.delete(${v.id},${v.status})"
                                class="btn btn-danger"> Xóa
                            </a>
                            <a href="javascript:void(0)" class="btn btn-info" onclick="typeOfRoom.ModalManagementImage(${v.id})">
                                Quản lí ảnh
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

typeOfRoom.ModalManagementImage = function (typeOfRoomId) {
    $("#typeOfRoomId").val(typeOfRoomId);
    $.ajax({
        url: `/TypeOfRoom/getImagesByTypeOfRoomId/${typeOfRoomId}`,
        method: 'GET',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            console.log(response.data);
            for (var i = 0; i < response.data.length; i++) {
                var img = document.createElement("img");
                img.src = 'images/' + response.data[i].imagePath;
                img.width = 200;
                img.height = 200;
                $("#filelist").append(img);
            }
            $("#filelist").children("img").css("margin-right", "10px");
            typeOfRoom.openModalManagementImage();
        }
    });
}

typeOfRoom.ImageArr = [];

typeOfRoom.UploadImages = function () {
    var form_data = new FormData();
    for (var i = 0; i < typeOfRoom.ImageArr.length; i++) {
        form_data.append('Files', typeOfRoom.ImageArr[i]);
    }
    form_data.append('TypeOfRoomId', $("#typeOfRoomId").val());
    //console.log(form_data);
    //var SaveImageObjectReq = {};
    //SaveImageObjectReq.Files = form_data;
    //SaveImageObjectReq.TypeOfRoomId = $("#typeOfRoomId").val();
    //console.log(SaveImageObjectReq);
    $.ajax({
        type: 'POST',
        url: "/typeofroom/UploadImages",
        data: form_data,
        contentType: false,
        dataType: 'json',
        processData: false,
        cache: false,
        success: function (data) {
            console.log(data);
        }
    });
}

$(".selectImage").change(function () {
    var totalfiles = document.getElementById('images').files.length;

    for (var i = 0; i < totalfiles; i++) {
        typeOfRoom.ImageArr.push(document.getElementById('images').files[i])
    }
    console.log(typeOfRoom.ImageArr);
});

typeOfRoom.loadFile = function (event) {
    for (var i = 0; i < document.getElementById('images').files.length; i++) {
        var img = document.createElement("img");
        img.src = URL.createObjectURL(event.target.files[i]);
        img.width = 200;
        img.height = 200;
        $("#newImages").append(img);
    }
    $("#newImages").children("img").css("margin-right", "10px");
};

$('.closeManagementImage').on('click', function () {
    //Close Modal
    $("#ManagementImage").modal("hide");
    //Reset Values
    $("#UploadFile").trigger("reset");
    $("img").remove();
});

typeOfRoom.save = function () {
    if ($('#frmAddEditTypeOfRoom').valid()) {
        var saveObj = {};
        saveObj.id = parseInt($('#Id').val());
        saveObj.name = $('#Name').val();
        saveObj.amountAdults = parseInt($('#AmountAdults').val());
        saveObj.amountChild = parseInt($('#AmountChild').val());
        saveObj.pricePerNight = parseInt($('#PricePerNight').val());
        saveObj.status = parseInt($('#Status').val());
        console.log(saveObj.status);
        $.ajax({
            url: '/typeofroom/Save',
            method: 'PATCH',
            dataType: 'JSON',
            contentType: 'application/json',
            data: JSON.stringify(saveObj),
            success: function (response) {
                console.log(response);
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

typeOfRoom.openModalManagementImage = function () {
    $('#ManagementImage').modal('show');
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