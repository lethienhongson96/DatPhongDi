
var booking = {} || booking;

booking.showData = function () {
    $.ajax({
        url: '/module/gets',
        method: 'GET',
        dataType: 'JSON',
        success: function (response) {
            $('#tbModule>tbody').empty();
            $.each(response.data, function (i, v) {
                $('#tbModule>tbody').append(
                    `<tr>
                        <td>${v.moduleId}</td>
                        <td>${v.moduleName}</td>
                        <td>${v.duration}</td>
                        <td>${v.statusName}</td>
                        <td>
                            <button class="btn btn-info"
                            onclick="module.edit(${v.moduleId},'${v.moduleName}',${v.duration},${v.status})">Edit</button>
                            <a href="javascript:void(0)" onclick="module.delete(${v.moduleId},'${v.moduleName}')"
                                class="btn btn-danger"> Delete
                            </a>
                        </td>
                    </tr>`
                );
            });
        }
    });
}

booking.init = function () {
    booking.showData();
    booking.initStatus();
}

$(document).ready(function () {
    booking.init();
});