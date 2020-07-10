// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmNewIncident").validate({
        // Specify validation rules
        rules: {

            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            dteIncident: {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            txtBadgeNumber: {
                required: true,
                minlength: 3,
                maxlength: 15,
                number: true
            },
            sltDepartment: {
                required: true,
            },
            sltType: {
                required: true,
            },
            txaSolution: {
                required: false,
            },
            txaActionTaken: {
                required: true,
                minlength: 3,
            },
        },

        // Specify validation error messages
        messages: {
            dteIncident: {
                required: "Select date",
            },
            txtBadgeNumber: {
                required: "Enter badge number",
                minlength: "Minimum badge number is 4 characters",
                maxlength: "Maximum badge number is 10 characters",
                number: "Enter numbers only for badge number"
            },
            sltDepartment: "Select department",
            sltType: "Select near miss type",
            txaSolution: {
                minlength: "Minimum description is 5 characters",
            },
            txaActionTaken: {
                required: "Provide description for action taken",
                minlength: "Minimum description is 5 characters",
            },
        },

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function(form) {
            form.submit();
        },
    });
});