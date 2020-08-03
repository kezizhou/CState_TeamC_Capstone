// Wait for the DOM to be ready
$(function () {
    $.validator.addMethod("maxDate", function (value, element) {
        var curDate = new Date();
        var inputDate = new Date(value);
        return this.optional(element) || inputDate <= curDate;
    }, "Date cannot be after today");

    // Initialize form validation
    $("#frmNewIncident").validate({
        // Specify validation rules
        rules: {

            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            dteIncident: {
                required: true,
                maxDate: true
            },
            txtBadgeNumber: {
                required: true,
                minlength: 6,
                maxlength: 6,
                number: true
            },
            sltDepartment: {
                required: true,
            },
            sltNMType: {
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
                maxDate: "Date cannot be after today"
            },
            txtBadgeNumber: {
                required: "Enter badge number",
                minlength: "Badge number must be 6 digits",
                maxlength: "Maximum badge number is 10 characters",
                number: "Enter numbers only for badge number"
            },
            sltDepartment: "Select department",
            sltNMType: "Select near miss type",
            txaSolution: {
                minlength: "Minimum description is 5 characters",
            },
            txaActionTaken: {
                required: "Provide description for action taken",
                minlength: "Minimum description is 5 characters",
            },
        },

        // Remove focus on validate
        focusInvalid: false,

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
