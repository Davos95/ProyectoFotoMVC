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
        
        //for (var i = 0; i < arrayImages.length; i++) {
            
        //    var image = arrayImages[i];
        //    var reader = new FileReader();
        //    reader.onload = function (e) {
        //        var pic = e.target;
        //        $("#div").append("<img src='" + pic.result + "' style='width: 150px; height: 150px'>");
        //    }
        //    reader.readAsDataURL(image);
        //}
        
    });

     $("#files").change(function(e) {
         console.log("cerrado"); 
         arrayImages = e.target.files;
    });

    $("#send").click(function () {
        var sesion = $("#sesion").val();
        console.log(sesion);
        uploadData(arrayImages, sesion);
        
    });

});


function uploadData(arrayImages, sesion) {

    var formData = new FormData();
    for (var i = 0; i < arrayImages.length; i++) {
        formData.append("File"+i, arrayImages[i]);
    }

    formData.append("idSesion", sesion);
    
    $.ajax({
        type: "POST",
        url: "/Images/Upload",
        data: formData,
        contentType: false,
        processData: false,
        beforeSend: function () {
            $("#loading").fadeIn(100);
        },
        success: function(data){
            console.log(data);
            setTimeout(function () {
                $("#loading").fadeOut(100);
                Swal.fire({
                    title: 'Completado!',
                    text: "Las imagenes se han subido correctamente. Quieres ir a gestionarlas?",
                    type: 'success',
                    showCancelButton: true,
                    confirmButtonColor: '#4caf50',
                    cancelButtonColor: '#f44336 ',
                    confirmButtonText: 'Aceptar',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.value) {
                        window.location = '/Sesion/ManagePhotos?idSesion=' + sesion;

                        //$("#divLink").html('<a id="goSession" href="/Sesion/ManagePhotos?idSesion='+sesion+'">link</a>');
                        //$("#goSession").click();
                    }
                })
            },1000);
            
        }
    });

}