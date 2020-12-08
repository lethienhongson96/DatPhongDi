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
                    `<tr style="text-align:center">
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
                        <td align="center">
                            <a href="javascript:void(0)" class="btn btn-warning"
                                onclick="typeOfRoom.ModalManagementImage(${v.id},'${v.name}')">
                                    Quản lí ảnh
                            </a>
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

typeOfRoom.ModalManagementImage = function (typeOfRoomId, roomtypename) {
    $("#typeOfRoomId").val(typeOfRoomId);
    $("#TypeofroomName").val(roomtypename);
    document.getElementById("TitleManagementImage").innerHTML = "Quản lí ảnh cho loại " + roomtypename;
    $.ajax({
        url: `/TypeOfRoom/getImagesByTypeOfRoomId/${typeOfRoomId}`,
        method: 'GET',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (response) {
            console.log(response.data);
            $("#filelist").empty();
            for (var i = 0; i < response.data.length; i++) {
                var imgdiv = `<div class="imgdiv" style="display: inline-block;width:215;height:215" >`
                imgdiv += `<img src=images/${response.data[i].imagePath} width=200 height=200 />`;
                imgdiv += `<span class="close" style="cursor:pointer"
                        onclick=typeOfRoom.deleteimg(${response.data[i].imageId},${typeOfRoomId},'${response.data[i].imagePath}')>x</span>`;
                imgdiv += `</div>`;
                $("#filelist").append(imgdiv);
            };
            $("#filelist").children("div").css("margin-right", "10px");
            typeOfRoom.openModalManagementImage();
        }
    });
}

typeOfRoom.deleteimg = function (imgid, typeofroomid, imgpath) {
    bootbox.confirm({
        message: "<span class='text-danger'>Xóa ảnh này ?</span>",
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
            if (result) {
                $.ajax({
                    url: `/TypeOfRoom/DeleteImages/${imgid}/${imgpath}`,
                    method: 'GET',
                    dataType: 'JSON',
                    contentType: 'application/json',
                    success: function (response) {
                        if (response.data.imageId > 0) {
                            $("#filelist").empty();
                            typeOfRoom.ModalManagementImage(typeofroomid, $("#TypeofroomName").val());
                        };
                    }
                });
            }
        }
    });
};

typeOfRoom.loadFile = function (event) {
    for (var i = 0; i < document.getElementById('images').files.length; i++) {
        imgdiv = document.createElement("div");
        imgdiv.style.display = "inline-block";
        imgdiv.setAttribute("id", document.getElementById('images').files[i].name);

        var img = document.createElement("img");
        img.src = URL.createObjectURL(event.target.files[i]);
        img.width = 200;
        img.height = 200;

        var closebtn = document.createElement("span");
        closebtn.innerHTML = "x";
        closebtn.className = "close";
        closebtn.style.cursor = "pointer";

        var input = document.createElement("input");
        input.type = "text";
        input.value = document.getElementById('images').files[i].name;
        input.setAttribute("type", "hidden");

        imgdiv.append(img);
        imgdiv.append(closebtn);
        imgdiv.append(input);
        $("#newImages").append(imgdiv);

        closebtn.addEventListener("click", function () {
            typeOfRoom.removeImage(this.parentNode.id);
            this.parentElement.remove();
        });
    }
    $("#newImages").children("div").css("margin-right", "10px");
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
    console.log(typeOfRoom.arr);
}

// 1 khi click vào dịch vụ 
typeOfRoom.ManagementService = function (id) {

    // 2 xuất hiện 1 bảng check service
    typeOfRoom.initService();
    // Lấy tất cả dịch vụ của loại phòng
    typeOfRoom.GetServiceByTypeOfRoomId(id);
    // 3  show ra toàn bộ service
    typeOfRoom.openModalManagementService();
    $("#TypeOfRoomId").val(id);
}

typeOfRoom.openModalManagementService = function () {
    $('#ManagementService').modal('show');
}

$('.closeButton').on('click', function () {
    //Close Modal
    $("#ManagementService").modal("hide");
    //Reset Values
    $("#frmManagementService").trigger("reset");
    typeOfRoom.arr = [];
});

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

typeOfRoom.removeImage = function (filename) {
    var delindex = -1;
    for (var i = 0; i < typeOfRoom.ImageArr.length; i++) {
        if (typeOfRoom.ImageArr[i].name == filename) {
            delindex = i;
            break;
        }
    }
    if (delindex != -1) {
        typeOfRoom.ImageArr.splice(delindex, 1);
    }
    console.log(typeOfRoom.ImageArr);
}

typeOfRoom.ImageArr = [];

typeOfRoom.UploadImages = function () {
    var form_data = new FormData();
    for (var i = 0; i < typeOfRoom.ImageArr.length; i++) {
        form_data.append('Files', typeOfRoom.ImageArr[i]);
    }
    var RoomTypeId = $("#typeOfRoomId").val();
    form_data.append('TypeOfRoomId', RoomTypeId);
    $.ajax({
        type: 'POST',
        url: "/typeofroom/UploadImages",
        data: form_data,
        contentType: false,
        dataType: 'json',
        processData: false,
        cache: false,
        success: function (response) {
            console.log(response.data);
            bootbox.alert('Đả upload ' + response.data + ' ảnh thành công!');
            //Reset Values
            $("#UploadFile").trigger("reset");
            $("#newImages").empty();
            typeOfRoom.ImageArr = [];
            typeOfRoom.ModalManagementImage(RoomTypeId, $("#TypeofroomName").val());
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

$('.closeManagementImage').on('click', function () {
    //Close Modal
    $("#ManagementImage").modal("hide");
    //Reset Values
    $("#UploadFile").trigger("reset");
    $("#newImages").empty();
    $("#filelist").empty();
    typeOfRoom.ImageArr = [];
});

typeOfRoom.deleteService = function (id) {
    $.ajax({
        url: `/typeOfRoomService/delete/${id}`,
        method: 'PATCH',
        dataType: 'JSON',
        contentType: 'application/json',
        success: function (reponse) {
            if (reponse.data > 0) {
                console.log("thanh cong");
            }
        }
    });

}

typeOfRoom.saveService = function () {
    if ($('#frmManagementService').valid()) {
        var formdata = new FormData();
        formdata.append("TypeOfRoomId", parseInt($("#TypeOfRoomId").val()));

        for (var i = 0; i < typeOfRoom.arr.length; i++) {
            if (typeOfRoom.arr[i].checked == true) {
                formdata.append("ServiceId", parseInt(typeOfRoom.arr[i].value));

            }
        }

        typeOfRoom.deleteService($("#TypeOfRoomId").val());

        $.ajax({
            url: '/typeOfRoomService/save',
            method: 'POST',
            dataType: 'JSON',
            contentType: false,
            processData: false,
            data: formdata,
            success: function (response) {
                bootbox.alert(response.data.message);
                if (response.data.id > 0) {
                    $('#ManagementService').modal('hide');
                    $('#frmManagementService').trigger('reset');
                    typeOfRoom.showData();
                }
            }
        });

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
}

typeOfRoom.openModalManagementImage = function () {
    $('#ManagementImage').modal('show');
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