

var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/user/GetAll' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'company.name', "width": "15%" },
            { data: 'role', "width": "10%" },
            {
                data: { id: 'id', lockoutEnd: 'lockoutEnd' },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return '<div class="text-center">' +
                            '<a onclick=LockUnlock(\'' + data.id + '\') class="btn btn-danger text-white" style="cursor:pointer; width:100px;"> <i class="bi bi-unlock-fill"></i>Lock</a>' +
                            '<a onclick=Permission href="/admin/user/RoleManagement?userId=' + data.id + '" class="btn btn-danger text-white" style="cursor:pointer; width:120px;"> <i class="bi bi-pencil-square"></i>Permission</a>' +
                            '</div >'
                    }
                    else {
                        return '<div class="text-center">' +
                            '<a onclick=LockUnlock(\'' + data.id + '\') class="btn btn-success text-white mr-2" style="cursor:pointer; width:100px;"> <i class="bi bi-unlock-fill"></i>Unlock</a>' +
                            '<a onclick=Permission(\'' + data.id + '\') href="/admin/user/RoleManagement?userId=' + data.id + '" class="btn btn-danger text-white" style="cursor:pointer; width:120px;"> <i class="bi bi-pencil-square"></i>Permission</a>' +
                            '</div >'
                    }

                },
                "width": "25% "
            }
        ]
    });
}


function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/user/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
    });
}

function Permission(id) {
    $.ajax({
        type: "GET",
        url: '/Admin/user/RetrieveRoleId',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (response) {
            // Handle the response here
            console.log("RoleID: " + response); // For testing, log the RoleID to console
            // You can perform further actions with the RoleID here
        },
        error: function (xhr, status, error) {
            // Handle errors here
            console.error(xhr.responseText);
        }
    });
}