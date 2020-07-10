// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmUpdateIncident").validate({
        // Specify validation rules
        rules: {

            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txaActionUpdate: {
                required: true,
                minlength: 5
            }
        },

        // Specify validation error messages
        messages: {
            txaActionUpdate: {
                required: "Enter updated actions",
                minlength: "Update must be at least 5 characters"
            }
        },

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        },
    });
});