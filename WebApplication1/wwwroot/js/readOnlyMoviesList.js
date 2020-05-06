var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {


    dataTable = $('#DT_load').dataTable({
        "ajax": {
            "url": "/api/movies",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                "data": function (data) {
                    return `<td><a href='/movies/edit/${data.id}' style='cursor:pointer;'>${data.name}</a></td>`
                },
                "width": "20%"
            },
            { "data": "genre.name", "width": "20%" },
            { "data": "releaseDate", "width": "20%" },
            { "data": "numberInStock", "width": "20%" },
      
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    })
}
