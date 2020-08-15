function ShowPopup() {
    $("#exampleModal").modal("show");
    $("#exampleModal").on("hidden.bs.modal", function () {
        window.location = window.location.pathname;
    })
}