var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {


    dataTable = $('#DT_load').dataTable({
        "ajax": {
            "url": "/api/customers",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                "data": function (data) {
                    return `<td><a href='/Customers/Edit/${data.id}' style='cursor:pointer;'>${data.name}</a></td>`
                },
                "width": "20%"
            },
            {
                "data": "membershipType.discountRate",
                "render": function (data) {
                    return data + "%"

                },
                "width": "20%"
            },
            { "data": "membershipType.name", "width": "20%" },
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    })
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.api().ajax.reload();

                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });



}