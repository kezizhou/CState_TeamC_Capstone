// Wait for the DOM to be ready
$(function () {

    // Custom validation
    $.validator.addMethod("nosymbols", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9_.-]*$/i.test(value);
    }, "No special characters allowed");

    $.validator.addMethod("lettersonly", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9]*$/i.test(value);
    }, "Letters only");

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmNewIncident").validate({
        // Specify validation rules
        rules: {

            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txtFirstName: {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            txtMiddleName: {
                required: true,
                minlength: 3,
                maxlength: 15,
                number: true
            },
            txtLastName: {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            txtemployeeID: {
                required: true,
                minlength: 6,
                maxlength: 6,
                number: true
            },
            txtEmail: {
                required: true,
                email: true
            },
            sltDepartment: {
                required: true,
            },
            txtUsername: {
                required: true,
                minlength: 3,
                maxlength: 20,
                nosymbols: true
            },
            txtPassword: {
                required: true,
                minlength: 5,
                maxlength: 25
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