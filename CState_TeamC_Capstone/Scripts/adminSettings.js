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

