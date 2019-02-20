$(document).ready(function () {
    var arrayImages;

     $("#drop-area").on('dragenter', function (e){
      e.preventDefault();
         $(this).css('border-color', '#81c784');
     });

    $("#drop-area").on('dragleave', function (e) {
        e.preventDefault();
        $(this).css('border-color', 'grey');
    });

    $("#drop-area").on('dragover', function (e){
        e.preventDefault();
    });

    $("#drop-area").on('drop', function (e){
        $(this).css('background', '#D8F9D3');
        e.preventDefault();
        arrayImages = e.originalEvent.dataTransfer.files;
        console.log(arrayImages);
        
        for (var i = 0; i < arrayImages.length; i++) {
            
            var image = arrayImages[i];
            var reader = new FileReader();
            reader.onload = function (e) {
                var pic = e.target;
                $("#div").append("<img src='" + pic.result + "' style='width: 150px; height: 150px'>");
            }
            reader.readAsDataURL(image);
        }
        
    });

     $("#files").change(function(e) {
         console.log("cerrado"); 
         arrayImages = e.target.files;
    });

    $("#send").click(function () {
        var sesion = $("#sesion").val();
        uploadData(arrayImages, sesion);
        
    });

});


function uploadData(arrayImages, sesion) {
    var values = {"images": arrayImages, "sesion": sesion}
    $.ajax({
        type: "POST",
        url: "upload_image.php",
        data: values,
        contentType:false,
        cache: false,
        processData: false,
        success: function(data){
            $('#drop-area').html(data);
        }
    });
}