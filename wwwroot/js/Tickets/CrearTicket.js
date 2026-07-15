$(document).ready(function(){
    GetAllCategories();

    $("#category").on('change', function(){
        $("#subcategory").empty();
        $("#failure").empty();
        //$("#subcategory").val("");
        GetAllSubCategories($("#category").val());
    });

    $("#subcategory").on('change', function(){
        $("#failure").empty();
        //$("#failure").val("");
        GetAllFailures($("#subcategory").val());
    });

    //send data
    $("#btn-createticket").on('click', function(){
        CreateTicket();
    });
});

function GetAllCategories(){
    var innerHTML = ""; var id_cat;
    $.ajax({
        async: true,
        url: 'getCategorias',
        type: "GET",
        dataType: "json",
        success: function(data){
            datos = data.category;

            for(let i = 0;i < datos.length; i++){
                innerHTML += "<option value="+ datos[i].id_cat +">"+ datos[i].descripcion +"</option>"
            }
            //console.log(innerHTML);
            $("#category").append(innerHTML);
            GetAllSubCategories($("#category").val());
        },
        error: function(err){
            console.log(err);
        }
    });
}

function GetAllSubCategories(id_cat){
    //console.log(id_cat);
    var innerHTML = "";
    var datos = [];
    $.ajax({
        async: true,
        url: "getSubCategorias",
        type: "GET",
        data: {id_cat: id_cat},
        success: function(data){
            console.log(data)
            datos = data.subcategory;
            for(let i = 0;i < datos.length; i++){
                innerHTML += "<option value="+ datos[i].id_subcat +">"+ datos[i].descripcion +"</option>"
            }
            //console.log(innerHTML);
            $("#subcategory").append(innerHTML);
            GetAllFailures($("#subcategory").val());
        },
        error: function(err){
            console.log(err);
        }
    });
    
}
function GetAllFailures(id_subcat){
    var innerHTML = "";
    $.ajax({
        async: true,
        url: "getFallos",
        type: "GET",
        data: {id_subcat: id_subcat},
        success: function(data){
            datos = data.fallos;
            for(let i = 0;i < datos.length; i++){
                innerHTML += "<option value="+ datos[i].id_fallo +">"+ datos[i].descripcion +"</option>"
            }
            $("#failure").append(innerHTML);
        }
    })
}

function CreateTicket(){
    formData = {
        nomina: $("#nomina").val(),
        title: $("#title").val(),
        id_cat: $("#category").val(),
        id_subcat: $("#subcategory").val(),
        id_failure: $("#failure").val(),
        descripcion: $("#descripcion").val()
    };
    $.ajax({
        async: true,
        url: "CreateNewTicket",
        type: "POST",
        data: formData,
        dataType: "json",
        success: function(data){
            Swal.fire({
                title: "Éxito",
                text: "Se ha creado el ticket con éxito. ID: " + data.id_ticket,
                icon: "success"
            });
        },
        error(err){

        }
    });
}