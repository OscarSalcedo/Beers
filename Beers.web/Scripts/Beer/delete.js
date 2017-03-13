
var onDeleteHandlerClick = function (id,controller) {
    confirmWindow(id, controller);
}

var confirmWindow = function (id, controller) {

    var resultConfirm = confirm("Seguro que deseas eliminar este elemento?");

    if(resultConfirm){
        //var href = $('#DeleteHandler').attr("href");
        deleteFunc(id, controller);
    }
}

var deleteFunc = function (id, controller) {
    //alert(url)

    //var cadena = href.split("/");
    //var controller = cadena[1];
    //var action = cadena[2];
    //var id = cadena[3];

    //"/" + { controller }+ "/" + { action }
    //http://localhost:51886/Beer/Delete/
    var url = '/'+ controller + '/Delete/' 
    $.ajax({
        url: url,
        type: 'DELETE',
        data: {id},
        success: function (data) {
            // Do something with the result
            location.reload();
        }
    });
}



//$('#DeleteHandler').click(onDeleteHandlerClick);