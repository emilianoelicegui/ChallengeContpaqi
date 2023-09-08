$(document).ready(function () {
    var dataTable = $("#employeeTable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": false,
        "ajax": {
            "url": apiUrl + "/employee/GetAll",
            "type": "POST",
            "datatype": "json",
            "contentType": "application/json", 
            "data": function (data) {
                data.Name = $("#NameFilter").val();
                data.Rfc = $("#RfcFilter").val();
                data.Status = $("#StatusFilter").val();
                return JSON.stringify(data);
            }
        },
        "columns": [
            { "data": "fullName", "name": "Nombre Completo", "autoWidth": true },
            { "data": "email", "name": "Email", "autoWidth": true },
            { "data": "position", "name": "Posición", "autoWidth": true },
            { "data": "rfc", "name": "Rfc", "autoWidth": true },
            { "data": "hireDate", "name": "Fecha Baja", "autoWidth": true },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<button class="btn btn-primary btn-edit" data-id="' + data.id + '">Editar</button>';
                },
                "autoWidth": true
            }
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json"
        },
        "error": function (xhr, errorText) {
            console.log("Error en la solicitud AJAX: " + errorText);
        }
    });

    $('#employeeTable tbody').on('click', '.btn-edit', function () {
        var employeeId = $(this).data('id');
        window.location.href = '/Employee/AddOrUpdate/' + employeeId;
    });

    $("#btnFilter").on("click", function () {
        dataTable.ajax.reload();
    });

    $("#btnClear").on("click", function () {
        $("#NameFilter").val(""); 
        $("#RfcFilter").val("");
        $("#StatusFilter").val(0); 
        dataTable.ajax.reload(); 
    });

    $("#showFilters").click(function () {
        $("#divFilters").show();
        $("#hideFilters").show();
        $("#showFilters").hide();
    });

    $("#hideFilters").click(function () {
        $("#divFilters").hide();
        $("#hideFilters").hide();
        $("#showFilters").show();
    });
});
