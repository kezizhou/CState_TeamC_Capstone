// Wait for the DOM to be ready
$(document).ready(function () {
    // Custom validation
    $.validator.addMethod("nosymbols", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9_.-]*$/i.test(value);
    }, "No special characters allowed");

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("#frmSignIn").validate({

        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
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
            }
        },

        // Specify validation error messages
        messages: {
            txtUsername: {
                required: "Required",
                minlength: "Minimum length is 3 characters",
                maxlength: "Maximum length is 20 characters",
                nosymbols: "No special characters allowed"
            },
            txtPassword: {
                required: "Required",
                minlength: "Minimum length is 5 characters",
                maxlength: "Maximum length is 25 characters"
            }
        },

        // Specify where the error goes
        errorPlacement: function (error, element) {
            var errorElement = $(element).closest(".input-group").next(".errorInfo");
            error.appendTo(errorElement);
            errorElement.find("i").css('display', 'inline-block');
        },

        // Add the error class when it is not correct
        highlight: function (element, errorClass) {
            $(element).addClass(errorClass);
            $(element).closest(".input-group").next(".errorInfo").show();
            $(element).closest(".input-group").next(".errorInfo").children("i").css('display', 'inline-block');
        },

        // Remove the error class when it is correct
        unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
            $(element).closest(".input-group").next(".errorInfo").hide();
        },

        // Uncomment for eager validation - Validate when focus leaves
        //onfocusout: function (element) {
        //    this.element(element);
        //},

        // Remove focus on validate
        focusInvalid: false,

        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function(form) {
            form.submit();
        },
    });
});