$(document).ready(function () {
    $('#resultTable').DataTable({
        "language": {
            "paginate": {
                "previous": '<i class="fas fa-angle-double-left"></i>',
                "next": '<i class="fas fa-angle-double-right"></i>'
            }
        }
    });
});