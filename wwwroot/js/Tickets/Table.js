const days = ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"];
const months = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];

$(document).ready(function(){
    //GetTableTickets()
    GetAllCategories();
    GetAllPrioridades();
    GETAllEstatus();
    SetFormatDate();

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
    $("#generate-report").on('click', function(){
        GetAllTicketTable();
        $("#table-tickets").empty();
    })
});

function SetFormatDate(){
    $('#dates').daterangepicker({
    opens: 'left',
    "locale": {
        "format": "DD/MM/YYYY",
        "daysOfWeek": days,
        "monthNames": months
    }
  });
}

function GetAllCategories(){
    var innerHTML = ""; var id_cat;
    innerHTML += "<option value=0>Todos</option>";
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
    innerHTML += "<option value=0>Todos</option>";
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
    innerHTML += "<option value=0>Todos</option>";
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
function GetAllPrioridades(){
    var innerHTML = "";
    innerHTML += "<option value=0>Todos</option>";
    $.ajax({
        async: true,
        url: "getPrioridad",
        type: "GET",
        success: function(data){
            datos = data.prioridades;
            for(let i = 0;i < datos.length; i++){
                innerHTML += "<option value="+ datos[i].id_prioridad +">"+ datos[i].descripcion +"</option>"
            }
            $("#priority").append(innerHTML);
        },
        error: function(error){

        }
    });
}
function GETAllEstatus(){
    var innerHTML = "";
    innerHTML += "<option value=0>Todos</option>";
    $.ajax({
        async: true,
        url: "getEstatus",
        type: "GET",
        success: function(data){
            datos = data.estatus;
            for(let i = 0;i < datos.length; i++){
                innerHTML += "<option value="+ datos[i].id_estatus +">"+ datos[i].descripcion +"</option>"
            }
            $("#status").append(innerHTML);
        },
        error: function(){

        }
    });
}

function GetAllTicketTable(){
    var innerHTML = "";
    var dates = $("#dates").val().split("-");
    var date1 = dates[0];
    var date2 = dates[1];
    var data = {
        date_ini: date1,
        date_fin: date2,
        idCat: $("#category").val(),
        idSubcat: $("#subcategory").val(),
        idFallo: $("#failure").val(),
        idPrioridad: $("#priority").val(),
        idEstatus: $("#idestatus").val(),
        user: $("#usuarios").val()
    }

    $.ajax({
        async: true,
        type: "GET",
        url: "getTableTickets",
        dataType: "json",
        data: data,
        success: function(data){
            datos = data.table;

            for(let i = 0; i < datos.length; i++){
                innerHTML += "<tr id='"+ datos[i].id_ticket +"'>";
                innerHTML += "<td>"+ datos[i].id_ticket +"</td>";
                innerHTML += "<td>"+ datos[i].user_owner +"</td>";
                innerHTML += "<td>"+ datos[i].titulo +"</td>";
                innerHTML += "<td>"+ datos[i].category +"</td>";
                innerHTML += "<td>"+ datos[i].subcategory +"</td>";
                innerHTML += "<td>"+ datos[i].failure +"</td>";
                innerHTML += "<td>"+ datos[i].v_date +"</td>";
                innerHTML += "<td>"+ datos[i].priority +"</td>";
                innerHTML += "<td>"+ datos[i].status +"</td>";
                innerHTML += "<td>"+ datos[i].responsible +"</td>";
                innerHTML += "<td><button type='button' class='btn btn-warning' id='btn-editTicket'>Editar</button></td>";
                innerHTML += "</tr>";
            }
            $("#table-tickets").append(innerHTML);
        }, error: function(){

        }
    });
}