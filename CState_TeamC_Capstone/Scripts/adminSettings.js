$(document).ready(function () {
    $('#pendingRequests').DataTable({
        "columnDefs": [
            {
                "orderable": false,
                "targets": [6, 8]
            }
        ],
        "language": {
            "paginate": {
                "previous": '<i class="fas fa-angle-double-left"></i>',
                "next": '<i class="fas fa-angle-double-right"></i>'
            }
        }
    });
});

function CallBtnAcceptClick() {
    var buttonVal = $(this).val();

    $.ajax({
        type: "POST",
        url: "adminSettings.aspx/btnAccept_Click",
        data: '{strRequestID: "' + buttonVal + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
}

function CallBtnRejectClick() {
    var buttonVal = $(this).val();

    $.ajax({
        type: "POST",
        url: "adminSettings.aspx/btnReject_Click",
        data: '{strRequestID: "' + buttonVal + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
}


function OnSuccess(response) {
    location.reload();
}

