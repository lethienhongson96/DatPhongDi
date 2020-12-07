$(document).ready(function () {
/*create array image*/
    var imageArr = [];
    /*create array id processbar*/
    $(".selectImage").change(function () {
        var totalfiles = document.getElementById('images').files.length;
        var form_data = new FormData();
        
        for (var i = 0; i < totalfiles; i++) {
            imageArr.push(document.getElementById('images').files[i])
        }
        console.log(imageArr);
    });
});