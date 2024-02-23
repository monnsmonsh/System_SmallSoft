$(document).ready(function () {
    $('#example').dataTable({
        "Lenguaje": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        }
    });
});

//User
$(document).ready(function () {
    $('#tblListUser').dataTable({
        "Lenguaje": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        }
    });
});
$(".btnEditUser").click(function (even) {
    $("#modal-content").load("/UsersAdmin/Edit/" + $(this).data("id"));
});
$(".btnDetailsUser").click(function (even) {
    $("#modal-content").load("/UsersAdmin/Details/" + $(this).data("id"));
});
$(".btnDeleteUser").click(function (even) {
    $("#modal-content").load("/UsersAdmin/Delete/" + $(this).data("id"));
});



//Proveedor
$(document).ready(function () {
    $('#tblListProveedores').dataTable({
        "Lenguaje": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        }
    });
});
$(".btnEditUser").click(function (even) {
    $("#modal-content").load("/UsersAdmin/Edit/" + $(this).data("id"));
});
$(".btnDetailsProveedor").click(function (even) {
    $("#modal-content").load("/Proveedores/Details/" + $(this).data("id"));
});
$(".btnDeleteProveedor").click(function (even) {
    $("#modal-content").load("/Proveedores/Delete/" + $(this).data("id"));
});



//Productos
$(document).ready(function () {
    $('#tblListProductos').dataTable({
        "Lenguaje": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        }
    });
});
$(".btnDetailsProducto").click(function (even) {
    $("#modal-content").load("/Productos/Details/" + $(this).data("id"));
});
$(".btnDeleteProducto").click(function (even) {
    $("#modal-content").load("/Productos/Delete/" + $(this).data("id"));
});



//Productos
$(document).ready(function () {
    $('#tblListEntradas').dataTable({
        "Lenguaje": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        }
    });
});
$(".btnDetailsEntrada").click(function (even) {
    $("#modal-content").load("/ProveedorProducto/Details/" + $(this).data("id"));
});
$(".btnDeleteEntrada").click(function (even) {
    $("#modal-content").load("/ProveedorProducto/Delete/" + $(this).data("id"));
});



//
$(document).ready(function () {
    $('#tblListVentas').dataTable({
        "Lenguaje": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Spanish.json"
        }
    });
});
$(".btnDetailsVenta").click(function (even) {
    $("#modal-content").load("/Ventas/DetailsVenta/" + $(this).data("id"));
});
//<!---->
$("#btnAddProducto").click(function (even) {
    $("#modal-content").load("/Ventas/AddProducto");
});




$(document).ready(function () {
    $('#tblListClientes').dataTable({
        "Lenguaje": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla =(",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            },
            "buttons": {
                "copy": "Copiar",
                "colvis": "Visibilidad"
            }
        }
    });
});


///
$("#btnNewCliente").click(function (even) {
    $("#modal-content").load("Clientes/Create");
});

$(".btnEditCliente").click(function (even) {
    $("#modal-content").load("/Clientes/Edit/" + $(this).data("id"));
});

$(".btnDetailsCliente").click(function (even) {
    $("#modal-content").load("/Clientes/Details/" + $(this).data("id"));
});

$(".btnDeleteCliente").click(function (even) {
    $("#modal-content").load("/Clientes/Delete/" + $(this).data("id"));
});

